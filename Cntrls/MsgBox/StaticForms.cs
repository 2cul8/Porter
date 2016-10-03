using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//using Utility;

namespace Cntrls 
{
    public static class StaticForms
    {
        public const int ALL_STATIC_FORMS_COUNT = 3;

        private static NullReferenceException InitFailedException = null;

        public static event dSetLoadingString ObjectLoaded = null;

        private static DialogBox dBox = null;
        //private static InputPanel iPnl = null;
        //private static NumPad nPad = null;
        //private static Splash sSplash = null;

        public static bool InvokeRequired
        {
            get { return dBox.InvokeRequired; }
        }

        public static bool _dialogBoxShowed;
        public static bool DialogBoxShowed
        {
            get { return dBox != null && dBox.Showed; } 
        }

        private static bool _AllLoaded = false;

        public static bool AllLoaded
        {
            get { return _AllLoaded; }
        }

        public static void InitForms()
        {
            InitFailedException = new NullReferenceException("StaticForms: Initilizing Error Occurred.");

            try
            {
                dBox = new DialogBox("", "", DialogBox.eDialogIcon.General, DialogBox.eDialogMod.OK);
                if (ObjectLoaded != null)
                    ObjectLoaded.Invoke("DialogBox"); 

                _AllLoaded = true; 
                return;
            }
            catch (Exception Ex)
            {
                string[] dd = new string[2];
                dd[0] = "StaticForms: InitForms";
                dd[1] = Ex.StackTrace;

                LogManager.WriteLogMessage(Ex.Message, dd);
                 
                _AllLoaded = false; 
            }
        }

        #region DialogBox

        private delegate DialogResult ShowDialogBoxDelegate(string Text, string Title, DialogBox.eDialogMod Buttons, DialogBox.eDialogIcon Icon);
        
        public static DialogResult ShowDialogBox(string Text, string Title, DialogBox.eDialogMod Buttons, DialogBox.eDialogIcon Icon)
        {
            if (dBox != null)
                if (dBox.InvokeRequired)
                    return (DialogResult)dBox.Invoke(new ShowDialogBoxDelegate(ShowDialogBox), new object[] { Text, Title, Buttons, Icon });
            try
            {
                if (dBox == null)
                {
                    InitForms();
                    if (!_AllLoaded)
                        throw new NullReferenceException();
                }

                dBox.Modality = Buttons;
                dBox.ShowIcon = Icon;
                dBox.Text = Text;
                dBox.Title = Title;

                return dBox.ShowDialog();
            }
            catch (ObjectDisposedException OBEx)
            {
                {
                    InitForms();
                    if (!_AllLoaded)
                        throw new NullReferenceException();
                }

                dBox.Modality = Buttons;
                dBox.ShowIcon = Icon;
                dBox.Text = Text;
                dBox.Title = Title;

                return dBox.ShowDialog();
            }
        }

        public static DialogResult ShowDialogBox(string Text, string Title, DialogBox.eDialogMod Buttons)
        {
            return ShowDialogBox(Text, Title, Buttons, DialogBox.eDialogIcon.General);
        }

        public static DialogResult ShowDialogBox(string Text, string Title)
        {
            return ShowDialogBox(Text, Title, DialogBox.eDialogMod.OK, DialogBox.eDialogIcon.General);
        }

        public static DialogResult ShowDialogBox(string Text)
        {
            return ShowDialogBox(Text, "Dialog Box", DialogBox.eDialogMod.OK, DialogBox.eDialogIcon.General);
        }

        #endregion

        #region NumPad

        //public static string ShowNumPad(string InitText, eModNumPad Mode, NumPad.ButtonToEnableEnum BtnToEnable)
        //{
        //    if (nPad == null)
        //    {
        //        InitForms();
        //        if (!_AllLoaded)
        //            throw new NullReferenceException();
        //    }

        //    return nPad.ShowDialog(InitText, Mode, BtnToEnable);
        //}

        //public static string ShowNumPad(string InitText, eModNumPad Mode)
        //{
        //    try
        //    {   
        //        if (nPad == null)
        //        {
        //            InitForms();
        //            if (!_AllLoaded)
        //                throw new NullReferenceException();
        //        }

        //        return nPad.ShowDialog(InitText, Mode);
        //    }
        //    catch
        //    { return string.Empty; }
        //}

        //public static string ShowNumPad(string InitText)
        //{
        //    try
        //    {
        //        return ShowNumPad(InitText, eModNumPad.Normal);
        //    }
        //    catch
        //    { return string.Empty; }
        //}

        //public static string ShowNumPad(eModNumPad Mode)
        //{
        //    try
        //    {
        //    return ShowNumPad(string.Empty, Mode);
        //    }
        //    catch
        //    { return string.Empty; }
        //}

        //public static string ShowNumPad()
        //{
        //    try
        //    {
        //        return ShowNumPad(string.Empty, eModNumPad.Normal);
        //    }
        //    catch
        //    { return string.Empty; }
        //}

        #endregion

        #region InputPanel

        //public static string ShowInputPanel()
        //{
        //    if (iPnl == null)
        //    {
        //        InitForms();
        //        if (!_AllLoaded)
        //            throw new NullReferenceException();
        //    }
             
        //    return iPnl.ShowDialog();
        //}

        #endregion

        #region SplashInfo

        public delegate void ShowSplashDelegate(string Text);

        //public static bool SplashVisible
        //{
        //    get { return Splash.Showing; }
        //}

        //public static void ShowSplash(string ToShow)
        //{
        //    if (sSplash == null)
        //        return;

        //    if (sSplash.InvokeRequired)
        //        sSplash.Invoke(new ShowSplashDelegate(ShowSplash), new object[] { ToShow });
        //    else
        //    {
        //        if (Splash.Showing)
        //            return;

        //        if (Splash.Showing)
        //            sSplash.Close(false);

        //        sSplash.TopMost = true;
        //        sSplash.Show(ToShow);
        //        sSplash.BringToFront();
        //    }
        //}

        //public static void CloseSplash()
        //{
        //    if (sSplash.InvokeRequired)
        //        sSplash.Invoke(new dGenericVoidDelegate(CloseSplash));
        //    else
        //    {
        //        if (sSplash == null)
        //            return;

        //        if (Splash.Showing)
        //            sSplash.Close(false);
        //    }
        //}

        #endregion

        public static void DisposeAll()
        {
            if (dBox != null)
                dBox = null;

            //if (iPnl != null)
            //    iPnl = null;

            //if (nPad != null)
            //    nPad = null;

            //if (sSplash != null)
            //{
            //    if (Splash.Showing)
            //        sSplash.Close(true);

            //    sSplash = null;
            //}
        }
    }
}
