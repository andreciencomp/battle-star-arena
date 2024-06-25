using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class LobbyManagerScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI roomNameToJoin;
    [SerializeField]
    private TMPro.TextMeshProUGUI newRoomName;
    [SerializeField]
    private Button createRoomButton;
    [SerializeField]
    private Button joinRoomButton;
    [SerializeField]
    private GameObject panelCreateRoom;

    private List<RoomInfo> rooms;
    [SerializeField]
    private GameObject roomItemListPrefab;
    [SerializeField]
    private GameObject scrollViewContents;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.CreateRoom(newRoomName.text);
            panelCreateRoom.SetActive(false);
        }
    }

    public void JoinRoom()
    {
        if(PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinRoom(roomNameToJoin.text);
        }
    }

    public void OnClickRoomItem()
    {

    }


    public void ListRooms(List<RoomInfo> roomList)
    {
        rooms = roomList;
        foreach(RoomInfo room in rooms)
        {
            GameObject roomItem = Instantiate(roomItemListPrefab,scrollViewContents.transform);
            roomItem.GetComponent<RoomListItem>().SetRoomName(room.Name);
        }
    }
}
