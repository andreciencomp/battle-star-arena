using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


using Photon.Chat;
using ExitGames.Client.Photon;

public class LobbyChatManager : MonoBehaviour, IChatClientListener
{
    private bool connectedToChat;
    private ChatClient chatClient;
    [SerializeField] GameObject messagePrefab;
    [SerializeField] Transform messageArea;
    [SerializeField] TMPro.TextMeshProUGUI messageText;

    public void SendChatMessage()
    {
        string message = messageText.text;
        chatClient.PublishMessage("RegionChannel", message);
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log("debug: " + message);
    }

    public void OnChatStateChange(ChatState state)
    {
        //throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        Debug.Log("Conectado");
        chatClient.Subscribe(new string[] { "RegionChannel" });
    }

    public void OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for(int i = 0; i < messages.Length; i++)
        {
            string messageStr = senders[i] + ": " + ((string) messages[i]);
            GameObject chatMessage = GameObject.Instantiate(messagePrefab, Vector3.zero, Quaternion.identity, messageArea);
            chatMessage.GetComponent<ChatMessage>().SetChatMessage(messageStr);
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log("Inscrito");
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        connectedToChat = false;
        chatClient = new ChatClient(this);
        bool x = chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.LocalPlayer.NickName));
        connectedToChat = x;
    }

    // Update is called once per frame
    void Update()
    {
        if(connectedToChat)
        {
            chatClient.Service();
        }
    }
}
