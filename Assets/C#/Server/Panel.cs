using System;
using System.Collections;
using System.Collections.Generic;
using PonyTestTask;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [Header("Статичные данные")]
    [SerializeField] private GameObject messageTextBox;
    [SerializeField] private Transform  messageParent;
    [Space]
    [Header("Динамические данные")]
    [SerializeField] private MessageType openPanelType = MessageType.Empty;

    private LocalDataStorage    localDataStorage;
    private TimeZoneInfo        playerTimeZone;

    private void Start()
    {
        playerTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
        localDataStorage = new LocalDataStorage();

        SendNewMessage("Hello world! Empty_1");
        SendNewMessage("Hello world! Empty_2");

        openPanelType = MessageType.Factional;
        SendNewMessage("Hello world! Factional_1");

        openPanelType = MessageType.Personal;
        SendNewMessage("Hello world! Personal_1");

        openPanelType = MessageType.Empty;
    }

    public void SendNewMessage(string message)
    {
        MessageData newMessage = new MessageData(GetActualTime(), message, "PonyQA", openPanelType);
        localDataStorage.AddMessage(newMessage);
        ShowMessage(newMessage);
    }
    // public void ChangePanel(MessageType openPanelType)
    public void ChangePanel(int typeID)
    {
        MessageType panelType = (MessageType) typeID;
        if (openPanelType == panelType)
        {
            return;
        }

        // ClearTextPanel();
        openPanelType = panelType;

        List<MessageData> messageDataList = new List<MessageData>();
        if (openPanelType == MessageType.Empty)
        {
            messageDataList = localDataStorage.GetMessage();
        }
        else
        {
            messageDataList = localDataStorage.GetMessage(openPanelType);
        }

        foreach(MessageData md in messageDataList)
        {
            ShowMessage(md);
        }
    }

    private void ShowMessage(MessageData message)
    {
        GameObject box = Instantiate(messageTextBox, messageParent);

        box.GetComponent<MessageTextBox>().SetData(message);
    }

    
    private string GetActualTime()
    {
        DateTime dateTime = DateTime.Now;

        DateTime serverTime = TimeZoneInfo.ConvertTime(dateTime, playerTimeZone);
        return string.Format("{0:00}:{1:00}:{2:00}", serverTime.Hour, serverTime.Minute, serverTime.Second);
    }
}