using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public delegate void SettingChangedEventHandler(object sender, SettingChangedEventArgs e);
    public class SettingChangedEventArgs : EventArgs
    {
        private SettingOptions option = SettingOptions.None;
        public SettingOptions ChangedOption
        {
            get { return option; }
        } 

        private string newValue = string.Empty;
        public string NewValue
        {
            get { return newValue; }
        }

        public SettingChangedEventArgs(SettingOptions changedOption, string settingNewValue)
        {
            option = changedOption; 
            newValue = settingNewValue; 
        }
    }
}
