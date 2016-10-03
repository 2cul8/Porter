using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Resources;

namespace Cntrls.BaseCntrls
{
    public partial class BitmapButton : BlinkControl
    {
        private bool fromResource = false;
        public bool FromResource
        {
            get { return fromResource; }
            set { fromResource = value; }
        }

        private string resourceNameBase = string.Empty;
        public string ResourceNameBase
        {
            get { return resourceNameBase; }
            set 
            {
                if (string.Compare(value, resourceNameBase) == 0)
                    return;

                resourceNameBase = value; 
                LoadBitamps();
                Invalidate(); 
            }
        }

        protected Bitmap bmpButtonNormal;
        protected Bitmap bmpButtonPressed;
        protected Bitmap bmpButtonBlinked;
        protected Bitmap bmpButtonSelected;
        protected Bitmap bmpButtonDisabled;

        private const string BUTTON_PRESSED_ID = "_pressed";
        private const string BUTTON_BLINKED_ID = "_blinked";
        private const string BUTTON_SELECTED_ID = "_selected";
        private const string BUTTON_DISABLED_ID = "_disabled";

        private const string NO_IMAGE_BMP = "no_image.bmp";

        public BitmapButton()
        {
            InitializeComponent(); 
        }

        private void LoadBitamps()
        { 
            bmpButtonNormal = (Bitmap)Resources.Resources.GetResource(resourceNameBase + ".bmp", ResourceType.Image); 
            bmpButtonPressed = (Bitmap)Resources.Resources.GetResource(resourceNameBase + BUTTON_PRESSED_ID + ".bmp", ResourceType.Image);
            bmpButtonBlinked = (Bitmap)Resources.Resources.GetResource(resourceNameBase + BUTTON_BLINKED_ID + ".bmp", ResourceType.Image);
            bmpButtonSelected = (Bitmap)Resources.Resources.GetResource(resourceNameBase + BUTTON_SELECTED_ID + ".bmp", ResourceType.Image);
            bmpButtonDisabled = (Bitmap)Resources.Resources.GetResource(resourceNameBase + BUTTON_DISABLED_ID + ".bmp", ResourceType.Image);

            if (bmpButtonNormal == null) 
                bmpButtonNormal = (Bitmap)Resources.Resources.GetResource(NO_IMAGE_BMP, ResourceType.Image); 

            if (bmpButtonPressed == null)
                bmpButtonPressed = (Bitmap)Resources.Resources.GetResource(NO_IMAGE_BMP, ResourceType.Image);

            if (bmpButtonBlinked == null)
                bmpButtonBlinked = (Bitmap)Resources.Resources.GetResource(NO_IMAGE_BMP, ResourceType.Image);

            if (bmpButtonSelected == null)
                bmpButtonSelected = (Bitmap)Resources.Resources.GetResource(NO_IMAGE_BMP, ResourceType.Image);

            if (bmpButtonDisabled == null)
                bmpButtonDisabled = (Bitmap)Resources.Resources.GetResource(NO_IMAGE_BMP, ResourceType.Image);
        } 
    }
}
