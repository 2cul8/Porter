using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Resources;

namespace Cntrls
{  
    public partial class GraphicLabelCntrl : BaseCntrls.DoubleBufferedControl
    {
        private Bitmap backGroundBitmap = null;
        private Bitmap bottomLineBitmap = null;

        private StringAlignment allinOrizzontale = StringAlignment.Center;
        public StringAlignment AllineamentoOrizzontale
        {
            get { return allinOrizzontale; }
            set
            {  
                allinOrizzontale = value;
                Invalidate();
            }
        }

        private StringAlignment allinVerticale = StringAlignment.Center;
        public StringAlignment AllineamentoVerticale
        {
            get { return allinVerticale; }
            set
            {  
                allinVerticale = value;
                Invalidate();
            }
        }
         
        private Color labelLineColor; 
        public Color LineColor
        {
            get { return labelLineColor; }
            set
            {
                labelLineColor = value; 
                Invalidate(); 
            }
        }

        private string backGroundResourceName = string.Empty;
        public string BackGroundresourceName
        {
            get { return backGroundResourceName; }
            set
            {
                backGroundResourceName = value;
                loadBitmaps();
                Invalidate();
            }
        }

        private string bottomlineResourceName = string.Empty;
        public string BottomLineResourceName
        {
            get { return bottomlineResourceName; }
            set
            {
                bottomlineResourceName = value;
                loadBitmaps();
                Invalidate();
            }
        }

        private bool borderLeft = false;
        public bool BorderLeft
        {
            get { return borderLeft; }
            set
            {
                borderLeft = value;
                Invalidate(); 
            }
        }

        private bool borderRight = false;
        public bool BorderRight
        {
            get { return borderRight; }
            set
            {
                borderRight = value;
                Invalidate();
            }
        }

        private bool borderTop = false;
        public bool BorderTop
        {
            get { return borderTop; }
            set
            {
                borderTop = value;
                Invalidate();
            }
        }

        private bool borderBottom = false;
        public bool BorderBottom
        {
            get { return borderBottom; }
            set
            {
                borderBottom = value;
                Invalidate();
            }
        }

        private bool enableDebug = false;
        public bool EnableDebug
        {
            get { return enableDebug; }
            set { enableDebug = value; }
        }

        public GraphicLabelCntrl()
            : base()
        { 
            InitializeComponent(); 
        }

        private void loadBitmaps()
        {
            backGroundBitmap = (Bitmap)Resources.ResourcesManager.GetResource(backGroundResourceName, ResourceType.Image);
            bottomLineBitmap = (Bitmap)Resources.ResourcesManager.GetResource(bottomlineResourceName, ResourceType.Image);
        }

        protected override void OnResize(EventArgs e)
        { 
            base.OnResize(e); 
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            using (doubleBuffer = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
            {
                gr.Clear(BackColor);

                if (backGroundBitmap != null)
                    gr.DrawImage(backGroundBitmap, 0, 0);

                if (bottomLineBitmap != null)
                    gr.DrawImage(bottomLineBitmap, (Width - bottomLineBitmap.Width) / 2, Height - bottomLineBitmap.Height);

                using (Brush textBrush = new SolidBrush(ForeColor))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = allinOrizzontale;
                    sf.LineAlignment = allinVerticale;
                    sf.FormatFlags = StringFormatFlags.NoClip;
                    gr.DrawString(Text, Font, textBrush, new Rectangle(0, 0, Width, Height), sf);
                }

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            }

            //base.OnPaint(e);
        }  
    }
}
