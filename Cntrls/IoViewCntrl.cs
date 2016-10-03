using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cntrls
{
    public partial class IoViewCntrl : UserControl
    {
        private static readonly Size IO_DEFAULT_SIZE = new Size(32, 32);

        public event IoSelectedEventHandler IoSelectedChanged;
        public event IoSelectedEventHandler ActionOnOutput;

        public enum IoStatus
        {
            None = 0,
            On= 1,
            Off = 2
        }

        private Size _IoSize = IO_DEFAULT_SIZE;
        public Size IoSize
        {
            get { return _IoSize; }
            set
            {
                //_IoSize = value;
                Invalidate();
            }
        } 

        private IOGraphic[] _allInput;
        private IOGraphic[] _allOutput;
        private int _columnCount;
        private int _rowCount;
        private StringFormat _sf;
        private SolidBrush _textBrush;
        private int _xAllInput;
        private int _xAllOutput;

        private int _inputMatrixWidth;
        private int _inputMatrixHeight;
        private int _outputMatrixWidth;
        private int _outputMatrixHeight;

        private IOGraphic _selected;

        private Point _selectedCoordinate;

        private bool _indiciIncrementali;
        public bool IndiciIncrementali
        {
            get { return _indiciIncrementali; }
            set { _indiciIncrementali = value; Invalidate(); }
        }

        private string _grid1Text;
        public string TestoGriglia1
        {
            get { return _grid1Text; }
            set { _grid1Text = value; Invalidate(); }
        } 

        private string _grid2Text;
        public string TestoGriglia2
        {
            get { return _grid2Text; }
            set { _grid2Text = value; Invalidate(); }
        }

        public IoViewCntrl()
        {
            InitializeComponent();

            _sf = new StringFormat();
            _sf.Alignment = StringAlignment.Center;
            _sf.LineAlignment = StringAlignment.Center;

            _textBrush = new SolidBrush(Color.FromArgb(164, 164, 164));

            Font = new Font("Arial", 12.0F, FontStyle.Regular);

            SetIoCount(64, 8);
        }

        public void SetIoCount(int ioCount, int columnCount)
        {
            _allInput = new IOGraphic[ioCount];
            _allOutput = new IOGraphic[ioCount];

            _columnCount = columnCount;
            _rowCount = (ioCount / columnCount);

            for (int index = 0; index < columnCount; index++)
            {
                _inputMatrixWidth += _IoSize.Width;
                _outputMatrixWidth += _IoSize.Width;
            }

            for (int index = 0; index < _rowCount; index++)
            {
                _inputMatrixHeight += _IoSize.Height;
                _outputMatrixHeight += _IoSize.Height;
            }

            _xAllInput = (Width - (_inputMatrixWidth + 60 + _outputMatrixWidth)) / 2;
            _xAllOutput = _xAllInput + 60 + _inputMatrixWidth;

            for (int r_index = 0; r_index < _rowCount; r_index++)
                for (int c_index = 0; c_index < _columnCount; c_index++)
                {
                    _allInput[c_index + (r_index * _columnCount)] = new IOGraphic
                                                (
                                                true,
                                                c_index + (r_index * _columnCount) + 1,
                                                new Point(c_index * _IoSize.Width, r_index * _IoSize.Height),
                                                _IoSize,
                                                Color.DarkOrange,
                                                IoStatus.Off,
                                                new Point(c_index, r_index)
                                                ).SetXOffset(_xAllInput, 20);


                    _allOutput[c_index + (r_index * _columnCount)] = new IOGraphic
                                                (
                                                false,
                                                c_index + (r_index * _columnCount) + 1,
                                                new Point(c_index * _IoSize.Width, r_index * _IoSize.Height),
                                                _IoSize,
                                                Color.DarkOrange,
                                                IoStatus.Off,
                                                new Point(_columnCount + c_index, r_index)
                                                ).SetXOffset(_xAllOutput, 20);
                }  

            SelectIo(_allInput[0]);

            RefreshBackground();
        }

        public void SetIOValues(byte[] inputs, byte[] outputs)
        {
            if (inputs == null) 
                throw new Exception("Numero di inputs non valido!!");

            if (outputs == null)
                throw new Exception("Numero di outputs non valido!!");

            if (_allInput.Length != inputs.Length)
                return;

            bool changed = false;

            for (int index = 0; index < _allInput.Length; index++)
            {
                IoStatus newValue = (inputs[index] > 0) ? IoStatus.On : IoStatus.Off;

                if (newValue != _allInput[index].Status)
                    changed = true;

                _allInput[index].Status = newValue;
            }

            for (int index = 0; index < _allOutput.Length; index++)
            {
                IoStatus newValue = (outputs[index] > 0) ? IoStatus.On : IoStatus.Off;

                if (newValue != _allOutput[index].Status)
                    changed = true;

                _allOutput[index].Status = newValue;
            } 

            if (changed)
                Refresh();
        }

        public void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    SelectLeft();
                    break;

                case Keys.Right:
                    SelectRight();
                    break;

                case Keys.Up:
                    SelectUp();
                    break;

                case Keys.Down:
                    SelectDown();
                    break;

                case Keys.Enter:

                    if (_selected == null)
                        return; 

                    if (ActionOnOutput != null)
                        ActionOnOutput.Invoke(this, new IoSelectedEventArgs(_selected.IsInput, _selected.IoNumber - 1, _selected.IsInput ? 0 : 64));

                    break;
            }
        }

        private void SelectLeft()
        { 
            if (_selectedCoordinate.X == 0)
                if (_selectedCoordinate.Y == 0) 
                    _selectedCoordinate = new Point((_columnCount * 2) - 1, _rowCount - 1);
                else
                    _selectedCoordinate = new Point((_columnCount * 2) - 1, _selectedCoordinate.Y - 1);
            else
                _selectedCoordinate = new Point(_selectedCoordinate.X - 1, _selectedCoordinate.Y);

            if (_selectedCoordinate.X >= _columnCount)
                SelectIo(_allOutput[(_selectedCoordinate.Y * (_columnCount)) + (_selectedCoordinate.X - _columnCount)]);
            else
                SelectIo(_allInput[(_selectedCoordinate.Y * _columnCount) + (_selectedCoordinate.X)]);
        }

        private void SelectRight()
        { 
            if (_selectedCoordinate.X == (_columnCount * 2) - 1)
                if (_selectedCoordinate.Y == (_rowCount - 1))
                    _selectedCoordinate = new Point(0, 0);
                else
                    _selectedCoordinate = new Point(0, _selectedCoordinate.Y + 1);
            else
                _selectedCoordinate = new Point(_selectedCoordinate.X + 1, _selectedCoordinate.Y);

            if (_selectedCoordinate.X >= _columnCount)
                SelectIo(_allOutput[(_selectedCoordinate.Y * _columnCount) + (_selectedCoordinate.X - _columnCount)]);
            else
                SelectIo(_allInput[(_selectedCoordinate.Y * _columnCount) + (_selectedCoordinate.X)]);
        }

        private void SelectUp()
        {   
            if (_selectedCoordinate.Y == 0)
                _selectedCoordinate = new Point(_selectedCoordinate.X, _rowCount - 1);
            else 
                _selectedCoordinate = new Point(_selectedCoordinate.X, _selectedCoordinate.Y - 1);

            if (_selectedCoordinate.X >= _columnCount)
                SelectIo(_allOutput[(_selectedCoordinate.Y * _columnCount) + (_selectedCoordinate.X - _columnCount)]);
            else
                SelectIo(_allInput[(_selectedCoordinate.Y * _columnCount) + (_selectedCoordinate.X)]);
        }

        private void SelectDown()
        {  
            if (_selectedCoordinate.Y == _rowCount - 1)
                _selectedCoordinate = new Point(_selectedCoordinate.X, 0);
            else
                _selectedCoordinate = new Point(_selectedCoordinate.X, _selectedCoordinate.Y + 1);

            if (_selectedCoordinate.X >= _columnCount)
                SelectIo(_allOutput[(_selectedCoordinate.Y * _columnCount) + (_selectedCoordinate.X - _columnCount)]);
            else
                SelectIo(_allInput[(_selectedCoordinate.Y * _columnCount) + (_selectedCoordinate.X)]); 
        }

        private void SelectIo(IOGraphic toSelect)
        {
            foreach (IOGraphic input in _allInput)
                input.IsSelected = false;

            foreach(IOGraphic output in _allOutput)
                output.IsSelected = false;

            _selected = toSelect;
            toSelect.IsSelected = true;
            _selectedCoordinate = toSelect.IoCoordinate;
            Refresh();

            if (IoSelectedChanged != null)
                IoSelectedChanged.Invoke(this, new IoSelectedEventArgs(toSelect.IsInput, toSelect.IoNumber - 1, toSelect.IsInput ? 0 : 64));
        }

        public void SelectZero()
        {
            SelectIo(_allInput[0]);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        { }

        public void RefreshGraphics()
        {
            RefreshBackground();
        }

        private void RefreshBackground()
        {
            _bmpDoubleBuffer = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(_bmpDoubleBuffer);

            Rectangle rAllInput = new Rectangle(_xAllInput, 20, _inputMatrixWidth, _inputMatrixHeight);
            Rectangle rAllOutput = new Rectangle(_xAllOutput, 20, _outputMatrixWidth, _outputMatrixWidth);

            Pen matrixPen = new Pen(Color.FromArgb(64, 64, 64));

            gr.DrawRectangle(matrixPen, rAllInput);
            gr.DrawRectangle(matrixPen, rAllOutput); 

            Font textFont = new Font("Arial", 14.0F, FontStyle.Regular);
            SizeF textSize = gr.MeasureString(_grid1Text, textFont);
            textSize.Height += 3;

            RectangleF textRect = new RectangleF(_xAllInput + (rAllInput.Width / 2) - (textSize.Width / 2), rAllInput.Bottom + 3, textSize.Width, textSize.Height);
            gr.DrawString(_grid1Text, textFont, new SolidBrush(Color.Gainsboro), textRect);

            textSize = gr.MeasureString(_grid2Text, textFont);
            textSize.Height += 3;

            textRect = new RectangleF(_xAllOutput + (rAllInput.Width / 2) - (textSize.Width / 2), rAllInput.Bottom + 3, textSize.Width, textSize.Height);
            gr.DrawString(_grid2Text, textFont, new SolidBrush(Color.Gainsboro), textRect); 

            for (int index = 1; index < _columnCount; index++)
            {
                gr.DrawLine(matrixPen, _xAllInput + (index * _IoSize.Width), 20, _xAllInput + (index * _IoSize.Width), _inputMatrixHeight + 20);
                gr.DrawLine(matrixPen, _xAllOutput + (index * _IoSize.Width), 20, _xAllOutput + (index * _IoSize.Width), _outputMatrixHeight + 20);
            }

            for (int index = 1; index < _rowCount; index++)
            {
                gr.DrawLine(matrixPen, _xAllInput, (index * _IoSize.Height) + 20, _xAllInput + _inputMatrixWidth, (index * _IoSize.Height) + 20);
                gr.DrawLine(matrixPen, _xAllOutput, (index * _IoSize.Height) + 20, _xAllOutput + _outputMatrixWidth, (index * _IoSize.Height) + 20);
            }

            if (_allInput != null)
                foreach (IOGraphic input in _allInput)
                {
                    string text = input.IoNumber.ToString();
                    textSize = gr.MeasureString(text, Font);

                    textRect = new RectangleF(_xAllInput + input.Location.X + ((_IoSize.Width - textSize.Width) / 2), 20 + input.Location.Y + 3, textSize.Width, textSize.Height);

                    gr.DrawString(text, Font, _textBrush, textRect);
                }

            if (_allOutput != null)
                foreach (IOGraphic output in _allOutput)
                {
                    string text = (_indiciIncrementali ? output.IoNumber + _allInput.Length : output.IoNumber).ToString();
                    textSize = gr.MeasureString(text, Font);

                    textRect = new RectangleF(_xAllOutput + output.Location.X + ((_IoSize.Width - textSize.Width) / 2), 20 + output.Location.Y + 3, textSize.Width, textSize.Height);

                    gr.DrawString(text, Font, _textBrush, textRect);
                }

            CreateGraphics().DrawImage(_bmpDoubleBuffer, 0, 0);
            matrixPen.Dispose();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            foreach (IOGraphic input in _allInput)
                if (input.MouseIn(e.X, e.Y)) 
                {
                    SelectIo(input);
                    base.OnMouseUp(e);
                    return;
                }

            foreach (IOGraphic output in _allOutput)
                if (output.MouseIn(e.X, e.Y))
                {
                    SelectIo(output);
                    base.OnMouseUp(e);
                    return;
                } 

            base.OnMouseUp(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            _bmpDoubleBuffer = null;

            _xAllInput = (Width - (_inputMatrixWidth + 60 + _outputMatrixWidth)) / 2;
            _xAllOutput = _xAllInput + 60 + _inputMatrixWidth;

            if (_allInput != null)
                foreach (IOGraphic input in _allInput)
                    input.SetXOffset(_xAllInput, 20);

            if (_allOutput != null)
                foreach (IOGraphic output in _allOutput)
                    output.SetXOffset(_xAllOutput, 20);

            RefreshBackground();
        } 

        private Bitmap _bmpDoubleBuffer;
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr;

            if (_bmpDoubleBuffer == null)
                return;

            gr = Graphics.FromImage(_bmpDoubleBuffer);

            Pen penIo = new Pen(Color.Transparent);
            Brush brushIo = new SolidBrush(Color.Transparent);

            if (_allInput != null)
            { 
                foreach (IOGraphic input in _allInput) 
                    if (input.Status == IoStatus.None)
                    {
                        penIo = new Pen(input.IsSelected ? Color.FromArgb(32, 32, 32) : Color.FromArgb(16, 16, 16));
                        brushIo = new SolidBrush(input.IsSelected ? Color.FromArgb(32, 32, 32) : Color.FromArgb(16, 16, 16)); 

                        gr.DrawRectangle(penIo, new Rectangle(_xAllInput + input.Location.X, 20 + input.Location.Y, input.Size.Width, input.Size.Height));
                        gr.FillRectangle(brushIo, new Rectangle(_xAllInput + input.Location.X + 3, 20 + input.Location.Y + input.Size.Height - 5, input.Size.Width - 5, 3));
                    }

                foreach (IOGraphic input in _allInput)
                    if (input.Status == IoStatus.Off)
                    {
                        penIo = new Pen(input.IsSelected ? Color.FromArgb(96, 96, 96) : Color.FromArgb(64, 64, 64));
                        brushIo = new SolidBrush(input.IsSelected ? Color.FromArgb(96, 96, 96) : Color.FromArgb(64, 64, 64)); 

                        gr.DrawRectangle(penIo, new Rectangle(_xAllInput + input.Location.X, 20 + input.Location.Y, input.Size.Width, input.Size.Height));
                        gr.FillRectangle(brushIo, new Rectangle(_xAllInput + input.Location.X + 3, 20 + input.Location.Y + input.Size.Height - 5, input.Size.Width - 5, 3));
                    }

                foreach (IOGraphic input in _allInput)
                    if (input.Status == IoStatus.On)
                    {
                        penIo = new Pen(input.IsSelected ? Color.Lime : Color.LimeGreen);
                        brushIo = new SolidBrush(input.IsSelected ? Color.Lime : Color.LimeGreen); 

                        gr.DrawRectangle(penIo, new Rectangle(_xAllInput + input.Location.X, 20 + input.Location.Y, input.Size.Width, input.Size.Height));
                        gr.FillRectangle(brushIo, new Rectangle(_xAllInput + input.Location.X + 3, 20 + input.Location.Y + input.Size.Height - 5, input.Size.Width - 5, 3));
                    }  

                foreach (IOGraphic input in _allInput)
                    if (input.IsSelected)
                    {
                        penIo = new Pen(Color.Gainsboro);
                        gr.DrawRectangle(penIo, new Rectangle(_xAllInput + input.Location.X + 2, 20 + input.Location.Y + 2, input.Size.Width - 4, input.Size.Height - 4));
                    }
                    else
                    {
                        penIo = new Pen(BackColor);
                        gr.DrawRectangle(penIo, new Rectangle(_xAllInput + input.Location.X + 2, 20 + input.Location.Y + 2, input.Size.Width - 4, input.Size.Height - 4));
                    }
            }
            
            if (_allOutput != null)
            {
                foreach (IOGraphic output in _allOutput)
                    if (output.Status == IoStatus.None)
                    {
                        penIo = new Pen(output.IsSelected ? Color.FromArgb(32, 32, 32) : Color.FromArgb(16, 16, 16));
                        brushIo = new SolidBrush(output.IsSelected ? Color.FromArgb(32, 32, 32) : Color.FromArgb(16, 16, 16));

                        gr.DrawRectangle(penIo, new Rectangle(_xAllOutput + output.Location.X, 20 + output.Location.Y, output.Size.Width, output.Size.Height));
                        gr.FillRectangle(brushIo, new Rectangle(_xAllOutput + output.Location.X + 3, 20 + output.Location.Y + output.Size.Height - 5, output.Size.Width - 5, 3));
                    }

                foreach (IOGraphic output in _allOutput)
                    if (output.Status == IoStatus.Off)
                    {
                        penIo = new Pen(output.IsSelected ? Color.FromArgb(96, 96, 96) : Color.FromArgb(64, 64, 64));
                        brushIo = new SolidBrush(output.IsSelected ? Color.FromArgb(96, 96, 96) : Color.FromArgb(64, 64, 64));

                        gr.DrawRectangle(penIo, new Rectangle(_xAllOutput + output.Location.X, 20 + output.Location.Y, output.Size.Width, output.Size.Height));
                        gr.FillRectangle(brushIo, new Rectangle(_xAllOutput + output.Location.X + 3, 20 + output.Location.Y + output.Size.Height - 5, output.Size.Width - 5, 3));
                    }

                foreach (IOGraphic output in _allOutput)
                    if (output.Status == IoStatus.On)
                    {
                        penIo = new Pen(output.IsSelected ? Color.Lime : Color.LimeGreen);
                        brushIo = new SolidBrush(output.IsSelected ? Color.Lime : Color.LimeGreen);

                        gr.DrawRectangle(penIo, new Rectangle(_xAllOutput + output.Location.X, 20 + output.Location.Y, output.Size.Width, output.Size.Height));
                        gr.FillRectangle(brushIo, new Rectangle(_xAllOutput + output.Location.X + 3, 20 + output.Location.Y + output.Size.Height - 5, output.Size.Width - 5, 3));
                    }

                foreach (IOGraphic output in _allOutput)
                    if (output.IsSelected)
                    {
                        penIo = new Pen(Color.Gainsboro);
                        gr.DrawRectangle(penIo, new Rectangle(_xAllOutput + output.Location.X + 2, 20 + output.Location.Y + 2, output.Size.Width - 4, output.Size.Height - 4));
                    }
                    else
                    {
                        penIo = new Pen(BackColor);
                        gr.DrawRectangle(penIo, new Rectangle(_xAllOutput + output.Location.X + 2, 20 + output.Location.Y + 2, output.Size.Width - 4, output.Size.Height - 4));
                    }
            }

            penIo.Dispose();
            brushIo.Dispose();
            e.Graphics.DrawImage(_bmpDoubleBuffer, 0, 0);
            base.OnPaint(e);
        }

        private class IOGraphic
        {
            internal Point Location;
            internal IoStatus Status;
            internal Size Size;
            internal int IoNumber;
            internal Color BorderColor;
            internal bool IsInput;
            internal bool IsSelected;

            internal Point IoCoordinate;

            private Rectangle ClientRectangle;

            internal IOGraphic(bool isInput, int ioNumber, Point location, Size size, Color borderColor, IoStatus status, Point ioCoordinate)
            {
                IsInput = isInput;
                IoNumber = ioNumber;
                Location = location;
                Size = size;
                BorderColor = borderColor;
                Status = status;
                IoCoordinate = ioCoordinate;
            }

            internal IOGraphic SetXOffset(int x_offset, int y_offset)
            {
                ClientRectangle = new Rectangle(x_offset + Location.X, Location.Y + y_offset, Size.Width, Size.Height);
                return this;
            }

            internal bool MouseIn(int mouseX, int mouseY)
            { 
                return ClientRectangle.Contains(new Point(mouseX, mouseY));
            }
        }
    }

    public delegate void IoSelectedEventHandler(object sender, IoSelectedEventArgs e);
    public class IoSelectedEventArgs : EventArgs
    {
        private bool _isInput;
        public bool IsInput
        {
            get { return _isInput; }
        }

        private int _ioIndex;
        public int IoIndex
        {
            get { return _ioIndex; }
        }

        private int _ioOffset;
        public int IoOffset
        {
            get { return _ioOffset; }
        }

        public IoSelectedEventArgs(bool isInput, int ioIndex, int offset)
        {
            _isInput = isInput;
            _ioIndex = ioIndex;
            _ioOffset = offset;
        }
    }
}
