using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionManagerScript : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {

    }


    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.LoadLevel("Lobby Screen");
        Debug.Log("Conectado ao servidor. user: " + PhotonNetwork.LocalPlayer.NickName);
        if(PhotonNetwork.InLobby == false)
        {
            PhotonNetwork.JoinLobby();
            
        }
        else
        {
            Debug.Log("Já no Lobby");
        }
        
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined to Lobby");
        
    }

    public override void OnCreatedRoom()
    {
        
        Debug.Log("Sala criada");
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined to the room");
        PhotonNetwork.LoadLevel("Level_01");
        
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        LobbyManagerScript lobby = GameObject.FindAnyObjectByType(typeof(LobbyManagerScript)) as LobbyManagerScript;
        lobby.ListRooms(roomList);
    }

}


