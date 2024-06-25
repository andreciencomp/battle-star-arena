using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageChatManager : MonoBehaviour
{
    private Transform chatContent;
    [SerializeField]
    private GameObject chatMessagePrefab;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendMessage()
    {
        Debug.Log("pass here");
        Debug.Log("text: " + text.text);
        GetComponent<PhotonView>().RPC("Enviar", RpcTarget.All);
        Debug.Log("pos");
    }

    [PunRPC]
    public void Enviar()
    {
        Debug.Log("hereyes");
        //GameObject chatMessage = Instantiate(chatMessagePrefab,Vector3.zero, Quaternion.identity, chatContent);
       // chatMessage.GetComponent<ChatMessage>().SetChatMessage(message);
    }
}
