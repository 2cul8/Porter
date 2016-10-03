using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PorterProto;

namespace SagoPorter
{
    public partial class FrmMessages : Form
    {
        private Bitmap backGroundBitmap;
        private MessageList messageList;

        public FrmMessages()
        {
            InitializeComponent(); 
            backGroundBitmap = (Bitmap)Resources.Resources.GetResource("background667x400.bmp", Resources.ResourceType.Image); 
            Size = new Size(667, 400);
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2); 
        }

        public new void ShowDialog()
        { 
            lblTitle.TextLabel = "Stato Allarmi";
            tmrRefresh.Enabled = true;
            messageList = (MessageList)DeviceData.GetDeviceData(DeviceDataDef.Messages);
            refreshShowedMessage();

            base.ShowDialog();
            tmrRefresh.Enabled = false;
        }

        private void refreshShowedMessage()
        {
            if (messagesTabCntrl1.SelectedItem < messageList.Count)
                lblSelectedMessageText.TextLabel = (string)Resources.Resources.GetResource(messageList[messagesTabCntrl1.SelectedItem].MessageResourceName, Resources.ResourceType.String);
            else
                lblSelectedMessageText.TextLabel = "----";
        }
        private void closeRequested(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshTick(object sender, EventArgs e)
        {
            messageList = (MessageList)DeviceData.GetDeviceData(DeviceDataDef.Messages);
            bool[] flags = new bool[messageList.Count];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = messageList[i].IsActive;

            messagesTabCntrl1.SetFlagsStatus(flags);
        }

        private void onItemSelected(object sender, EventArgs e)
        {
            refreshShowedMessage();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
                gr.DrawImage(backGroundBitmap, 0, 0);

            e.Graphics.DrawImage(doubleBuffer, 0, 0);
        } 

    }
}