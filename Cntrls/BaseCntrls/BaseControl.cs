using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls.BaseCntrls
{
    public partial class BaseControl : UserControl
    {
        private static bool enableClick = true;
        public static bool EnableClick
        {
            get { return enableClick; }
            set { enableClick = value; }
        }

        private bool pressed = false;
        protected bool Pressed
        {
            get { return pressed; }
        }

        private bool selected = false;
        public bool Selected
        {
            get { return selected; }
            set { selected = value; Invalidate(); }
        }

        protected bool enabled = true;
        public bool ButtonEnabled
        {
            get { return enabled; }
            set
            {
                if (!(enabled ^ value)) 
                    return;

                enabled = value;
                Invalidate();
            }
        }

        public BaseControl()
        {
            InitializeComponent();
        }

        public void Select()
        {
            selected = true;
            Invalidate();
        }

        public void Unselect()
        {
            selected = false;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!enableClick) return;

            if (!enabled) return; 

            pressed = true;
            Refresh();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!enableClick) return;

            if (!enabled) return;

            if (!pressed) return;

            pressed = false;
            Refresh();
            base.OnMouseUp(e);
            
            //if (ClientRectangle.Contains(new Point(e.X, e.Y))) 
        }

        protected override void OnClick(EventArgs e)
        {
            if (!enableClick) return;
            if (!enabled) return;

            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
    }
}
