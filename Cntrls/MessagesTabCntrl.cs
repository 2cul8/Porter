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
    public partial class MessagesTabCntrl : Cntrls.BaseCntrls.DoubleBufferedControl
    {
        public event EventHandler SelectedItemChanged;

        private static Bitmap selectedActiveItemBitmap;
        private static Bitmap activeItemBitmap;
        private static Bitmap selectedItemBitmap;
        private static Bitmap itemBitmap;

        private const int ITEM_PER_LINE = 8;
        private const int LINE_COUNT = 4;

        private const int ITEM_WIDTH = 54;
        private const int ITEM_HEIGHT = 54;

        private Point selectedItem;
        private Rectangle[,] matrix;
        private bool[] flagStatus;

        public int SelectedItem
        {
            get { return (selectedItem.Y * ITEM_PER_LINE) + selectedItem.X; }
        }

        public MessagesTabCntrl()
        {
            InitializeComponent();

            flagStatus = new bool[ITEM_PER_LINE * LINE_COUNT];

            selectedItem = Point.Empty;
            selectedActiveItemBitmap = (Bitmap)Resources.Resources.GetResource("messageFlagOn_selected.bmp", Resources.ResourceType.Image);
            activeItemBitmap = (Bitmap)Resources.Resources.GetResource("messageFlagOn.bmp", Resources.ResourceType.Image);
            selectedItemBitmap = (Bitmap)Resources.Resources.GetResource("messageFlagOff_selected.bmp", Resources.ResourceType.Image);
            itemBitmap = (Bitmap)Resources.Resources.GetResource("messageFlagOff.bmp", Resources.ResourceType.Image);
        }

        public void SetFlagsStatus(bool[] flags)
        {
            if (flags == null)
                return;

            bool needRefresh = false;

            for (int i = 0; i < flagStatus.Length; i++)
                if (i < flags.Length)
                {
                    if (flagStatus[i] ^ flags[i])
                        needRefresh = true;

                    flagStatus[i] = flags[i];
                }

            if (needRefresh)
                Invalidate();
        }

        private void setLayout()
        {
            matrix = new Rectangle[LINE_COUNT, ITEM_PER_LINE];

            int matrix_x_offset = (Width - ((ITEM_WIDTH + 6) * ITEM_PER_LINE)) / 2;  
            int matrix_y_offset = (Height - ((ITEM_HEIGHT + 6) * LINE_COUNT)) / 2; 

            for (int line = 0, y = matrix_y_offset; line < LINE_COUNT; line++, y += (ITEM_HEIGHT + 6))
                for (int column = 0, x = matrix_x_offset; column < ITEM_PER_LINE; column++, x += (ITEM_WIDTH + 6)) 
                    matrix[line, column] = new Rectangle(x, y, ITEM_WIDTH, ITEM_HEIGHT); 
        }

        protected override void OnResize(EventArgs e)
        {
            setLayout();
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //base.OnMouseDown(e);
        }

        protected override void OnClick(EventArgs e)
        {
            //base.OnClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            for (int line = 0; line < LINE_COUNT; line++)
                for (int column = 0; column < ITEM_PER_LINE; column++)
                    if (matrix[line, column].Contains(new Point(e.X, e.Y)))
                        if (selectedItem.X != column | selectedItem.Y != line)
                        {
                            selectedItem = new Point(column, line);

                            if (SelectedItemChanged != null)
                                SelectedItemChanged.Invoke(this, EventArgs.Empty);

                            Refresh(); 
                        } 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (doubleBuffer = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
            using (StringFormat sf = new StringFormat())
            using (Brush textBrush = new SolidBrush(ForeColor))
            { 
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                gr.Clear(BackColor);

                int i = 1;
                for (int line = 0; line < LINE_COUNT; line++)
                    for (int column = 0; column < ITEM_PER_LINE; column++, i++)
                    {
                        if (line == selectedItem.Y & column == selectedItem.X)
                            gr.DrawImage(flagStatus[i - 1] ? selectedActiveItemBitmap : selectedItemBitmap, matrix[line, column].X, matrix[line, column].Y);
                        else
                            gr.DrawImage(flagStatus[i - 1] ? activeItemBitmap : itemBitmap, matrix[line, column].X, matrix[line, column].Y);

                        gr.DrawString(i.ToString(), Font, textBrush, matrix[line, column], sf);
                    }

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            } 
        }
    }
}
