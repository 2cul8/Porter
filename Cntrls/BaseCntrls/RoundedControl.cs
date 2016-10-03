using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.BaseCntrls
{
    public partial class RoundedControl : BorderedControl
    {
        protected int roundSize = 0;
        public int RoundSize
        {
            get { return roundSize; }
            set { roundSize = value; Invalidate(); }
        }

        public RoundedControl()
        {
            InitializeComponent();
        }
    }
}
