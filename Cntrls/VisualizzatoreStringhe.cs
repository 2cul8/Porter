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
    internal delegate void dSetCheckString(object sender, int Index, bool Status);

    public partial class VisualizzatoreStringhe : Control
    {
        public event EventHandler ModStringRequest = null;
        internal event dSetCheckString SetStringChecked = null;

        private bool _ShowSelectedItem = true;
        public bool ShowSelectedItem
        {
            get { return _ShowSelectedItem; }
            set { _ShowSelectedItem = value; }
        }

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set 
            { 
                _IsSelected = value; 
            }
        }

        private bool _ClickEnable = false;
        public bool ClickEnable
        {
            get { return _ClickEnable; }
            set 
            {
                _ClickEnable = value;  
            }
        }

        private Color _SelectionForeColor = Color.Gainsboro;
        public Color SelectionForeColor
        {
            get { return _SelectionBackColor; }
            set { _SelectionForeColor = value; }
        }

        private Color _BackColor = Color.Black;
        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                _BackColor = base.BackColor = value; 
            }
        } 
         
        private Color _ForeColor = Color.Black;
        public new Color ForeColor
        {
            get { return _ForeColor; }
            set 
            {
                _ForeColor = value; Invalidate(); 
            }
        } 

        private Color _SelectionBackColor = Color.FromArgb(32, 32, 32);
        public Color SelectionBackColor
        {
            get { return _SelectionBackColor; }
            set
            {
                _SelectionBackColor = value;
            }
        }

        private bool _IndexShowed = true;
        public bool ShowIndex
        {
            get { return _IndexShowed; }
            set 
            {
                _IndexShowed = value; Invalidate();
            }
        } 

        private Font _stringFont = new Font("Arial", 14.0F, FontStyle.Regular);
        public Font StringFont
        {
            get { return _stringFont; }
            set { _stringFont = value; Invalidate(); }
        }

        private string _text = string.Empty;
        public string TextString
        {
            get { return _text; }
            set { _text = value; Invalidate(); }
        }

        private int _Index = 0;
        public int Index
        {
            get { return _Index; }
            set 
            { _Index = value; }
        }

        private bool _ShowBtn = false;
        public bool ShowButton
        {
            get { return _ShowBtn; }
            set 
            {
                if (_ShowBtn != value) 
                    _ShowBtn = value;  
            }
        } 

        private StringAlignment _Allineamento;
        public StringAlignment Allineamento
        {
            get { return _Allineamento; }
            set { _Allineamento = value; Invalidate(); }
        } 

        public VisualizzatoreStringhe()
        {
            InitializeComponent(); 
        }

        public VisualizzatoreStringhe(string ToShow, int __Index)
            : this()
        {
            TextString = ToShow;
            Index = __Index;
        }

        //private Bitmap _doubleBuffer;
        protected override void OnPaint(PaintEventArgs e)
        {
            //_doubleBuffer = new Bitmap(Width, Height);
            Graphics gr = e.Graphics;//Graphics.FromImage(_doubleBuffer);
            Rectangle rCient = ClientRectangle;
            rCient.Width--;
            rCient.Height--;

            string _toWrite = " " + _text;
            Color _lineBackColor = _IsSelected ? _SelectionBackColor : _BackColor;
            Color _lineForeColor = _IsSelected ? _SelectionForeColor : _ForeColor;
            Color _borderColor = _IsSelected ? _SelectionForeColor : Color.FromArgb(32, 32, 32); 

            Font _font = _stringFont;

            StringFormat sf = new StringFormat();
            sf.Alignment = _Allineamento;
            sf.LineAlignment = StringAlignment.Center;

            SolidBrush sBrush = new SolidBrush(_lineBackColor);
            SolidBrush fBrush = new SolidBrush(_lineForeColor);
            Pen sPen = new Pen(_borderColor, 1.0F);
            gr.FillRectangle(sBrush, rCient);
            gr.DrawRectangle(sPen, rCient);

            gr.DrawString(_toWrite, _font, fBrush, rCient, sf);

            fBrush.Dispose();
            sf.Dispose();
            sBrush.Dispose(); 
            sPen.Dispose();

            base.OnPaint(e);
        } 

        public void Select()
        {
            if (!_IsSelected)
            {  
                _IsSelected = true;
                Invalidate();
            }
        }

        public void UnSelect()
        {
            if (_IsSelected)
            {
                _IsSelected = false;
                Invalidate();
            }
        }

        private void OnLabelClick(object sender, EventArgs e)
        {
            if (_ClickEnable)
                OnClick(e);
        } 
    }

    public class StringContainerControl : UserControl
    {
        private enum eScSenso : byte
        {
            Up = 0,
            Down = 1,

            Null = 2
        }
        private eScSenso scSenso = eScSenso.Null;
         
        public event EventHandler selectedLineChanged = null; 

        private Timer TmrScorr = null;

        private int MaxString = 0; //Numero massimo di stringhe visualizzabili.t
        private float StringY = 0F;
        private int NumberOfCntrls = 0; //Numero di stringhe visualizzate. 
        private ListOfString CurrentList = null;
        private List<VisualizzatoreStringhe> ListaVisualizzatori = null;

        //Informazioni per la visualizzazione:
        private Color stringBackColor = Color.Gainsboro;
        private Color stringForeColor = Color.Black;
        private Color stringSelectionBackColor = Color.FromArgb(32, 32, 32);
        private Color stringSelectionForeColor = Color.Gainsboro;
        private Font stringFont = new Font("Arial", 14F, FontStyle.Regular);
        private Font stringIndexFont = new Font("Arial", 14F, FontStyle.Regular);
        // ------------------------------------------- //

        public Font StringFont
        {
            get { return stringFont; }
            set { stringFont = value; }
        }

        public Font StringIndexFont
        {
            get { return stringIndexFont; }
            set { stringIndexFont = value; }
        }

        public Color StringBackColor
        {
            get { return stringBackColor; }
            set { stringBackColor = value; }
        }

        public Color StringForeColor
        {
            get { return stringForeColor; }
            set { stringForeColor = value; }
        }

        public Color StringSelectionBackColor
        {
            get { return stringSelectionBackColor; }
            set { stringSelectionBackColor = value; }
        }

        public Color StringSelectionForeColor
        {
            get { return stringSelectionForeColor; }
            set { stringSelectionForeColor = value; }
        }

        private int CurrentRangeUp = 0;
        private int CurrentRangeDown = 0;

        private bool _ShowSelectedItem = true;
        /// <summary>
        /// TRUE: Evidenzia la riga selezionata.
        /// </summary>
        public bool ShowSelectedItem
        {
            get { return _ShowSelectedItem; }
            set { _ShowSelectedItem = value; }
        }
        
        private bool _ScrollingOn = false;
        /// <summary>
        /// TRUE: Scorrimento automatico delle righe attivo.
        /// </summary>
        public bool ScrollingOn
        {
            get { return _ScrollingOn; }
        }

        private Color _BorederColor = Color.Black;
        public Color BorderColor
        {
            get { return _BorederColor; }
            set { _BorederColor = value; }
        }

        private float _BorderWidth = 1F;
        public float BorderWidth
        {
            get { return _BorderWidth; }
            set
            {
                if (value == 0F)
                    _BorderWidth = 1F;
                else
                    _BorderWidth = value; 
            }
        } 

        private StringAlignment _Allineamento;
        public StringAlignment Allineamento
        {
            get { return _Allineamento; }
            set { _Allineamento = value; }
        }

        /// <summary>
        /// Numero di stringhe create.
        /// </summary>
        public int Count
        {
            get 
            {
                if (CurrentList == null)
                    return 0;
                return CurrentList.Count; 
            }
        }

        private bool _ShowIndex = true;
        /// <summary>
        /// Visualizzazione degli indici di stringa.
        /// </summary>
        public bool ShowIndex
        {
            get { return _ShowIndex; }
            set { _ShowIndex = value; }
        }

        /// <summary>
        /// Numero di stringhe visualizzate contemporaneamente.
        /// </summary>
        public int ShowedCntrls
        {
            get { return ListaVisualizzatori == null ? 0 : ListaVisualizzatori.Count; }
        }

        private int _CurrentSelectedLine = 0;
        private int _CurrentRelLine = 0;
        /// <summary>
        /// Indice relativo della stringa corrente.
        /// </summary>
        public int CurrentSelectedLine
        {
            get { return _CurrentSelectedLine = CurrentRangeUp + _CurrentRelLine; }
        } 

        private int _StringHeight = 25;
        public int StringHeight
        {
            get { return _StringHeight; }
            set { _StringHeight = value; }
        }

        private bool _AutoScrollEnable = true;
        public bool AutoScrollEnable
        {
            get { return _AutoScrollEnable; }
            set { _AutoScrollEnable = value; }
        }

        private bool _ShowListButtons = false;
        public bool ShowListButtons
        {
            get { return _ShowListButtons; }
            set { _ShowListButtons = value; }
        }

        private bool _ClickEnable = false;
        public bool ClickEnable
        {
            get { return _ClickEnable; }
            set { _ClickEnable = value; }
        }

        private bool _UseCheckCntrl = false;
        public bool UseCheckCntrl
        {
            get { return _UseCheckCntrl; }
            set { _UseCheckCntrl = value; }
        }

        private string _NoStringText = string.Empty;
        public string NoStringText
        {
            get { return _NoStringText; }
            set { _NoStringText = value; }
        }
         
        public StringContainerControl()
        {
            this.AutoScroll = false;

            TmrScorr = new Timer();
            TmrScorr.Interval = 80;
            TmrScorr.Enabled = false;
            TmrScorr.Tick += new EventHandler(ScorriTabella); 
        } 

        public void SetApparence
            (
            Color _BackColor,
            Color _ForeColor,
            Color _SelectionBackColor,
            Color _SelectionForeColor,
            Font _StringFont,
            Font _IndexFont          
            )
        {
            StringBackColor = _BackColor;
            stringForeColor = _ForeColor;
            stringSelectionBackColor = _SelectionBackColor;
            stringSelectionForeColor = _SelectionForeColor;
            StringFont = _StringFont;
            stringIndexFont = _IndexFont;
        }

        /// <summary>
        /// Metodo di aggiunta righe.
        /// Per liste estese è meglio usare questo metodo.
        /// Crea un numero di controlli pari a quelli visibili a seconda della dimensione disponibile.
        /// </summary>
        /// <param name="ListaText"></param>
        public void AddStringhe(List<string> ListaText)
        {
            ClearAll();

            NumberOfCntrls = 0;
            CurrentRangeUp = 0;
            CurrentRangeDown = 0;

            int Index = 0;
            foreach(string S in ListaText)
            {
                StringWithIndex SWI = new StringWithIndex(Index, ListaText[Index]);

                if (NumberOfCntrls < MaxString)
                {
                    VisualizzatoreStringhe VS = CreateNew(SWI);
                    ListaVisualizzatori.Add(VS);
                    NumberOfCntrls++;
                    Controls.Add(VS);
                    CurrentRangeDown = NumberOfCntrls - 1;
                
                    if (Index == 0)
                    {
                        _CurrentRelLine = 0;
                        CurrentRangeUp = 0;
                        VS.Select();
                    }
                }
                
                CurrentList.Add(SWI);               
                Index++;
            }  

            if (this.MaxString < CurrentList.Count && _AutoScrollEnable) 
                foreach (VisualizzatoreStringhe VS in ListaVisualizzatori)
                    VS.Size = new Size(this.Width - 4 - VS.Height, VS.Height);
            else
                foreach (VisualizzatoreStringhe VS in ListaVisualizzatori)
                    VS.Size = new Size(this.Width - 8, VS.Height); 
        }

        public void AddItem(string Text, int Index) 
        {
            if (CurrentList == null)
                ClearAll();

            StringWithIndex SWI = new StringWithIndex(Index, Text);
            VisualizzatoreStringhe VS = CreateNew(SWI);
            
            CurrentList.Add(SWI);
            ListaVisualizzatori.Add(VS);

            if (NumberOfCntrls < MaxString)
            {
                Controls.Add(VS);
                NumberOfCntrls++;
            }

            if (NumberOfCntrls == 1)
                SelectIndex(0);
        }

        public void RemoveString(int Index)
        {
            if (CurrentList == null)
                return;

            if (Index >= CurrentList.Count)
                return;

            if (Index < 0)
                return;

            CurrentList.Remove(CurrentList[Index]);

            if (ListaVisualizzatori.Count < CurrentList.Count)
                ListaVisualizzatori.Remove(ListaVisualizzatori[Index]);

            Refresh();
        }

        public void AggiungiStringa(string Text)
        {
            if (CurrentList == null)
                ClearAll();

            AddItem(Text, CurrentList.Count);
        }

        private VisualizzatoreStringhe CreateNew(StringWithIndex SWI)
        {
            if (CurrentList == null) CurrentList = new ListOfString();
            if (ListaVisualizzatori == null) ListaVisualizzatori = new List<VisualizzatoreStringhe>();            

            VisualizzatoreStringhe VS = new VisualizzatoreStringhe(SWI.MyString, SWI.Index);

            VS.Location = new Point(4, (((NumberOfCntrls) * (_StringHeight + 2)) + (int)StringY));
            VS.Size = new Size(this.Width - 4 - (_AutoScrollEnable ? _StringHeight : 4), _StringHeight);

            VS.ShowSelectedItem = _ShowSelectedItem;
            VS.ShowIndex = _ShowIndex;
            VS.BackColor = StringBackColor;
            VS.ForeColor = stringForeColor;
            VS.SelectionBackColor = stringSelectionBackColor;
            VS.SelectionForeColor = stringSelectionForeColor;
            VS.StringFont = stringFont;  
            VS.Allineamento = _Allineamento;
            VS.ClickEnable = _ClickEnable;  
            
            if (_ClickEnable)
                VS.Click += new EventHandler(OnLabelClick); 

            return VS;
        }

        private void SetStringCkState(object sender, int Index, bool Status)
        {
            CurrentList[Index].IsChecked = Status;
        }

        private void OnLabelClick(object sender, EventArgs e)
        {
            if (sender is VisualizzatoreStringhe)
                if (CurrentSelectedLine != ((VisualizzatoreStringhe)sender).Index)
                    SelectIndex(((VisualizzatoreStringhe)sender).Index);
        } 

        private void ModifyAString(int RelIndex, string NewString)
        {
            try
            {
                if (RelIndex > 0 && RelIndex < Controls.Count)
                    if (this.Controls[RelIndex] is VisualizzatoreStringhe)
                        ((VisualizzatoreStringhe)this.Controls[RelIndex]).TextString = NewString;
            }
            catch
            { }
        }

        private void ModifyAString(string NewString)
        {
            try
            { 
                if (this.Controls[_CurrentRelLine] is VisualizzatoreStringhe)
                    ((VisualizzatoreStringhe)this.Controls[_CurrentRelLine]).TextString = NewString;
            }
            catch
            { }
        }

        /// <summary>
        /// Modifica la stringa specificata. Se non specifico l'indice viene modificata quella correntemente selezionata.
        /// </summary>
        /// <param name="NewString">Nuova label</param> 
        public void ModifyCurrentString(string NewString, bool Append)
        {
            string Mod = string.Empty;

            if (Append)
                Mod = CurrentList[CurrentSelectedLine].MyString + NewString;
            else
                Mod = NewString;

            ModifyAString(Mod);
            CurrentList[CurrentSelectedLine].MyString = NewString;
        } 

        public void ClearAll()
        { 
            SuspendLayout();

            if (CurrentList == null)
                CurrentList = new ListOfString();

            CurrentList.Clear();
            CurrentList = new ListOfString(); 

            Controls.Clear();

            if (ListaVisualizzatori == null)
                ListaVisualizzatori = new List<VisualizzatoreStringhe>();

            foreach (VisualizzatoreStringhe vs in ListaVisualizzatori)
                vs.Dispose();

            ListaVisualizzatori.Clear();
            ListaVisualizzatori = new List<VisualizzatoreStringhe>();

            NumberOfCntrls = 0;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            ResumeLayout(true);  
        }

        public void SelectIndex(int index)
        {
            try
            {  
                if (CurrentList == null || CurrentList.Count == 0)
                    return;

                if (index >= CurrentList.Count)
                    return;

                if (index < 0)
                    return;

                if (index >= NumberOfCntrls && index < (CurrentList.Count - NumberOfCntrls))
                {
                    CurrentRangeUp = index;
                    CurrentRangeDown = CurrentRangeUp + NumberOfCntrls;
                    ListaVisualizzatori[_CurrentRelLine].UnSelect();
                    _CurrentRelLine = 0;
                    ListaVisualizzatori[_CurrentRelLine].Select();

                    RefreshVisibili();

                    if (selectedLineChanged != null)
                        selectedLineChanged.Invoke(this, EventArgs.Empty);

                    return;
                }

                if (index < NumberOfCntrls)
                {
                    CurrentRangeUp = 0;
                    CurrentRangeDown = NumberOfCntrls;
                    ListaVisualizzatori[_CurrentRelLine].UnSelect();
                    _CurrentRelLine = index;
                    ListaVisualizzatori[_CurrentRelLine].Select();

                    RefreshVisibili();

                    if (selectedLineChanged != null)
                        selectedLineChanged.Invoke(this, EventArgs.Empty);

                    return;
                }

                if (index >= CurrentList.Count - NumberOfCntrls)
                {
                    CurrentRangeUp = CurrentList.Count - MaxString;
                    CurrentRangeDown = CurrentList.Count - 1;

                    ListaVisualizzatori[_CurrentRelLine].UnSelect();
                    _CurrentRelLine = index - CurrentRangeUp;
                    ListaVisualizzatori[_CurrentRelLine].Select();

                    RefreshVisibili();

                    if (selectedLineChanged != null)
                        selectedLineChanged.Invoke(this, EventArgs.Empty);

                    return;
                }
            }
            catch (Exception ex)
            { 
            }
        } 

        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    ScorPrevStart();
                    break;

                case Keys.Down:
                    ScorNextStart();
                    break;
            }
        }

        public void KeyUpHandler(object sender, KeyEventArgs e)
        {
            ScorStop();

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!_ScrollingOn)
                        SelectPrev();
                    break;

                case Keys.Down:
                    if (!_ScrollingOn)
                        SelectNext();
                    break; 
            } 
        }

        /// <summary>
        /// Start dello scorrimento automatico verso il basso.
        /// </summary>
        public void ScorNextStart()
        {
            scSenso = eScSenso.Down;
            Scorri = true;
            TmrScorr.Enabled = true;
            if (!TastPrem)
            {
                TastPrem = true;
                WaitInt = 0;
            }
        }

        private bool Scorri = false;

        /// <summary>
        /// Stop dello scorrimento automatico.
        /// </summary>
        public void ScorStop()
        {
            TmrScorr.Enabled = false;
            Scorri = false;
            WaitInt = 0;
            scSenso = eScSenso.Null;
            _ScrollingOn = false;
        }

        /// <summary>
        /// Start dello scorrimento automatico verso l'alto.
        /// </summary>
        public void ScorPrevStart()
        {
            scSenso = eScSenso.Up;
            Scorri = true;
            TmrScorr.Enabled = true;
            if (!TastPrem)
            {
                TastPrem = true;
                WaitInt = 0;
            }
        }

        private bool TastPrem = false;
        private int WaitInt = 0;
        private void ScorriTabella(object sender, EventArgs e)
        {
            if (!Scorri)
                return;

            if (WaitInt > 10)
            {
                _ScrollingOn = true;

                switch (scSenso)
                {
                    case eScSenso.Down:
                        SelectNext();
                        break;
                    case eScSenso.Up:
                        SelectPrev();
                        break;
                }
            }
            else
                WaitInt++; 
        }

        public void SelectNext()
        {
            try
            {
                if (CurrentList == null || CurrentList.Count == 0)
                    return;

                if (_CurrentRelLine == (NumberOfCntrls - 1))
                {
                    if (CurrentRangeDown < CurrentList.Count)
                    {
                        CurrentRangeDown++;
                        CurrentRangeUp = CurrentRangeDown - NumberOfCntrls;
                    }
                    else
                    {
                        CurrentRangeDown = NumberOfCntrls;
                        CurrentRangeUp = 0;
                        if (_ShowSelectedItem)
                            ListaVisualizzatori[_CurrentRelLine].UnSelect();
                        _CurrentRelLine = 0;
                        if (_ShowSelectedItem)
                            ListaVisualizzatori[_CurrentRelLine].Select();
                    }

                    RefreshVisibili();

                    if (selectedLineChanged != null)
                        selectedLineChanged.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    if (_ShowSelectedItem)
                        ListaVisualizzatori[_CurrentRelLine].UnSelect();
                    _CurrentRelLine++;
                    if (_ShowSelectedItem)
                        ListaVisualizzatori[_CurrentRelLine].Select();

                    if (selectedLineChanged != null)
                        selectedLineChanged.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            { }
        }

        public void SelectPrev()
        {
            try
            {
                if (CurrentList == null || CurrentList.Count == 0)
                    return;

                if (_CurrentRelLine == 0)
                {
                    if (CurrentRangeUp > 0)
                    {
                        CurrentRangeUp--;
                        CurrentRangeDown = CurrentRangeUp + (NumberOfCntrls - 1);
                    }
                    else
                    {
                        CurrentRangeDown = CurrentList.Count - 1;
                        CurrentRangeUp = CurrentRangeDown - (NumberOfCntrls - 1);
                        if (_ShowSelectedItem)
                            ListaVisualizzatori[_CurrentRelLine].UnSelect();
                        _CurrentRelLine = NumberOfCntrls - 1;
                        if (_ShowSelectedItem)
                            ListaVisualizzatori[_CurrentRelLine].Select();
                    }

                    RefreshVisibili();

                    if (selectedLineChanged != null)
                        selectedLineChanged.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    if (_ShowSelectedItem)
                        ListaVisualizzatori[_CurrentRelLine].UnSelect();
                    _CurrentRelLine--;
                    if (_ShowSelectedItem)
                        ListaVisualizzatori[_CurrentRelLine].Select();

                    if (selectedLineChanged != null)
                        selectedLineChanged.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception Ex)
            { }
        } 

        private void RefreshVisibili()
        {
            //try
            //{ 
                int i = CurrentRangeUp;
                foreach (VisualizzatoreStringhe VS in ListaVisualizzatori)
                {
                    VS.TextString = CurrentList[i].MyString;
                    VS.Index = CurrentList[i].Index;

                    if (i - CurrentRangeUp > MaxString)
                        break;

                    i++;
                } 
            //}
            //catch (Exception Ex)
            //{ LogManager.WriteLogMessage(Ex); }
        }

        private Bitmap bmpDoubleBuffer;
        protected override void OnPaint(PaintEventArgs e)
        {
            bmpDoubleBuffer = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bmpDoubleBuffer);

            Rectangle rClient = ClientRectangle;
            gr.FillRectangle(new SolidBrush(BackColor), rClient);

            Pen MyPen = new Pen(_BorederColor, 1F);
            Rectangle R = new Rectangle(0, 0, this.Width - (int)MyPen.Width, this.Height - (int)MyPen.Width);
            gr.DrawRectangle(MyPen, R); 

            if (CurrentList != null)
            {
                if (this.MaxString < CurrentList.Count && _AutoScrollEnable)
                {
                    Rectangle R1 = new Rectangle(this.Width - 2 - _StringHeight, 2, _StringHeight, _StringHeight);
                    Rectangle R2 = new Rectangle(this.Width - 2 - _StringHeight, Height - _StringHeight - 2, _StringHeight, _StringHeight);

                    MyPen = new Pen(Color.Red, 1F);

                    Point[] P = new Point[4];

                    int RowBase = 10;
                    int RowHeight = 8;

                    P[0] = new Point((this.Width - 8) - (RowBase), RowHeight + 6);
                    P[1] = new Point(this.Width - 8, RowHeight + 6);
                    P[2] = new Point(this.Width - 8 - (RowBase / 2), 6);
                    P[3] = P[0];

                    gr.DrawPolygon(MyPen, P);
                    gr.FillPolygon(new SolidBrush(Color.Red), P);

                    P[0] = new Point((this.Width - 8) - (RowBase), this.Height - 6 - (RowHeight));
                    P[1] = new Point(this.Width - 8, this.Height - 6 - (RowHeight));
                    P[2] = new Point(this.Width - 8 - (RowBase / 2), this.Height - 6);
                    P[3] = P[0];

                    gr.DrawPolygon(MyPen, P);
                    gr.FillPolygon(new SolidBrush(Color.Red), P); 
                }                
            }

            if (ListaVisualizzatori != null && ListaVisualizzatori.Count > 0)
            {
                //MyPen = new Pen(Color.FromArgb(32, 32, 32));
                //Brush MyBrush = new SolidBrush(StringBackColor);

                //const int rX = 3;
                //int rY = ListaVisualizzatori[ListaVisualizzatori.Count - 1].Location.Y + _StringHeight + 2;

                //if (!(rY > Height - 2))
                //{ 
                //    Rectangle rBase = new Rectangle(rX, rY, Width - 7, this.Height - rY - 4);

                //    gr.FillRectangle(MyBrush, rBase);
                //    gr.DrawRectangle(MyPen, rBase);
                //}

                //MyBrush.Dispose();
            }
            else
                if (!string.IsNullOrEmpty(_NoStringText))
                {
                    RectangleF rString = new RectangleF(3, (this.Height - 80) / 2, this.Width - 7, 80);  

                    Brush sBrush = new SolidBrush(Color.DarkGray);

                    gr.DrawString(_NoStringText, stringFont, sBrush, rString);

                    sBrush.Dispose(); 
                }

            MyPen.Dispose();

            e.Graphics.DrawImage(bmpDoubleBuffer, 0, 0);
            gr.Dispose();

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            //Calcolo il massimo numero di stringhe visualizzabili
            //a seconda della dimensione del controllo.
            MaxString = (this.Height - 2) / (_StringHeight + 2);
            StringY = 4;/*(this.Height - ((_StringHeight + 2) * MaxString)) / 2;*/
            base.OnResize(e);
        }
    }

    class StringWithIndex
    {
        private bool _IsChecked = false;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; }
        }

        private int _Index = 0;
        public int Index
        {
            get { return _Index; }
            internal set { _Index = value; }
        }

        private string _String = string.Empty;
        public string MyString
        {
            get { return _String; }
            set { _String = value; }
        }

        public StringWithIndex(int I, String S)
        {
            _Index = I;
            _String = S;
        }
    }

    class ListOfString : List<StringWithIndex>
    {
        public new void Remove(StringWithIndex toRemove)
        {
            base.Remove(toRemove);
            RefreshIndexes(); 
        }

        private void RefreshIndexes()
        {
            for (int index = 0; index < Count; index++)
                this[index].Index = index;
        }
    }

    public delegate void ModStringEventHandler(object sender, ModStringEventArgs e);

    public class ModStringEventArgs : EventArgs
    {
        private int _StringIndex = -1;

        public int StringIndex
        {
            get { return _StringIndex; }
        }

        public ModStringEventArgs(int __StringIndex)
            : base()
        {
            _StringIndex = __StringIndex;
        } 
    }
}
