#define MANAGE_LAMP

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.WindowsCE.Forms;

using Cntrls.Boxes;
using PorterProto;
using RfidManager;
using UserManagement;
using NetManagement;
using LogManagement;

namespace SagoPorter
{

    internal partial class FrmLoader : Form
    {
        FrmHome frmHome;
        FrmHider frmHider;
        private int loadingStatus;
        private int testComCount = 1;

        public FrmLoader()
        {
            frmHider = new FrmHider();
            frmHider.Show();

            WindowsManager.CloseAllRequested += new EventHandler(closeAllRequested);
            WindowsManager.MinimizeRequested += new EventHandler(minimizeRequested);

#if MANAGE_LAMP
            if (PowerManagement.InitManager())
            { }
#endif 
            loadingStatus = 0;
            Visible = false;
            Resources.Resources.LoadAllResources();
            Visible = true;

            InitializeComponent();
            lblStatus.TextLabel = "FrmLoading.lblStatus.Text.1";
            lblMessages.TextLabel = lblMessages.SetLabelFormatArgs("FrmLoading.lblMessages.Text.1", ".  ");

            DeviceEvents.OnDeviceConnected += new EventHandler(deviceConnected);
            DeviceEvents.OnDeviceError += new DeviceErrorEventHandler(onDeviceError); 
            
            tmrFrmLoaded.Enabled = true;

            (new Thread(refreshDaemon)).Start(); 
        }

        private void minimizeRequested(object sender, EventArgs e)
        {
            System.Diagnostics.Process explorer = new System.Diagnostics.Process();
            explorer.StartInfo.FileName = "explorer.exe";
            explorer.Start();
        }

        private void closeAllRequested(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();  
        }

        private void refreshDaemon()
        {
            //while (loadingStatus != 10)
            //{
            //    Application.DoEvents();
            //    Thread.Sleep(100);
            //}
        }

        private void onDeviceError(object sender, DeviceErrorEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new DeviceErrorEventHandler(onDeviceError), new object[] { sender, e });
            else
                switch (e.Error.Id)
                {
                    case 200: // ERRORE TIMEOUT
                        loadingStatus = 5;
                        testComCount++;
                        break;

                    case 202: // ERRORE DURANTE INIZIALIZZAZIONE
                        loadingStatus = 7;
                        break;

                    case 101: // ERRORE DURANTE L'APERTURA DELLA COM
                        loadingStatus = 8;
                        break;
                }
        }
         
        private void onFrmLoadedTick(object sender, EventArgs e)
        { 
            switch (loadingStatus)
            {
                case 0:
                    LogManager.SetDirectory(Resources.Utils.GetApplicationPath());
                    frmHider.Close();
                    frmHider = null;
                    PowerManagement.TurnOnLamp(); 
                    frmHome = new FrmHome();
                    loadingStatus = 1;
                    return;

                case 1:
                    lblMessages.TextLabel = lblMessages.SetLabelFormatArgs("FrmLoading.lblMessages.Text.1", " . ");
                    frmHome.initSpecialForm();
                    loadingStatus = 2;
                    return;

                case 2:
                    lblMessages.TextLabel = lblMessages.SetLabelFormatArgs("FrmLoading.lblMessages.Text.1", "  .");
                    Boxes.InitBoxes();
                    loadingStatus = 3;
                    return;

                case 3:
                    lblMessages.TextLabel = "FrmLoading.lblMessages.Text.2"; 
                    NetworkManager.InitManager();

                    try
                    {
                        if (!DeviceInterface.initDevice())
                        {
                            lblMessages.TextLabel = "FrmLoading.lblMessages.Text.3";
                            tmrFrmLoaded.Enabled = false;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show(ex.StackTrace);
                        tmrFrmLoaded.Enabled = false;
                        return;
                    }

                    BatteryStatusManager.InitializeManager();
                    UserManager.InitializeManager();
                    LettoManager.InitializeManager(); 
                    loadingStatus = 4;
                    return;

                case 4:
                    lblMessages.TextLabel = "FrmLoading.lblMessages.Text.4";
                    NetworkManager.StartListening();
                    DeviceInterface.AvviaComunicazione();
                    LettoManager.StartListening();
                    loadingStatus = 999;
                    return;

                case 5: // Comunicazione in TimeOut 
                    loadingStatus = 6;
                    lblMessages.TextLabel = "FrmLoading.lblMessages.Text.5";
                    return;

                case 6: // Comunicazione in TimeOut 
                    lblMessages.TextLabel = lblMessages.SetLabelFormatArgs("FrmLoading.lblMessages.Text.6", testComCount);
                    DeviceInterface.AvviaComunicazione();
                    loadingStatus = 999;
                    return;

                case 7: 
                    loadingStatus = 6;
                    lblMessages.TextLabel = lblMessages.SetLabelFormatArgs("FrmLoading.lblMessages.Text.7", 202);
                    tmrFrmLoaded.Enabled = false;
                    spinnerCntrl1.SpinOn = false;
                    return;

                case 8:
                    lblMessages.TextLabel = lblMessages.SetLabelFormatArgs("FrmLoading.lblMessages.Text.7", 101);
                    tmrFrmLoaded.Enabled = false;
                    spinnerCntrl1.SpinOn = false;
                    return;
                    
                case 10:
                    Close();
                    return;

                case 999:
                    return;
            }  
        }

        private void deviceConnected(object sender, EventArgs e)
        { 
            if (InvokeRequired)
                Invoke(new EventHandler(deviceConnected), new object[] { sender, e });
            else
            {
                tmrFrmLoaded.Enabled = false;  
                frmHome.Show();
                spinnerCntrl1.SpinOn = false;
            }
        } 
    }
}