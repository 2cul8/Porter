using System;
using System.Collections.Generic;
using System.Text;

namespace Cntrls.Boxes
{
    public static class Boxes
    {
        private static bool initialized = false;
        public static bool Initializad
        {
            get { return initialized; }
        }

        private static frmNumPad numPad;
        private static frmProgressDialog progressBox;
        private static frmMessageBox messageBox;
        private static frmLoadingBox loadingBox;
        private static FrmPopUp popUpBox;
        private static frmRequestString requestStringBox;
        private static frmRequestId requestIdBox;

        public static void InitBoxes()
        {
            numPad = new frmNumPad();
            progressBox = new frmProgressDialog();
            messageBox = new frmMessageBox();
            loadingBox = new frmLoadingBox();
            popUpBox = new FrmPopUp();
            requestStringBox = new frmRequestString();
            requestIdBox = new frmRequestId();
            initialized = true;
        }

        public static string RequestId(string title)
        {
            if (requestIdBox.ShowDialog(title) == System.Windows.Forms.DialogResult.OK)
                return requestIdBox.Value;

            return string.Empty;
        }

        public static string RequestString(string title, bool returnEnable)
        {
            if (requestStringBox.ShowDialog(title, returnEnable) == System.Windows.Forms.DialogResult.OK)
                return requestStringBox.Value;

            return string.Empty;
        }

        public static void ShowMessageDialog(string title, string text, frmMessageBox.MessageLevel lvl)
        {
            messageBox.ShowDialog(title, text, lvl, null);
        }

        public static void ShowMessageDialog(string title, string text, frmMessageBox.MessageLevel lvl, params object[] args)
        {
            messageBox.ShowDialog(title, text, lvl, args);
        }

        public static System.Windows.Forms.DialogResult ShowMessageDialog(string title, string text, frmMessageBox.MessageLevel lvl, frmMessageBox.BoxResponse response)
        {
            return messageBox.ShowDialog(title, text, lvl, response);
        }

        public static void ShowPopUp(string title, string message, int time)
        {
            if (popUpBox.Showing) 
                popUpBox.PopUpMessage = message; 
            else
                popUpBox.Show(title, message, time); 
        }

        public static string ShowNumPad(string title, string value)
        {
            if (numPad.ShowDialog(title, value) == System.Windows.Forms.DialogResult.OK)
                return numPad.NumPadValue;

            return string.Empty;
        }

        public static string ShowPasswordPad()
        {
            if (numPad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return numPad.NumPadValue;

            return string.Empty;
        }

        public static void ShowLoadingDialog(string title, string message, frmLoadingBox.ShowedMessageDelegate messageDelegate)
        {
            if (!loadingBox.Showing)
                loadingBox.ShowDialog(title, message, messageDelegate);
        }

        public static void ShowProgressDialog(string title, frmProgressDialog.PercentageValueDelegate precentageWorker)
        {
            progressBox.ShowDialog(title, precentageWorker);
        }

        public static void CloseLoadingDialog()
        {
            loadingBox.StartClosing();
        }

        public static void CloseProgressDialog()
        {
            progressBox.StartClosing(); 
        }

        public static void Dispose()
        {
            progressBox.Dispose();
            numPad.Dispose();
            messageBox.Dispose();
            loadingBox.Dispose();
            popUpBox.Dispose();
            requestStringBox.Dispose();
            requestIdBox.Dispose();
        }
    }
}
