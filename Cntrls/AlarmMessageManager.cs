using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Utility; 
using Utility.Allarm; 

namespace Cntrls 
{
    public delegate void dAllarmAdded(AlarmType alInfo);
    public delegate void dAllarmListCleared(); 

    public partial class AllarmMessageManager : UserControl
    { 
        private List<AlarmInfo> CurrentAlarmList = null; //Storico messaggi
        private AlarmType CurrentAlarm = null; //Messaggio visualizzato
        private AlarmInfo CurrentAlarmInfo = null;

        public event dAllarmAdded AlarmAdded;
        public event dAllarmListCleared AlarmListCleared;  
          
        private bool _OfflineMode;
        public bool OfflineMode
        {
            get { return _OfflineMode; }
            set
            {
                if (value == _OfflineMode)
                    return;

                _OfflineMode = value; 
                Refresh(); 
            }
        }

        public List<AlarmInfo> AlarmList
        {
            get { return CurrentAlarmList; }
        } 

        private StringFormat sf;

        public AllarmMessageManager()
        {
            InitializeComponent();

            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center; 
            CurrentAlarmList = new List<AlarmInfo>();
            CurrentAlarm = AllarmManager.GetNoAlarmMessage(); 
            SetMessage(); 
        }
         
        public void AggiungiAllarme(AlarmType Al)
        {
            if (CurrentAlarmInfo != null && CurrentAlarmInfo.Alarm.Indice == Al.Indice) //Per non aggiungere sempre lo stesso allarme
                return;

            CurrentAlarmInfo = new AlarmInfo(Al);
            CurrentAlarmList.Add(CurrentAlarmInfo);

            CurrentAlarm = Al; 

            try
            {
                if (AlarmAdded != null)
                    AlarmAdded.Invoke(CurrentAlarm);
            }
            catch { }

            SetMessage(); 
        }

        public void CancellaAllarmi()
        { 
            if (CurrentAlarmList != null)
                CurrentAlarmList.Clear();
            else
                CurrentAlarmList = new List<AlarmInfo>();

            if (CurrentAlarm == null)
                CurrentAlarm = AllarmManager.GetNoAlarmMessage(); 

            if (CurrentAlarm.Indice == AllarmManager.GetNoAlarmMessage().Indice)
                return;

            CurrentAlarm = AllarmManager.GetNoAlarmMessage();
            CurrentAlarmInfo = new AlarmInfo(CurrentAlarm);

            try
            {
                if (AlarmListCleared != null)
                    AlarmListCleared.Invoke();
            }
            catch (Exception ex) { LogManager.WriteLogMessage(ex); }

            SetMessage();
        }

        public void EliminaAllarme(int Index)
        {
            foreach (AlarmInfo a in CurrentAlarmList) 
                if (a.Alarm.Indice == Index)
                {
                    CurrentAlarmList.Remove(a);
                    return;
                } 
        }
          
        private void SetMessage()
        { 
            try
            {  
                if (CurrentAlarm.Priority == eAlarmPriority.Error)
                { 
                    BackColor = Color.Red;
                    ForeColor = Color.White; 
                }

                if (CurrentAlarm.Priority == eAlarmPriority.Warning)
                { 
                    BackColor = Color.Yellow;
                    ForeColor = Color.Black; 
                }

                if (CurrentAlarm.Priority == eAlarmPriority.NoError)
                {  
                    BackColor = Color.Lime;
                    ForeColor = Color.Black; 
                } 

                Invalidate();
            }
            catch (ObjectDisposedException OdEx)
            {
                string[] dd = new string[3] { "AlarmMessageManager refresh message Error.", "Posi:0034", OdEx.StackTrace };
                LogManager.WriteLogMessage(OdEx.Message, dd);
            }
        }
         
        private Color _currentColor = Color.Gold; 

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bDoubleBuffer = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bDoubleBuffer); 

            Rectangle rClient = ClientRectangle;
            rClient.Width--;
            rClient.Height--;

            if (!_OfflineMode)
                if (CurrentAlarm != null)
                {
                    SizeF stringSize = gr.MeasureString(CurrentAlarm.Name[AppVariables.SelectedLanguage], Font);
                    RectangleF rText = new RectangleF((Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2, stringSize.Width, stringSize.Height);

                    gr.FillRectangle(new SolidBrush(BackColor), rClient);

                    gr.DrawString(CurrentAlarm.Name[AppVariables.SelectedLanguage], Font, new SolidBrush(ForeColor), rText);
                    gr.DrawRectangle(new Pen(Color.FromArgb(64, 64, 64)), rClient);
                    e.Graphics.DrawImage(bDoubleBuffer, 0, 0);
                }
                else { }
            else
            {
                SizeF stringSize = gr.MeasureString("Terminale in Modalità Offline", Font);
                RectangleF rText = new RectangleF((Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2, stringSize.Width, stringSize.Height);
                gr.FillRectangle(new SolidBrush(Color.Black), rClient);
                gr.DrawRectangle(new Pen(Color.FromArgb(64, 64, 64), 1.0F), rClient); 

                gr.DrawString("Terminale in Modalità Offline", Font, new SolidBrush(Color.Gainsboro), rText); 
                e.Graphics.DrawImage(bDoubleBuffer, 0, 0); 
            }

            base.OnPaint(e);  
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        { } 
    }
}
