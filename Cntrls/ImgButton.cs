using System; 
using System.Drawing; 
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using Utility;

namespace Cntrls
{
    public partial class ImgButton : UserControl
    {
        #region Property 
        private Bitmap _img;
        private Bitmap _onClickImg;
        private Bitmap _currentImg; 
         
        private Color _backGroundColor = Color.Black;
        private Color _backColorOnMuoseDown;
        public Color BackColorOnMouseDown
        {
            get { return _backColorOnMuoseDown; }
            set { _backColorOnMuoseDown = value; }
        }

        public Bitmap BtnImg
        {
            get { return _img; }
            set
            {
                _img = value; 
                _currentImg = _img;
            }
        } 

        public Bitmap OnMouseClickImg
        {
            get { return _onClickImg; }
            set { _onClickImg = value; }
        }

        /// <summary>
        /// Colore dello sfondo del pulsante.
        /// </summary>
        public Color BtnColor
        {
            get { return _backGroundColor; }
            set
            {
                _backGroundColor = value;
                base.BackColor = value;
            }
        }

        private Color _borderColor = Color.Black; 
        private Color _internalBorderColor = Color.Black;

        /// <summary>
        /// Colore del bordo del pulsante.
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        public Color InternalBorderColor
        {
            get { return _internalBorderColor; }
            set { _internalBorderColor = value; }
        }

        private int _borderSize = 2;
        /// <summary>
        /// Spessore del bordo
        /// </summary>
        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                _borderSize = value;
            }
        }

        private bool _drawImage = true;
        public new bool Enabled
        {
            get { return base.Enabled; }
            set 
            {
                _drawImage = value;
                Refresh();
                base.Enabled = value;
            }
        }

        #endregion

        public ImgButton()
        {
            InitializeComponent();  
        }
           
        #region Overrides 

        private Bitmap _doubleBuffer; //Doppio buffer grafico

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_doubleBuffer == null)
                _doubleBuffer = Utils.CreateBitmap(Width, Height, 32); // new Bitmap(Width, Heights

            Graphics gr = Graphics.FromImage(_doubleBuffer);
            gr.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            Pen myPen = new Pen(_borderColor, _borderSize);

            Rectangle rExtBorder = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            rExtBorder.Width -= (int)_borderSize;
            rExtBorder.Height -= (int)_borderSize;

            gr.DrawRectangle(myPen, rExtBorder);

            myPen = new Pen(_internalBorderColor, 1F);

            Rectangle rIntBorder = rExtBorder;

            rIntBorder.Location = new Point(_borderSize, _borderSize);
            rIntBorder.Width -= (_borderSize + 1);
            rIntBorder.Height -= (_borderSize + 1);

            gr.DrawRectangle(myPen, rIntBorder); 

            Utils.IImagingFactory factory = (Utils.IImagingFactory)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("327ABDA8-072B-11D3-9D7B-0000F81EF32E")));
            // Load the image with alpha data from an embedded resource through Imaging
            // !! If your data source is not a MemoryStream, you will need to get your image data into a byte array and use it below. !!
            MemoryStream strm = (MemoryStream)Assembly.GetExecutingAssembly().GetManifestResourceStream("Cntrls.Graphics.5_content_edit.png");
            byte[] pbBuf = strm.GetBuffer();
            uint cbBuf = (uint)strm.Length;
            Utils.IImage imagingResource;
            Utils.ImageInfo imgInfo;
            factory.CreateImageFromBuffer(pbBuf, cbBuf, Utils.BufferDisposalFlag.BufferDisposalFlagNone, out imagingResource); 
            imagingResource.GetImageInfo(out imgInfo);
  
            Rectangle rDest = new Rectangle((Width - (int)imgInfo.Width) / 2, (Height - (int)imgInfo.Height) / 2, (int)imgInfo.Width, (int)imgInfo.Height);
            Rectangle rSource = new Rectangle(0, 0, (int)imgInfo.Width, (int)imgInfo.Height);
 
            IntPtr hdcDest = gr.GetHdc();
            imagingResource.Draw(hdcDest, ref rDest, ref rSource);
            gr.ReleaseHdc(hdcDest); 

            myPen.Dispose();

            e.Graphics.DrawImage(_doubleBuffer, 0, 0);
        }
         
        private static Rectangle _rSource = Rectangle.Empty;

        protected override void OnPaintBackground(PaintEventArgs e)
        { }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!base.Enabled)
            {
                Refresh();
                return;
            }

            base.BackColor = _backColorOnMuoseDown;
            if (_onClickImg != null)
                _currentImg = _onClickImg;

            _doubleBuffer = null;
            Refresh();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.BackColor = _backGroundColor;
            if (_onClickImg != null)
                _currentImg = _img; 

            if (!base.Enabled)
            {
                Refresh();
                return;
            }

            base.OnMouseUp(e);
            _doubleBuffer = null;
            Refresh(); 

            base.OnClick(e); 
        }

        protected override void OnClick(EventArgs e)
        { }

        #endregion 
    }
}
