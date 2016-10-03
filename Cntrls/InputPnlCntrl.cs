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
    public delegate void dClickOnIODelegate(eIOType Type, int Index);

    public partial class IOPnlCntrl : Control
    {
        //public event dGenericIntDelegate eOutPutStateChanged = null;
        public event dClickOnIODelegate eClickOnIO = null;

        protected const int IOWidth = 36;
        protected const int IOHeight = 36;

        public const int IO_COLUMN_COUNT = 8;
        public const int IO_ROW_COUNT = 6;

        private ListOfIOStatus _IOStates = null;
        public ListOfIOStatus IOStates
        {
            get { return _IOStates; }
        }

        private eIOType _IOType = eIOType.NULL;

        private ListOfIOCntrl IOCntrlList = null;
        
        public IOPnlCntrl()
        {
            InitializeComponent();

            //Test
            _IOStates = new ListOfIOStatus();

            this.Size = new Size(329, 252);
        }

        public void InitIOCntrlList(eIOType __IOType)
        {
            _IOType = __IOType;

            if (IOCntrlList == null)
                IOCntrlList = new ListOfIOCntrl();
            else
                IOCntrlList.Clear();

            int PosX = 3;
            int PosY = 3;

            int IndexMatrixPosX = 0;
            int IndexMatrixPosY = 0;

            SuspendLayout();

            for (int i = 0; i < ListOfIOStatus.IO_COUNT; i++)
            {
                IoViewCntrl IO = new IoViewCntrl();

                //Fermo il richiamo dei gestori di evento.
                IO.Initializing = true;

                IO.Location = new Point(PosX, PosY);
                IO.MatrixLoaction = new Point(IndexMatrixPosX, IndexMatrixPosY);

                IO.Size = new Size(IOWidth, IOHeight);
                IO.Type = _IOType;

                if (_IOType == eIOType.INPUT)
                    IO.SetApparance
                        (
                            StaticVars.YellowDark,
                            StaticVars.Black,
                            StaticVars.YellowLight,
                            StaticVars.Gray,
                            1
                        );
                else if (_IOType == eIOType.OUTPUT)
                {
                    IO.SetApparance
                        (
                            StaticVars.YellowDark,
                            StaticVars.Black,
                            StaticVars.YellowLight,
                            StaticVars.Gray,
                            1
                        );

                    //Mi serve solo per le uscite.
                    //IO.eStatusChanged += new dGenericIntDelegate(IOSatusChangedHandler);
                }

                IO.Click += new EventHandler(ClickOnIOHandler);

                IO.IO_Index = (i + 1);
                IO.IOStatus = eIOState.OFF;

                //Abilito la gestione degli eventi.
                IO.Initializing = false;

                IOCntrlList.Add(IO);
                this.Controls.Add(IO);

                PosX += (IOWidth + 3);
                IndexMatrixPosX++;

                if ((PosX + (IOWidth + 3)) > this.Width)
                { 
                    PosX = 3;
                    PosY += (IOHeight + 3);
                    IndexMatrixPosY++;
                    IndexMatrixPosX = 0;
                }                  
            }

            ResumeLayout(true);
        }

        public void SetIOStates(ListOfIOStatus IOStatus)
        {
            if (IOStatus == null)
                return;

            int i = 0;

            SuspendLayout();

            foreach (eIOState IOS in IOStatus)
            {
                if (IOS == eIOState.OFF)
                    IOCntrlList.ReSetIO(i);
                else
                    IOCntrlList.SetIO(i);
                i++;
            }

            ResumeLayout(true);
        }

        public void ReSetIOStates()
        {
            SuspendLayout();

            foreach (IoViewCntrl IO in IOCntrlList)
                if (IO != null)
                    IO.IOStatus = eIOState.OFF;

            ResumeLayout(true);
        }

        private void IOSatusChangedHandler(int Index)
        {
            //if (eOutPutStateChanged != null)
            //    eOutPutStateChanged.Invoke(Index);
        }

        public eIOState GetIOState(int Index)
        {
            return IOCntrlList[Index].IOStatus;
        }

        private void ClickOnIOHandler(object sender, EventArgs e)
        {
            //eIOType Type = ((IOCntrl)sender).Type;
            int Index = ((IoViewCntrl)sender).IO_Index - 1;

            //if (eClickOnIO != null)
            //    eClickOnIO.Invoke(Type, Index);
        }

        public int SetSelected(Point MatrixPosi)
        {
            IOCntrlList.SetSelected(MatrixPosi);

            return MatrixPosi.X + (MatrixPosi.Y * IO_COLUMN_COUNT);
        }

        public void ClearSelection()
        {
            IOCntrlList.ClearSelection();
        }

        public static Point GetPointFromIndex(int Index)
        {
            int X = 0;
            int Y = 0;

            int i = 0;
            int count = 0;
            for (i = Index + 1; i > 8; i = i - IO_COLUMN_COUNT, count++) ;

            Y = count;
            X = i - 1;

            return new Point(X, Y);    
        }
    }

    class ListOfIOCntrl : List<IoViewCntrl>
    {
        public ListOfIOCntrl()
            : base(ListOfIOStatus.IO_COUNT)
        { }

        public new void Add(IoViewCntrl IO)
        {
            IO.Click += new EventHandler(IOClickHandler);
            base.Add(IO);
        }

        private void IOClickHandler(object sender, EventArgs e)
        {
            ForEach(new Action<IoViewCntrl>(ResetSelection));
        }

        internal void SetSelected(Point MatrixLocation)
        {
            ForEach(new Action<IoViewCntrl>(ResetSelection));

            foreach (IoViewCntrl IO in this)
            {
                if (IO.MatrixLoaction == MatrixLocation)
                    IO.IsSelected = true;
            }
        }

        private void ResetSelection(IoViewCntrl IO)
        {
            IO.IsSelected = false;
        }

        public void ClearSelection()
        {
            ForEach(new Action<IoViewCntrl>(ResetSelection));
        }

        public void SetIO(int Index)
        {
            this[Index].IOStatus = eIOState.ON;
        }

        public void ReSetIO(int Index)
        {
            this[Index].IOStatus = eIOState.OFF;
        }

        public ListOfIOStatus GetIOStates()
        {
            ListOfIOStatus List = new ListOfIOStatus();

            foreach (IoViewCntrl IO in this)
                List.Add(IO.IOStatus);

            return List;
        }
    }
}
