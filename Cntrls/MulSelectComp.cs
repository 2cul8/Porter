using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Drawing;

namespace Cntrls
{
    public partial class MulSelectComp : Component
    {
        private MulSelectCntrl MultipleSelection = null;
        private SelectionItemList _ItemsList = null;
        
        public MulSelectComp()
        {
            InitializeComponent();
        }

        public MulSelectComp(IContainer container)
        {
            container.Add(this); 
            InitializeComponent();
        }

        public int ShowDialog(string Title, string Help, Point Location, Size Size)
        {
            if (MultipleSelection == null)
                MultipleSelection = new MulSelectCntrl();

            MultipleSelection.Title = Title;
            MultipleSelection.Help = Help;
            MultipleSelection.Location = Location;
            MultipleSelection.Size = Size;

            return MultipleSelection.ShowDialog(_ItemsList);
        }

        public void AddItem(SelectionItem SI)
        {
            if (_ItemsList == null)
                ClearItems();

            _ItemsList.Add(SI);
        }

        public void AddItem(string Text)
        {
            if (_ItemsList == null)
                ClearItems();

            _ItemsList.Add(CreateItem(Text));
        }

        private SelectionItem CreateItem(string Text)
        {
            return new SelectionItem((uint)_ItemsList.Count, Text);
        }

        public void ClearItems()
        {
            _ItemsList = new SelectionItemList();
        }
    }

    public class SelectionItem
    {
        private uint _Index = 0;
        public uint Index
        {
            get { return _Index; }
        }

        private string _ItemString = string.Empty;
        public string ItemString
        {
            get { return _ItemString; }
        }

        public SelectionItem(uint __Index, string Text)
        {
            _Index = __Index;
            _ItemString = Text;
        }
    }

    internal class SelectionItemList : List<SelectionItem>
    {
        public SelectionItemList()
            : base()
        { }

        public SelectionItemList(SelectionItemList SIL)
        {
            this.Clear();
            this.AddRange(SIL);
        }
    }
}
