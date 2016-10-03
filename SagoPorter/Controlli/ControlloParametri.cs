using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PorterProto;
using Cntrls.Boxes;
using Cntrls;

namespace SagoPorter.Controlli
{
    public partial class ControlloParametri : UserControl
    {
        private Parametro selectedPar = null;

        enum showedPar
        {
            parAsse = 0, 
            parMacchina = 2, 
            parPlc = 4, 

            none = 999
        }

        private showedPar currentShowed = showedPar.none;

        public ControlloParametri()
        {
            InitializeComponent();
            DeviceEvents.OnLocalParsLoaded += new EventHandler(onLocalParsLoaded);
            DeviceEvents.OnDeviceParsDownloaded += new EventHandler(onDeviceParsDownloaded);
        }

        public new void Show()
        {
            DeviceEvents.OnDeviceParsUploaded += new EventHandler(onDeviceParsUploaded);
            DeviceEvents.OnDeviceParsDownloading += new EventHandler(onDeviceParsDownloading);
            DeviceEvents.OnDeviceParsUploading += new EventHandler(onDeviceParsUploading);

            ShowPar(showedPar.parAsse);
            Visible = true;
            BringToFront();
        }

        public new void Hide()
        {
            DeviceEvents.OnDeviceParsUploaded -= new EventHandler(onDeviceParsUploaded);
            DeviceEvents.OnDeviceParsDownloading -= new EventHandler(onDeviceParsDownloading);
            DeviceEvents.OnDeviceParsUploading -= new EventHandler(onDeviceParsUploading);

            Visible = false;
            SendToBack();
        }

        public void manageClose()
        {
            DeviceEvents.OnLocalParsLoaded -= new EventHandler(onLocalParsLoaded);
            DeviceEvents.OnDeviceParsDownloaded -= new EventHandler(onDeviceParsDownloaded);
        }

        private void onLocalParsLoaded(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(onLocalParsLoaded), new object[] { sender, e });
            else
                setLocalPars();
        }

        private void onDeviceParsDownloading(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(onDeviceParsDownloading), new object[] { sender, e });
            else
                Boxes.ShowProgressDialog("Richiesta parametri in corso...", new frmProgressDialog.PercentageValueDelegate(DeviceInterface.GetOperationPercentage));
        }

        private void onDeviceParsDownloaded(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(onDeviceParsDownloaded), new object[] { sender, e });
            else
                setDevicePars();
        }

        private void onDeviceParsUploading(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new EventHandler(onDeviceParsUploading), new object[] { sender, e });
            else
                Boxes.ShowProgressDialog("Invio parametri in corso...", new frmProgressDialog.PercentageValueDelegate(DeviceInterface.GetOperationPercentage));
        }

        private void onDeviceParsUploaded(object sender, EventArgs e)
        {
            DeviceData.SaveLocalPars(string.Empty);
            Boxes.CloseProgressDialog();
        }

        private void setLocalPars()
        {
            int index = 0;
            string[] rowTexts = new string[DeviceConstants.PAR_ASSE];
            string[,] values = new string[DeviceConstants.PAR_ASSE, DeviceConstants.NUM_ASSI];  

            for (int asseListIndex = 0; asseListIndex < DeviceConstants.NUM_ASSI; asseListIndex++)
            {
                ListaParametri parAsse = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars)).GetParList(TipoParametro.Asse, asseListIndex);

                if (asseListIndex == 0) 
                    for (int i = 0; i < rowTexts.Length; i++)
                        rowTexts[i] = parAsse[i].ParName; 

                for (int row = 0; row < parAsse.Count; row++)
                    values[row, asseListIndex] = parAsse[row].ParValue.ToString();
            }

            PageColumnsText parAssePageColumns = new PageColumnsText();
            ColumnsText parAsseColumns = new ColumnsText();

            parAsseColumns.Add("ASSE 1");
            parAsseColumns.Add("ASSE 2");
            parAsseColumns.Add("ASSE 3");
            parAsseColumns.Add("ASSE 4");
            parAssePageColumns.Add(parAsseColumns);

            tabAsse.SetColumnsText(parAssePageColumns);
            tabAsse.SetRowsText(rowTexts);  
            tabAsse.SetValues(values);

            rowTexts = new string[DeviceConstants.PAR_MACCHINA];
            values = new string[DeviceConstants.PAR_MACCHINA, 1];

            ListaParametri parMacchina = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars)).GetParList(TipoParametro.Macchina);

            for (int i = 0; i < parMacchina.Count; i++)
                rowTexts[i] = parMacchina[i].ParName;

            for (int row = 0; row < parMacchina.Count; row++)
                values[row, 0] = parMacchina[row].ParValue.ToString();

            PageColumnsText parMacchinaPageColumns = new PageColumnsText();
            ColumnsText parMacchinaColumns = new ColumnsText();

            parMacchinaColumns.Add("VALORI");
            parMacchinaPageColumns.Add(parMacchinaColumns);

            tabMacchina.SetColumnsText(parMacchinaPageColumns);
            tabMacchina.SetRowsText(rowTexts);
            tabMacchina.SetValues(values);
            
            rowTexts = new string[tabPlc.RowCount * 3];
            values = new string[tabPlc.RowCount * 3, 1];

            ListaParametri parTimer = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars)).GetParList(TipoParametro.Timer);

            for (int c = 0; c < tabPlc.RowCount; index++, c++)
            {
                rowTexts[index] = c >= parTimer.Count ? string.Empty : parTimer[c].ParName;
                values[index, 0] = c >= parTimer.Count ? string.Empty : parTimer[c].ParValue.ToString();
            }

            ListaParametri parContatori = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars)).GetParList(TipoParametro.Contatori);

            for (int c = 0; c < tabPlc.RowCount; index++, c++)
            {
                rowTexts[index] = c >= parContatori.Count ? string.Empty : parContatori[c].ParName;
                values[index, 0] = c >= parContatori.Count ? string.Empty : parContatori[c].ParValue.ToString();
            }

            ListaParametri parMonostabili = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars)).GetParList(TipoParametro.Monostabili);

            for (int c = 0; c < tabPlc.RowCount; index++, c++)
            {
                rowTexts[index] = c >= parMonostabili.Count ? string.Empty : parMonostabili[c].ParName;
                values[index, 0] = c >= parMonostabili.Count ? string.Empty : parMonostabili[c].ParValue.ToString();
            }

            PageColumnsText parPlcPageColumns = new PageColumnsText();
            ColumnsText parTimerColumns = new ColumnsText();
            parTimerColumns.Add("Timer");
            parPlcPageColumns.Add(parTimerColumns);

            ColumnsText parContatoriColumns = new ColumnsText();
            parContatoriColumns.Add("Contatori");
            parPlcPageColumns.Add(parContatoriColumns);

            ColumnsText parMonostabiliColumns = new ColumnsText();
            parMonostabiliColumns.Add("Monostabili");
            parPlcPageColumns.Add(parMonostabiliColumns);

            tabPlc.SetColumnsText(parPlcPageColumns);
            tabPlc.SetRowsText(rowTexts);
            tabPlc.SetValues(values);
        }

        private void setDevicePars()
        {
            //return;
            int index = 0;
            string[,] values = new string[DeviceConstants.PAR_ASSE, DeviceConstants.NUM_ASSI]; 

            for (int asseListIndex = 0; asseListIndex < DeviceConstants.NUM_ASSI; asseListIndex++)
            {
                ListaParametri parAsse = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.DeviceDownloadedPars)).GetParList(TipoParametro.Asse, asseListIndex);
                 
                for (int row = 0; row < parAsse.Count; row++)
                    values[row, asseListIndex] = parAsse[row].ParValue.ToString();
            }

            tabAsse.SetDeviceValues(values);

            values = new string[DeviceConstants.PAR_MACCHINA, 1];
            ListaParametri parMacchina = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.DeviceDownloadedPars)).GetParList(TipoParametro.Macchina);
             
            for (int row = 0; row < parMacchina.Count; row++)
                values[row, 0] = parMacchina[row].ParValue.ToString();

            tabMacchina.SetDeviceValues(values);

            values = new string[tabPlc.RowCount * 3, 1];

            ListaParametri parTimer = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.DeviceDownloadedPars)).GetParList(TipoParametro.Timer);

            for (int c = 0; c < tabPlc.RowCount; index++, c++) 
                values[index, 0] = c >= parTimer.Count ? string.Empty : parTimer[c].ParValue.ToString(); 

            ListaParametri parContatori = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.DeviceDownloadedPars)).GetParList(TipoParametro.Contatori);

            for (int c = 0; c < tabPlc.RowCount; index++, c++) 
                values[index, 0] = c >= parContatori.Count ? string.Empty : parContatori[c].ParValue.ToString(); 

            ListaParametri parMonostabili = ((DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.DeviceDownloadedPars)).GetParList(TipoParametro.Monostabili);

            for (int c = 0; c < tabPlc.RowCount; index++, c++) 
                values[index, 0] = c >= parMonostabili.Count ? string.Empty : parMonostabili[c].ParValue.ToString();

            tabPlc.SetDeviceValues(values);

            Boxes.CloseProgressDialog();
        }

        private void showParAsseRequest(object sender, EventArgs e)
        {
            ShowPar(showedPar.parAsse);
        }

        private void showParMacchinaRequest(object sender, EventArgs e)
        {
            ShowPar(showedPar.parMacchina);
        }

        private void showParPlcRequested(object sender, EventArgs e)
        {
            ShowPar(showedPar.parPlc);
        } 

        private void ShowPar(showedPar toShow)
        {
            if (toShow == currentShowed)
                return; 

            selectedPar = null;

            switch (toShow)
            {
                case showedPar.parAsse: 
                    tabAsse.ResetSelected();
                    tabAsse.Visible = true;
                    tabAsse.BringToFront();

                    btnShowParAsse.Select();
                    btnShowParAsse.BringToFront();

                    btnShowParPlc.Unselect();
                    btnShowParMacchina.Unselect();
                    break; 

                case showedPar.parMacchina: 
                    tabMacchina.ResetSelected();
                    tabMacchina.Visible = true;
                    tabMacchina.BringToFront();

                    btnShowParMacchina.Select();
                    btnShowParMacchina.BringToFront();

                    btnShowParPlc.Unselect(); btnShowParPlc.SendToBack();
                    btnShowParAsse.Unselect(); btnShowParAsse.SendToBack();
                    break;

                case showedPar.parPlc:
                    tabPlc.ResetSelected();
                    tabPlc.Visible = true;
                    tabPlc.BringToFront();

                    btnShowParPlc.Select();
                    btnShowParPlc.BringToFront();

                    btnShowParMacchina.Unselect(); btnShowParMacchina.SendToBack();
                    btnShowParAsse.Unselect(); btnShowParAsse.SendToBack();
                    break;

                default: return;
            }

            selectedPar = null;
            currentShowed = toShow;
        }

        private void onSetParRequest(object sender, EventArgs e)
        {
            string newValue = string.Empty;

            if (selectedPar == null)
                return;

            if ((newValue = Boxes.ShowNumPad(selectedPar.ParName, selectedPar.ParValue.ToString())).Equals(string.Empty))
                return;

            int value = 0;
            try
            {
                value = int.Parse(newValue); 

                switch (selectedPar.ParTipo)
                {
                    case TipoParametro.Asse: 
                        if (DeviceData.SetParValue(TipoParametro.Asse, tabAsse.SelectedAbsoluteCell.X, tabAsse.SelectedAbsoluteCell.Y, value))
                            tabAsse.SetValue(tabAsse.SelectedAbsoluteCell, value.ToString());
                        break;

                    case TipoParametro.Macchina:
                        if (DeviceData.SetParValue(TipoParametro.Macchina, selectedPar.ParIndex, value))
                            tabMacchina.SetValue(tabMacchina.SelectedAbsoluteCell, value.ToString());
                        break;

                    case TipoParametro.Timer:
                        if (DeviceData.SetParValue(TipoParametro.Timer, selectedPar.ParIndex, value))
                            tabPlc.SetValue(tabPlc.SelectedAbsoluteCell, value.ToString());
                        break;

                    case TipoParametro.Contatori:
                        if (DeviceData.SetParValue(TipoParametro.Contatori, selectedPar.ParIndex, value))
                            tabPlc.SetValue(tabPlc.SelectedAbsoluteCell, value.ToString()); 
                        break;

                    case TipoParametro.Monostabili:
                        if (DeviceData.SetParValue(TipoParametro.Monostabili, selectedPar.ParIndex, value))
                            tabPlc.SetValue(tabPlc.SelectedAbsoluteCell, value.ToString());
                        break; 
                }

            }
            catch
            { return; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            using (Pen leftLinePen = new Pen(Color.FromArgb(64, 64, 64)))
                gr.DrawLine(leftLinePen, 0, 0, 0, Height);

            base.OnPaint(e);
        } 

        private void saveRequested(object sender, EventArgs e)
        {
            DeviceData.SaveLocalPars(string.Empty);
        } 

        private void reciveParRequested(object sender, EventArgs e)
        {
            DeviceInterface.RichiediParametriDispositivo();
        }

        private void sendParsRequested(object sender, EventArgs e)
        {
            DeviceInterface.InviaParametriLocali();
        }

        private void sincWithDeviceRequested(object sender, EventArgs e)
        {

            if (Boxes.ShowMessageDialog("Parmetri", "I valori salvati su terminale verranno sovrascritti. Continuare?", frmMessageBox.MessageLevel.Message, frmMessageBox.BoxResponse.YesNo) == DialogResult.OK)
            {
                DeviceData.SynchParsWithDevice();
                DeviceData.SaveLocalPars(string.Empty);
            }
        }

        private void showInfoRequested(object sender, EventArgs e)
        {
            if (selectedPar == null) return;
            Boxes.ShowMessageDialog(selectedPar.ParName, selectedPar.ParDesc, frmMessageBox.MessageLevel.Message);
        }  

        private void onParAsseSelected(object sender, EventArgs e)
        {
            if (tabAsse.SelectedAbsoluteCell.Equals(TableCell.Empty))
                selectedPar = null;

            DataBaseParametri pars = (DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars);

            try
            {
                if (tabAsse.SelectedAbsoluteCell.X < DeviceConstants.NUM_ASSI & tabAsse.SelectedAbsoluteCell.Y < DeviceConstants.PAR_ASSE) 
                        selectedPar = pars.GetParList(TipoParametro.Asse, tabAsse.SelectedAbsoluteCell.X)[tabAsse.SelectedAbsoluteCell.Y];
                    else
                        tabAsse.ResetSelected();
            }
            catch
            {
                tabAsse.ResetSelected();
            }
        }

        private void onParMacchinaSelected(object sender, EventArgs e)
        {
            if (tabMacchina.SelectedAbsoluteCell.Equals(TableCell.Empty))
                selectedPar = null;

            DataBaseParametri pars = (DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars);

            try
            {
                if (tabMacchina.SelectedAbsoluteCell.X < 1 & tabMacchina.SelectedAbsoluteCell.Y < DeviceConstants.PAR_MACCHINA)
                    selectedPar = pars.GetParList(TipoParametro.Macchina)[tabMacchina.SelectedAbsoluteCell.Y];
                else
                    tabMacchina.ResetSelected();
            }
            catch
            {
                tabMacchina.ResetSelected();
            }
        }

        private void onParPlcSelected(object sender, EventArgs e)
        {
            if (tabPlc.SelectedAbsoluteCell.Equals(TableCell.Empty))
                selectedPar = null;

            DataBaseParametri pars = (DataBaseParametri)DeviceData.GetDeviceData(DeviceDataDef.localPars);

            try
            {
                switch (tabPlc.CurrentPage)
                {
                    case 0:
                        if (tabPlc.SelectedAbsoluteCell.X < 1 & tabPlc.SelectedRelativeCell.Y < DeviceConstants.PAR_TIMER)
                            selectedPar = pars.GetParList(TipoParametro.Timer)[tabPlc.SelectedRelativeCell.Y];
                        else
                            tabPlc.ResetSelected();
                        break;

                    case 1:
                        if (tabPlc.SelectedAbsoluteCell.X < 1 & tabPlc.SelectedRelativeCell.Y < DeviceConstants.PAR_TIMER)
                            selectedPar = pars.GetParList(TipoParametro.Contatori)[tabPlc.SelectedRelativeCell.Y];
                        else
                            tabPlc.ResetSelected();
                        break;

                    case 2:
                        if (tabPlc.SelectedAbsoluteCell.X < 1 & tabPlc.SelectedRelativeCell.Y < DeviceConstants.PAR_TIMER)
                            selectedPar = pars.GetParList(TipoParametro.Monostabili)[tabPlc.SelectedRelativeCell.Y];
                        else
                            tabPlc.ResetSelected();
                        break;
                } 
            }
            catch
            {
                tabPlc.ResetSelected();
            }
        }
    }
}
