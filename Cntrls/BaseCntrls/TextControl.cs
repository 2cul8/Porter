using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Resources;

namespace Cntrls.BaseCntrls
{
    public partial class TextControl : BaseControl
    {
        private static List<TextControl> createdControls = null;

        private object[] formatArgs = null;

        protected string textLabel = string.Empty; 
        public string TextLabel
        {
            get { return textLabel; }

            set
            {
                if (string.Compare(textLabel, value) == 0)
                    return;

                textLabel = value;
                text = LoadString(textLabel);

                Invalidate();
            }
        }

        private string text = string.Empty;
        protected new string Text
        {
            get { return text; }
        }

        public TextControl()
        {
            if (createdControls == null)
            {
                createdControls = new List<TextControl>();
                Settings.SettingChanged += new SettingChangedEventHandler(onSettingChanged);
            }

            InitializeComponent();

            createdControls.Add(this); 
        }

        private void onSettingChanged(object sender, SettingChangedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new SettingChangedEventHandler(onSettingChanged), new object[] { sender, e });
            else
                if (e.ChangedOption == SettingOptions.Language) 
                    foreach(TextControl cntrl in createdControls)
                        cntrl.OnLanguageChanged(); 
        }

        protected virtual void OnLanguageChanged()
        {
            text = LoadString(textLabel);
            Invalidate();
        } 

        protected string LoadString(string labelName)
        {
            if (string.IsNullOrEmpty(labelName))
                return string.Empty;

            string resourceString = (string)Resources.ResourcesManager.GetResource(labelName, ResourceType.String);

            resourceString = string.IsNullOrEmpty(resourceString) ? labelName : resourceString; 
            string resultText = (formatArgs == null ? resourceString : string.Format(resourceString, formatArgs)); 
            return resultText;
        }

        public string SetLabelFormatArgs(string label, params object[] args)
        {
            formatArgs = args;
            textLabel = label;
            return textLabel;
        }

        public void SetLabelFormatArgs(params object[] args)
        {   
            formatArgs = args;
        }
    }
}
