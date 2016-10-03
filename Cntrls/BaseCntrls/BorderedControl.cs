using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.BaseCntrls
{
    public partial class BorderedControl : DoubleBufferedControl
    {
        protected float borderWidth = 1.0f;
        public float BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }

        protected Color borderColor = Color.Transparent;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        public BorderedControl()
        {
            InitializeComponent();
        }
    }
}
