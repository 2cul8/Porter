using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

//using Utility;
//using Utility.Const;

namespace Cntrls
{
    public partial class DialogBox : Form
    {
        public enum eDialogIcon
        {
            Question = 0,
            Error = 1,
            Exclametion = 2,
            General = 3
        }

        public enum eDialogMod
        {
            OK = 0,
            YES_NO = 1,
            YES_NO_CANCEL = 2,
        }

        private const string ExclametionIconURI = "Immagini.DialogBoxIcons.Exclametion.png";
        private const string QuestionIconURI = "Immagini.DialogBoxIcons.Question.png";
        private const string ErrorIconURI = "Immagini.DialogBoxIcons.Error.png";
        private const string GeneralIconURI = "Immagini.DialogBoxIcons.General.png";

        private Assembly MyAssembly = null;

        /// <summary>
        /// Testo da visualizzare
        /// </summary>
        public new string Text
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        /// <summary>
        /// Titolo da visualizzare
        /// </summary> 
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        private bool _showed;
        public bool Showed
        {
            get { return _showed; }
        }       

        private eDialogIcon _ShowIcon = eDialogIcon.General;
        /// <summary>
        /// Icona da visualizzare
        /// </summary> 
        public eDialogIcon ShowIcon
        {

            get { return _ShowIcon; }
            set
            {
                _ShowIcon = value;

                switch (value)
                {
                    case eDialogIcon.General:
                        pBox.Image = Properties.Resources.General;
                        break;

                    case eDialogIcon.Error:
                        pBox.Image = Properties.Resources.Error;
                        break;

                    case eDialogIcon.Exclametion:
                        pBox.Image = Properties.Resources.Exclametion;
                        break;

                    case eDialogIcon.Question:
                        pBox.Image = Properties.Resources.Question;
                        break;
                }

                this.Refresh();
            }
        }

        private eDialogMod _Modality = eDialogMod.OK;
        /// <summary>
        /// Modalità della finestra di dialogo
        /// </summary>
        public eDialogMod Modality
        {
            get { return _Modality; }
            set
            {
                _Modality = value;

                switch (value)
                {
                    case eDialogMod.OK:
                        btnOk.Caption = "Enter";
                        btnOk.BtnText = "Ok";
                        btnOk.Visible = true;
                        btnNo.Visible = btnCancel.Visible = false; 
                        break;

                    case eDialogMod.YES_NO:
                        btnCancel.Visible = false;
                        btnNo.Caption = "N";
                        btnOk.Caption = "Y";
                        btnOk.BtnText = "SI";
                        btnNo.Visible = btnOk.Visible = true;
                        break;

                    case eDialogMod.YES_NO_CANCEL:
                        btnNo.Caption = "N";
                        btnOk.Caption = "Y";
                        btnCancel.Caption = "DEL";
                        btnOk.BtnText = "SI";
                        btnNo.Visible = btnCancel.Visible = btnOk.Visible = true;
                        break;
                }
            }
        }

        private DialogResult __Result = DialogResult.OK;

        public DialogBox(string TextView, string titolo, eDialogIcon icon, eDialogMod mod)
        {
            InitializeComponent();
            MyAssembly = Assembly.GetExecutingAssembly();
                        
            Text = TextView;
            ShowIcon = icon;
            Modality = mod;
            Title = titolo;
        }

        public new DialogResult ShowDialog()
        {
            Location = Utils.CenterScreen(this.Size);
            lblTitle.LinePosition = eLinePosition.Down;
            Size = new Size(413, 240);
            TopMost = true;
            _showed = true;

            BringToFront();

            try
            { 
                base.ShowDialog(); 
            }
            catch(InvalidOperationException IOEx)
            {
                string[] dd = new string[2];

                dd[0] = "DialogBox: ShowDialog() InvalidOperetionException";
                dd[1] = IOEx.StackTrace;

                LogManager.WriteLogMessage(IOEx.Message, dd);
            }
            catch(ArgumentException AEx)
            {
                string[] dd = new string[2];

                dd[0] = "DialogBox: ShowDialog() ArgumentException";
                dd[1] = AEx.StackTrace;

                LogManager.WriteLogMessage(AEx.Message, dd);
            }

            _showed = false;
            return __Result;             
        }

        private void SetOK(object sender, EventArgs e)
        {
            if (_Modality == eDialogMod.OK)
                __Result = DialogResult.OK;
            else
                __Result = DialogResult.Yes;

            this.Close();
        }

        private void SetNo(object sender, EventArgs e)
        {
            __Result = DialogResult.No;
            this.Close();
        }

        private void SetCancel(object sender, EventArgs e)
        {
            __Result = DialogResult.Retry;
            this.Close();
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            //base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            //base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            switch (_Modality)
            {
                case eDialogMod.OK:
                    if (e.KeyCode == Keys.Enter)
                        SetOK(new object(), EventArgs.Empty);
                    break;

                case eDialogMod.YES_NO:
                    if (e.KeyCode == Keys.Y)
                        SetOK(new object(), EventArgs.Empty);
                    else if (e.KeyCode == Keys.N)
                        SetNo(new object(), EventArgs.Empty);
                    break;

                case eDialogMod.YES_NO_CANCEL:
                    if (e.KeyCode == Keys.Y)
                        SetOK(new object(), EventArgs.Empty);
                    else if (e.KeyCode == Keys.N)
                        SetNo(new object(), EventArgs.Empty);
                    else if (e.KeyCode == Keys.Escape)
                        SetCancel(new object(), EventArgs.Empty);
                    break; 
            }

            e.Handled = true;
            //base.OnKeyUp(e);
        }
    }
}