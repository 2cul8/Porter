using System;
using System.Collections.Generic; 
using System.Text;
using System.Reflection;
using System.Xml;

namespace PorterProto
{
    public class MessageList : List<Message>
    {  
        public new void Sort()
        {
            MessageComaprer msgCompare = new MessageComaprer(); 
            base.Sort(msgCompare);
        }

        public int GetActiveMessageCount()
        {
            int count = 0;

            foreach (Message msg in this)
                if (msg.IsActive)
                    count++;

            return count;
        }

        internal void setMessageStatus(int id, bool stat)
        {
            foreach (Message msg in this)
                if (msg.Id == id)
                    msg.IsActive = stat;
        }

        internal static MessageList LoadMessageList()
        {
            MessageList msgList = new MessageList(); 

            XmlDocument xDocMsg = new XmlDocument();
            xDocMsg.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream(Global.MESSAGES_DEF_ASSEMBLY_NAME));

            foreach (XmlNode xNodeAdcDef in xDocMsg["MESSAGES"])
            { 
                int id = int.Parse(xNodeAdcDef.Attributes["id"].Value);
                int priority = int.Parse(xNodeAdcDef.Attributes["Priority"].Value);
                int level = int.Parse(xNodeAdcDef.Attributes["MessageLevel"].Value);
                string resource = xNodeAdcDef.Attributes["Resource"].Value;

                msgList.Add(new Message(id, priority, level, resource));
            }

            //msgList.Sort();
            return msgList;
        }

        private class MessageComaprer : IComparer<Message>
        {
            public int Compare(Message msgA, Message msgB)
            {
                if (msgA.MessagePrority == msgB.MessagePrority)
                    return 0;

                if (msgA.MessagePrority < msgB.MessagePrority)
                    return -1;
                else 
                    return 1; 
            }
        }
    }

    public class Message
    {
        private int id = 0;
        public int Id
        {
            get { return id; }
        }

        private int messagePrority = 0;
        public int MessagePrority
        {
            get { return messagePrority; }
        }

        private int messageLevel = 0;
        public int MessageLevel
        {
            get { return messageLevel; }
        }

        private bool isActive = false;
        public bool IsActive
        {
            get { return isActive; }
            internal set { isActive = value; }
        }

        private string messageResourceName = string.Empty;
        public string MessageResourceName
        {
            get { return messageResourceName; }
        }

        internal Message(int msgId, int msgPrio, int msgLvl, string msgResourceName)
        {
            id = msgId;
            messagePrority = msgPrio;
            messageLevel = msgLvl;
            messageResourceName = msgResourceName;
        }
    }
}
