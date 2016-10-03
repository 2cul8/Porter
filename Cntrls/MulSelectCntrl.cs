using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Utility;

namespace Cntrls
{
    partial class MulSelectCntrl : Form
    {
        private SelectionItemList MyList = null;

        private int _SelectedIndex = 0;
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { lblTitle.Text = _Title = value; }
        }

        private string _Help = string.Empty;
        public string Help
        {
            get { return _Help; }
            set { _Help = lblHelp.Text = value; }
        }

        public MulSelectCntrl()
        {
            InitializeComponent();
            StringViewer.eSelectedIndexChanged += new dSelectedIndexChanged(OnSelectionEvent);
            this.KeyPreview = true;
        }

        public int ShowDialog(SelectionItemList List)
        {
            MyList = new SelectionItemList(List);
            SetApparence();
            RefreshItemList();
            base.ShowDialog();
            return _SelectedIndex;
        }

        private void SetApparence()
        {
            StringViewer.SetApparence
                (
                Color.FromArgb(32, 32, 32),
                Color.Gainsboro,
                Color.Gainsboro,
                Color.FromArgb(32, 32, 32),
                new Font("Arial", 14F, FontStyle.Regular),
                new Font("Arial", 16F, FontStyle.Regular)
                );

            StringViewer.ShowIndex = true;
        }

        private void RefreshItemList()
        {
            if (MyList == null)
                return;

            StringViewer.ClearAll();

            foreach (SelectionItem SL in MyList)
                StringViewer.AggiungiStringa_DaUno(SL.ItemString, (int)SL.Index);

            if (MyList.Count > 0)
                StringViewer.SelectIndex(0);
        }

        private void OnSelectionEvent(int SelectedItem)
        {            
            _SelectedIndex = SelectedItem;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    StringViewer.ScorPrevStart();
                    break;

                case Keys.Down:
                    StringViewer.ScorNextStart();
                    break;
            }

            base.OnKeyDown(e);
        } 

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            pnl1.Size = new Size(this.Width - 4, this.Height - 4);
        }
    }
}