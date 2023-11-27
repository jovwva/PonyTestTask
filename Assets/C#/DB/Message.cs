using UnityEngine;

namespace PonyTestTask
{
    public enum MessageType
    {
        Empty,
        Factional,
        Personal,
    }

    public struct MessageData
    {
        public MessageData(/*uint messageID, */string sendTime, string messageText, string playerNickname, MessageType messageType)
        {
            // this.messageID      = messageID;
            this.sendTime       = sendTime;
            this.messageText    = messageText;

            this.playerNickname = playerNickname;
            this.messageType    = messageType;
        }

        // public uint         messageID;
        public MessageType  messageType;
        public string       sendTime;
        public string       playerNickname;
        public string       messageText;
    }
}

