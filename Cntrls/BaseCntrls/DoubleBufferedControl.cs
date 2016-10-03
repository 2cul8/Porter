using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.BaseCntrls
{
    public partial class DoubleBufferedControl : TextControl
    {
        protected static Bitmap doubleBuffer;

        public DoubleBufferedControl()
        {
            doubleBuffer = new Bitmap(Width, Height);
            InitializeComponent();
        } 
    }
}
