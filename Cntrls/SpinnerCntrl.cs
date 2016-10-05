using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{
    public partial class SpinnerCntrl : BaseCntrls.DoubleBufferedControl
    {
        private const int SPINNER_BITMAPS_COUNT = 20;

        private Bitmap[] spinnerBitmaps;
        private int currentSpinBitmap = 0;

        private bool spinOn = false;
        public bool SpinOn
        {
            get { return spinOn; }
            set
            {
                spinOn = value;
                tmrChangeBitmap.Enabled = spinOn;
                currentSpinBitmap = 0;
            }
        }

        private string spinnerFramesDir = "SpinnerFramesBlack";
        public string SpinnerFramesDir
        {
            get { return spinnerFramesDir; }
            set
            {
                spinnerFramesDir = value;
                loadSpinners();
            }
        }

        public SpinnerCntrl()
        { 
            InitializeComponent();
        }

        private void loadSpinners()
        {
            spinnerBitmaps = new Bitmap[SPINNER_BITMAPS_COUNT];  

            for (int i = 0; i < SPINNER_BITMAPS_COUNT; i++)
                spinnerBitmaps[i] = (Bitmap)Resources.ResourcesManager.GetResource(spinnerFramesDir + ".frame_" + i.ToString() + ".gif", Resources.ResourceType.Image);
        }

        private void onTmrTick(object sender, EventArgs e)
        {
            if (currentSpinBitmap + 1 >= SPINNER_BITMAPS_COUNT)
                currentSpinBitmap = 0;
            else
                currentSpinBitmap++;

            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            using (doubleBuffer = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
            {
                gr.DrawImage(spinnerBitmaps[currentSpinBitmap], 0, 0);
                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            }
        }
    }
}
