using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PonyTestTask;

public class LocalDataStorage
{
    private List<MessageData> messageDataList;

    public LocalDataStorage()
    {
        // Если нам нужно сохранять прошлые сообщения
        //

        // Если сообщения можно удалять сообщения, его игрок прекратил сессию
        messageDataList = new List<MessageData>();
    }

    public List<MessageData> GetMessage(MessageType messageType)
    {
        List<MessageData> messageWithSameType = new List<MessageData>();

        foreach(MessageData md in messageDataList)
        {
            if (md.messageType == messageType)
            {
                messageWithSameType.Add(md);
            }
        }

        return messageWithSameType;
    }
    
    public List<MessageData> GetMessage()
    {
        return messageDataList;
    }

    public void AddMessage(MessageData newMessage)
    {
        messageDataList.Add(newMessage);
    }
}
