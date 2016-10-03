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
    public partial class TabPorterCntrl : BaseCntrls.DoubleBufferedControl
    {
        public event EventHandler SelectedCellChanged;

        private Bitmap backGroundBitmap;
        private Bitmap verLineBitmap;
        private Bitmap orzLineBitmap;

        private int topMargin = 3;
        private int leftMargin = 3;
        private int bottomTableMargin = 0;

        private TableCell selectedCell = TableCell.Empty;

        private RectangleF[] columnTextRectangles;
        private RectangleF[] rowTextRectangles;

        private int y_distance = 0;
        private int x_distance = 0; 

        private string[] showedRowTexts;
        private int currentPage = 0;
        private int pageCount = 0;
        private int showedRowCount = 0;

        private string[,] showedValues;
        private string[,] values;
        private string[,] deviceValues;

        private PageColumnsText columnsText;
        private string[] rowsText;

        private int[] verticalLinesPosition;
        private int[] orizontalLinesPosition;

        private string backGroundResource;
        public string BackGroundResource
        {
            get { return backGroundResource; }
            set { backGroundResource = value; loadBitmaps(); }
        }

        private string verLineResource;
        public string VerLineResource
        {
            get { return verLineResource; }
            set { verLineResource = value; loadBitmaps(); }
        }

        private string orzLineResource;
        public string OrzLineResource
        {
            get { return orzLineResource; }
            set { orzLineResource = value; loadBitmaps(); }
        }

        private int columnCount = 5;
        public int ColumnCount
        {
            get { return columnCount - 1; }
            set
            {
                if (value < 0) return;

                columnCount = value + 1;
                refreshLayouts();
                Invalidate();
            }
        }

        private int rowCount = 11;
        public int RowCount
        {
            get { return rowCount - 2; }
            set
            {
                if (value < 0) return;

                showedRowCount = value;
                rowCount = value + 2;
                showedRowTexts = new string[showedRowCount]; 
                refreshLayouts();
                Invalidate();
            }
        }

        private Font columnTitleFont = new Font("Arial", 10.0f, FontStyle.Regular);
        public Font ColumnTitleFont
        {
            get { return columnTitleFont; }
            set
            {
                columnTitleFont = value;
                Invalidate();
            }
        }

        private Font rowTitleFont = new Font("Arial", 10.0f, FontStyle.Regular);
        public Font RowTitleFont
        {
            get { return rowTitleFont; }
            set
            {
                rowTitleFont = value;
                Invalidate();
            }
        } 

        public TableCell SelectedAbsoluteCell
        {
            get { return new TableCell(selectedCell.X - 1, selectedCell.Y + (currentPage * showedRowCount) - 1); }
        }

        public TableCell SelectedRelativeCell
        {
            get { return new TableCell(selectedCell.X - 1, selectedCell.Y - 1); }
        }

        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        } 

        public TabPorterCntrl()
        {
            InitializeComponent();
        }

        #region Privates

        private void loadBitmaps()
        {
            backGroundBitmap = (Bitmap)Resources.Resources.GetResource(backGroundResource, ResourceType.Image);
            verLineBitmap = (Bitmap)Resources.Resources.GetResource(verLineResource, ResourceType.Image);
            orzLineBitmap = (Bitmap)Resources.Resources.GetResource(orzLineResource, ResourceType.Image);

            Invalidate();
        }

        private void refreshShowedRows()
        { 
            int rowOffset = showedRowCount * currentPage;

            showedRowTexts = new string[showedRowCount];
            showedValues = new string[showedRowCount, columnCount - 1];

            for (int i = 0; i < showedRowCount; i++)
                showedRowTexts[i] = rowsText.Length > (rowOffset + i) ? rowsText[rowOffset + i] : string.Empty; 

            for (int col = 0; col < columnCount - 1; col++)
                for (int row = 0; row < showedRowCount; row++) 
                    showedValues[row, col] = rowsText.Length > (rowOffset + row) ? values[row + rowOffset, col] : string.Empty;

            lblPage.TextLabel = (currentPage + 1).ToString() + "/" + pageCount.ToString();
            Invalidate();
        }

        private void onNextRequested(object sender, EventArgs e)
        {
            if (currentPage + 1 >= pageCount)
                return;

            currentPage++;
            ResetSelected();
            refreshShowedRows();
        }

        private void onPrevRequested(object sender, EventArgs e)
        {
            if (currentPage <=0)
                return;

            currentPage--;
            ResetSelected();
            refreshShowedRows();
        }

        private void refreshSelectedRectangle(Point point)
        {
            int x_position = leftMargin;
            int y_position = topMargin;

            int x_index = 0;
            int y_index = 0;

            if (point.X < leftMargin)
            {
                selectedCell = TableCell.Empty;
                Invalidate();
                return;
            }

            if (point.Y < topMargin)
            {
                selectedCell = TableCell.Empty;
                Invalidate();
                return;
            }

            if (point.Y > bottomTableMargin)
            {
                selectedCell = TableCell.Empty;
                Invalidate();
                return;
            }

            for (x_position = leftMargin; x_position < point.X; x_position += x_distance, x_index++) ; x_position -= x_distance; x_index--;
            for (y_position = topMargin; y_position < point.Y; y_position += y_distance, y_index++) ; y_position -= y_distance; y_index--;

            if (x_index == 0 | y_index == 0)
            {
                selectedCell = TableCell.Empty;
                Invalidate();
                return;
            }

            selectedCell = new TableCell(x_index, y_index, new Rectangle(x_position, y_position, x_distance, y_distance));

            if (string.IsNullOrEmpty(values[selectedCell.Y - 1 + (currentPage * showedRowCount), selectedCell.X - 1]))
                selectedCell = TableCell.Empty;

            Invalidate();

            if (SelectedCellChanged != null)
                SelectedCellChanged.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Pubblics

        public void SetColumnsText(PageColumnsText colTexts)
        { 
            columnsText = colTexts;
        }

        public void SetRowsText(string[] rowTexts)
        {
            if (rowTexts == null)
                return; 

            rowsText = rowTexts;
            showedRowTexts = new string[showedRowCount]; 

            if (rowsText.Length > showedRowCount) 
                pageCount = (rowsText.Length / showedRowCount); 
            else  
                pageCount = 1;

            currentPage = 0;
            lblPage.TextLabel = (currentPage + 1).ToString() + "/" + pageCount.ToString();
        }

        public void SetValues(string[,] val)
        {
            values = val;  
            refreshShowedRows();
        }

        public void SetDeviceValues(string[,] val)
        {
            deviceValues = val;
            refreshShowedRows();
        }

        public void ResetSelected()
        {
            selectedCell = TableCell.Empty;
            Invalidate();
        }

        public void SetValue(TableCell cell, string value)
        {
            values[cell.Y, cell.X] = value;
            refreshShowedRows(); 
        }

        #endregion

        #region Layout

        protected override void OnResize(EventArgs e)
        { 
            refreshLayouts();
            base.OnResize(e);
        }

        private void refreshLayouts()
        {
            verticalLinesPosition = new int[columnCount - 1];
            orizontalLinesPosition = new int[rowCount - 1];
            columnTextRectangles = new RectangleF[columnCount - 1];
            rowTextRectangles = new RectangleF[rowCount - 1]; 

            y_distance = (Height - (topMargin * 2)) / rowCount;
            x_distance = (Width - (leftMargin * 2)) / columnCount;

            int y_position = topMargin;
            int x_position = leftMargin;

            for (int i = 0; i < columnCount - 1; i++)
            {
                verticalLinesPosition[i] = (x_position += x_distance);
                columnTextRectangles[i] = new RectangleF(x_position, topMargin, x_distance, y_distance);
            }

            for (int i = 0; i < rowCount - 1; i++)
            {
                orizontalLinesPosition[i] = (y_position += y_distance);
                rowTextRectangles[i] = new RectangleF(leftMargin, y_position, x_distance, y_distance);
            }

            bottomTableMargin = Height - topMargin - y_distance;
            //Invalidate();

            if (lblPage != null)
            {
                lblPage.Location = new Point(lblPage.Left, bottomTableMargin + 1);
                lblPage.Height = y_distance - 4;
            }
        } 

        #endregion

        #region Rendering

        protected override void OnPaint(PaintEventArgs e)
        {
            using (doubleBuffer = new Bitmap(Width, Height))
            using (Graphics gr = Graphics.FromImage(doubleBuffer))
            {
                gr.Clear(BackColor);

                gr.DrawImage(backGroundBitmap, 0, 0);

                drawVerticalLines(gr);
                drawOrizontalLined(gr);

                using (Brush textBrush = new SolidBrush(ForeColor))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    drawColumnsText(gr, textBrush, sf);
                    drawRowsText(gr, textBrush, sf);
                    drawValues(gr, textBrush, sf);
                    drawSelectedCell(gr, textBrush, sf);
                }

                e.Graphics.DrawImage(doubleBuffer, 0, 0);
            } 
        }

        private void drawVerticalLines(Graphics gr)
        {
            if (verLineBitmap == null) return;

            for (int i = 0; i < verticalLinesPosition.Length; i++)
                gr.DrawImage(verLineBitmap, verticalLinesPosition[i], topMargin);  
        }

        private void drawOrizontalLined(Graphics gr)
        {
            if (orzLineBitmap == null) return;

            for (int i = 0; i < orizontalLinesPosition.Length; i++)
                gr.DrawImage(orzLineBitmap, leftMargin, orizontalLinesPosition[i]);  
        }

        private void drawColumnsText(Graphics gr, Brush textBrush, StringFormat sf)
        {
            if (columnsText == null)
                return;

            ColumnsText currentColumnsText;

            if (currentPage >= columnsText.Count)
                currentColumnsText = columnsText[0];
            else
                currentColumnsText = columnsText[currentPage];

            if (currentColumnsText.Count < columnCount - 1)
                return;

            using (Brush selectedColBrush = new SolidBrush(Color.FromArgb((Color.White.R + Color.LightBlue.R) / 2, (Color.White.G + Color.LightBlue.G) / 2, (Color.White.B + Color.LightBlue.B) / 2)))
                for (int i = 0; i < columnCount - 1; i++)
                {
                    if (!selectedCell.Equals(TableCell.Empty) & selectedCell.X == (i + 1))
                    {
                        Rectangle selectedColRect = new Rectangle((int)columnTextRectangles[i].X + leftMargin, (int)columnTextRectangles[i].Y + orzLineBitmap.Height, x_distance - verLineBitmap.Width - leftMargin, y_distance - orzLineBitmap.Height);
                            gr.FillRectangle(selectedColBrush, selectedColRect); 
                    }

                    gr.DrawString(currentColumnsText[i], columnTitleFont, textBrush, columnTextRectangles[i], sf);
                } 
        }

        private void drawRowsText(Graphics gr, Brush textBrush, StringFormat sf)
        {
            if (showedRowTexts == null)
                return;

            using (Brush selectedRowBrush = new SolidBrush(Color.FromArgb((Color.White.R + Color.LightBlue.R) / 2, (Color.White.G + Color.LightBlue.G) / 2, (Color.White.B + Color.LightBlue.B) / 2))) 
                for (int i = 0; i < showedRowTexts.Length; i++)
                {
                    if (!selectedCell.Equals(TableCell.Empty) & selectedCell.Y == (i + 1))
                    {
                        Rectangle selectedRowRect = new Rectangle((int)rowTextRectangles[i].X + leftMargin, (int)rowTextRectangles[i].Y + orzLineBitmap.Height, x_distance - verLineBitmap.Width - leftMargin, y_distance - orzLineBitmap.Height);
                        gr.FillRectangle(selectedRowBrush, selectedRowRect);
                    }
                    
                    gr.DrawString(showedRowTexts[i], rowTitleFont, textBrush, rowTextRectangles[i], sf);
                } 
        }

        private void drawValues(Graphics gr, Brush textBrush, StringFormat sf)
        {
            if (showedValues == null)
                return; 

            float y_position = topMargin + y_distance;
            float x_position = leftMargin + x_distance;

            for (int col = 0; col < columnCount - 1; col++)
            {
                for (int row = 0; row < showedRowCount; row++)
                {
                    RectangleF textRect = new RectangleF(x_position, y_position, x_distance, y_distance);
                    y_position += y_distance;

                    gr.DrawString(showedValues[row, col], Font, textBrush, textRect, sf);

                    if (deviceValues != null)
                        if (string.Compare(values[row + (currentPage * showedRowCount), col], deviceValues[row + (currentPage * showedRowCount), col]) != 0)
                            using (Pen diffPen1 = new Pen(Color.SteelBlue))
                            using (Pen diffPen2 = new Pen(Color.LightBlue))
                            {
                                Rectangle diffRect = new Rectangle((int)textRect.X + 2, (int)textRect.Y + 2, (int)textRect.Width - 4, (int)textRect.Height - 4);
                                gr.DrawRectangle(diffPen1, diffRect);
                                diffRect = new Rectangle((int)textRect.X + 3, (int)textRect.Y + 3, (int)textRect.Width - 6, (int)textRect.Height - 6);
                                gr.DrawRectangle(diffPen2, diffRect);
                            }
                }

                x_position += x_distance;
                y_position = topMargin + y_distance;
            }
        }

        private void drawSelectedCell(Graphics gr, Brush textBrush, StringFormat sf)
        {
            if (selectedCell.Equals(TableCell.Empty))
                return; 

            using (Pen selectedCellBorder = new Pen(Color.Black))
            using (Brush selectedCellBackGroung = new SolidBrush(Color.LightBlue))
            using (Font selectedTextFont = new Font(Font.Name, Font.Size + 6f, Font.Style))
            {
                int selectedCellWidth = x_distance * 2;
                int selectedCellLocationX = selectedCell.CellRectangle.X - (selectedCellWidth / 4);

                if (x_distance * 2 >= (Width / 2))
                    selectedCellWidth = x_distance;

                if (columnCount == 2)
                    selectedCellLocationX = selectedCell.CellRectangle.X;

                Rectangle rectToDraw = new Rectangle(selectedCellLocationX, selectedCell.CellRectangle.Y - (y_distance / 2), selectedCellWidth, y_distance * 2);

                rectToDraw.X = (rectToDraw.Right > Width) ? rectToDraw.X - (rectToDraw.Right - Width) : rectToDraw.X;
                rectToDraw.Y = (rectToDraw.Bottom > bottomTableMargin) ? rectToDraw.Y - (rectToDraw.Bottom - bottomTableMargin) : rectToDraw.Y;

                gr.FillRectangle(selectedCellBackGroung, rectToDraw);
                gr.DrawRectangle(selectedCellBorder, rectToDraw);

                if (deviceValues != null)
                {
                    rectToDraw.Height /= 3;
                    rectToDraw.Height *= 2;
                }
                 
                gr.DrawString(values[selectedCell.Y - 1 + (currentPage * showedRowCount), selectedCell.X - 1], selectedTextFont, textBrush, rectToDraw, sf);

                if (deviceValues != null)
                {
                    rectToDraw.Y += rectToDraw.Height;
                    rectToDraw.Height /= 3;

                    using (Font deviceTextFont = new Font(Font.Name, Font.Size, Font.Style))
                        gr.DrawString(deviceValues[selectedCell.Y - 1 + (currentPage * showedRowCount), selectedCell.X - 1], deviceTextFont, textBrush, rectToDraw, sf);
                }
            }
        }

        #endregion

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            refreshSelectedRectangle(new Point(e.X, e.Y)); 
        }

        private void lblPage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblPage.Height.ToString());
        }
    }

    public class PageColumnsText : List<ColumnsText>
    { }

    public class ColumnsText : List<string>
    { }

    public class TableCell
    {
        public static readonly TableCell Empty = new TableCell(-1, -1, Rectangle.Empty);

        private int x;
        public int X
        {
            get { return x; }
        }

        private int y;
        public int Y
        {
            get { return y; }
        }

        private Rectangle cellRectangle = Rectangle.Empty;
        internal Rectangle CellRectangle
        {
            get { return cellRectangle; }
        }

        internal TableCell(int coordX, int coordY, Rectangle cellRect)
        {
            x = coordX;
            y = coordY;
            cellRectangle = cellRect;
        } 

        public TableCell(int coordX, int coordY)
        {
            x = coordX;
            y = coordY;
        } 
    }
}
