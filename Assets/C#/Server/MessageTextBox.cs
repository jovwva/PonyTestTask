using System.Collections;
using System.Collections.Generic;
using PonyTestTask;
using TMPro;
using UnityEngine;

public class MessageTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;

    public void SetData(MessageData messageData)
    {
        messageText.text = $"[{messageData.sendTime}] {messageData.playerNickname}: {messageData.messageText}";

        messageText.color = GetMessageColor(messageData.messageType);
    }
    private Color GetMessageColor(MessageType messageType)
    {
        switch (messageType)
        {
            case MessageType.Factional:
                return Color.red;
            case MessageType.Personal:
                return Color.green;
            default:
                return Color.white;
        }
    }
}
