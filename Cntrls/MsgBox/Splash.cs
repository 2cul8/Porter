using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Utility;

namespace Cntrls
{
    public partial class Splash : Form
    {
        private static bool pShowing = false;
        public static  bool Showing
        {
            get { return pShowing; }
        }

        internal Splash()
        {
            InitializeComponent(); 
            InitGraphics();
        }

        private void InitGraphics()
        {
            this.Size = new Size(428, 166);
            this.Location = Utils.CenterScreen(this.Size);

            TopMost = true;
            lblText.LinePosition = eLinePosition.All;
        }

        public void Show(string Text)
        {
            lblText.Text = Text;
            base.Show(); 

            pShowing = true;
        }

        private new void Close() { }

        internal void Close(bool Dispose)
        {
            if (!Dispose)
                base.Hide();
            else
                base.Close();

            pShowing = false;
        }
    }
}