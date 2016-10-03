using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Utility;

namespace Cntrls
{
    public partial class CkBox : UserControl
    {
        public enum eCkBoxImage : short
        {
            Big = 0x00,
            Small = 0xFF
        }

        private bool _Checked = false;
        public event EventHandler CheckStateChanged = null;

        private eCkBoxImage pImageType = eCkBoxImage.Big;
        public eCkBoxImage ImageType
        {
            get { return pImageType; }
            set { pImageType = value; }
        }

        private bool pClickEnable = true;
        public bool CanClick
        {
            get { return pClickEnable; }
            set { pClickEnable = value; }
        }

        public bool Checked
        {
            get { return _Checked; }
            set 
            {
                if (_Checked == value)
                    return;

                _Checked = value;
                                
                if (CheckStateChanged != null)
                    CheckStateChanged.Invoke(this, new EventArgs());

                Refresh();
            }
        }

        private bool pUseErrorIcon = false;
        public bool UseErrorIcon
        {
            get { return pUseErrorIcon; }
            set { pUseErrorIcon = value; Refresh(); }
        }

        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public CkBox()
        {
            InitializeComponent();
        }

        private Bitmap BufferBmp = null;
        protected override void OnPaint(PaintEventArgs e)
        {
            if (BufferBmp == null)
                BufferBmp = new Bitmap(Width, Height);

            Graphics Gr = Graphics.FromImage(BufferBmp);

            Bitmap ToShow = null;

            if (ImageManager.ImagesLoaded)
                if (!pUseErrorIcon)
                    if (_Checked)
                        if (pImageType == eCkBoxImage.Big)
                            ToShow = Image.FromHbitmap(ImageManager.APPLY_BIG_PRESSED_IMAGE_PTR);
                        else
                            ToShow = Image.FromHbitmap(ImageManager.APPLY_SMALL_PRESSED_IMAGE_PTR);
                    else
                        if (pImageType == eCkBoxImage.Big)
                            ToShow = Image.FromHbitmap(ImageManager.RETURN_BIG_PRESSED_IMAGE_PTR);
                        else
                            ToShow = Image.FromHbitmap(ImageManager.RETURN_SMALL_PRESSED_IMAGE_PTR);
                else
                    ToShow = Image.FromHbitmap(ImageManager.ERROR_SMALL_IMAGE_PTR);

            Rectangle rSource = new Rectangle(0, 0, ToShow.Width, ToShow.Height);
            Rectangle rDest = new Rectangle((this.Width - rSource.Width) / 2, (this.Height - rSource.Height) / 2, rSource.Width, rSource.Height);
          
            Gr.DrawImage((Image)ToShow, rDest, rSource, GraphicsUnit.Pixel); 

            Pen MyPen = new Pen(Color.Gainsboro, 2F);
            Rectangle rTxtBorder = new Rectangle
                                        (
                                        0,
                                        0,
                                        this.Width - 2,
                                        this.Height - 2
                                        );

            Gr.DrawRectangle(MyPen, rTxtBorder);

            MyPen = new Pen(Color.Gray, 1F);

            Rectangle tIntBorder = new Rectangle
                                        (
                                        1,
                                        1,
                                        rTxtBorder.Width - 1,
                                        rTxtBorder.Height - 1
                                        );

            Gr.DrawRectangle(MyPen, tIntBorder);

            MyPen.Dispose();
            e.Graphics.DrawImage(BufferBmp, 0, 0);

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        { 
            //base.OnPaintBackground(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if (!pClickEnable)
                return;

            _Checked = !_Checked;

            BufferBmp = null;
            Refresh();

            if (CheckStateChanged != null)
                CheckStateChanged.Invoke((object)this, e);
        }
    }
}
