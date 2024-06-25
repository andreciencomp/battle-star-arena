using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    private string roomName;
    [SerializeField]
    private TMPro.TextMeshProUGUI roomText;
    
    void Start()
    {
        //roomText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
       // roomText.SetText(" - Room " + roomText.GetInstanceID());


    }

    public string GetRoomName()
    {
        return roomName;
    }

    public void SetRoomName(string roomName)
    {
        this.roomName = roomName;
        roomText.SetText(" - " + roomName);

    }

    public void OnClickRoomListItem()
    {
        Debug.Log("roomName: " + roomName);
        PhotonNetwork.JoinRoom(roomName);
    }
}
