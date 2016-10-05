using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Resources;
using LocationManagement;

namespace SagoPorter
{
    public partial class FrmLocation : Form
    {
        private Bitmap backGroundBitmap;

        private int selectedLocation = 0;
        public int SelectedLocation
        {
            get { return selectedLocation; }
        }

        public FrmLocation()
        {
            InitializeComponent();
            backGroundBitmap = (Bitmap)Resources.ResourcesManager.GetResource("background667x400.bmp", Resources.ResourceType.Image); 
        }

        public new DialogResult ShowDialog()
        {
            List<string> locations = new List<string>();

            foreach (Location l in LocationManager.Locations)
                locations.Add(l.LocationName);

            locationsList.AddStringhe(locations);

            Size = new Size(667, 400);
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);

            lblTitle.TextLabel = "FrmLocation.lblTitle.Text";
            lblInfo.TextLabel = "FrmLocation.lblInfo.Text";
            return base.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBuffer = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
                gr.DrawImage(backGroundBitmap, 0, 0);

            e.Graphics.DrawImage(doubleBuffer, 0, 0);
        } 

        private void abortRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void sendRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        } 

        private void onLineSelected(object sender, EventArgs e)
        {
            selectedLocation = locationsList.CurrentSelectedLine;
        }
    }
}