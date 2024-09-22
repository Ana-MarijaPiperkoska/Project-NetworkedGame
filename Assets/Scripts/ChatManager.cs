using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ChatManager : NetworkBehaviour
{
    
    public TMP_InputField chatInputField;
    public TMP_Text chatLog;

    
    private List<string> chatMessages = new List<string>();
    private const int maxMessages = 25;  


    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToChat();
        }
    }

     
    public void SendMessageToChat()
    {
        
        if (!string.IsNullOrEmpty(chatInputField.text))
        {
            
            SendChatMessageServerRpc(NetworkManager.Singleton.LocalClientId, chatInputField.text);
            chatInputField.text = "";
                     
        }
    }

    
    [ServerRpc(RequireOwnership = false)]
    private void SendChatMessageServerRpc(ulong senderClientId, string message)
    {
        string formattedMessage = $"Player {senderClientId}: {message}";

       
        BroadcastMessageClientRpc(formattedMessage);
    }

    [ClientRpc]
    private void BroadcastMessageClientRpc(string message)
    {
        
        chatMessages.Add(message);

        
        if (chatMessages.Count > maxMessages)
        {
            chatMessages.RemoveAt(0);
        }

        chatLog.text = "";
        foreach (string msg in chatMessages)
        {
            chatLog.text += msg + "\n";
        }
    }
}
