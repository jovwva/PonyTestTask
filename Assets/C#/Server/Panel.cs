using System;
using System.Collections.Generic;
using PonyTestTask;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [Header("Статичные данные")]
    [SerializeField] private GameObject messageTextBox;
    [SerializeField] private Transform  messageParent;
    [SerializeField] private ContentCleaner ContentCleaner;
    [Space]
    [Header("UI эллементы")]
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private List<Image> panelButtonList;
     
    [Space]
    [Header("Динамические данные")]
    [SerializeField] private MessageType openPanelType = MessageType.Empty;

    private LocalDataStorage    localDataStorage;
    private TimeZoneInfo        playerTimeZone;
    private Color               selectColor = new Color(0.13f, 0.65f, 0.5f, 1f);

    private void Start()
    {
        playerTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
        localDataStorage = new LocalDataStorage();

        panelButtonList[0].color = selectColor;
    }

    public void SendNewMessage(string message)
    {
        if (message == "")
        {
            return;
        }
        MessageData newMessage = new MessageData(GetActualTime(), message, "PonyQA", openPanelType);
        localDataStorage.AddMessage(newMessage);
        
        // inputField.Restore();
        inputField.text = "";

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

        ContentCleaner.ClearPanel();
        panelButtonList[(int) openPanelType].color = Color.white;
        openPanelType = panelType;
        panelButtonList[(int) openPanelType].color = selectColor;

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