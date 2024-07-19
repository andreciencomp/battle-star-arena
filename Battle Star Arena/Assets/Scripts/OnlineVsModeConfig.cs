using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class OnlineVsModeConfig : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
        if(PhotonNetwork.LocalPlayer.IsMasterClient)
        {

        

            Hashtable hash = new Hashtable();
            hash.Add("hostName", PhotonNetwork.LocalPlayer.NickName);
            hash.Add("assignedFighterTeam1", null);
            hash.Add("assignedFighterTeam2", null);
            hash.Add("numPlayersReady", 0);
            hash.Add("levelState", "TEAM_SELECT");

            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetAssignedFighterTeam1()
    {

        return (string)PhotonNetwork.CurrentRoom.CustomProperties["assignedFighterTeam1"];
    }

    public bool AssignFighterTeam1(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        string assignedFighterTeam1 = (string) hash["assignedFighterTeam1"];
        if(assignedFighterTeam1 == null)
        {
            UnassignAll(username);
            hash["assignedFighterTeam1"] = username;
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
            return true;
        }
        return false;
    }

    public bool UnassignFighterTeam1(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        string assignedFighterTeam1 = (string)hash["assignedFighterTeam1"];
        if (assignedFighterTeam1 == username)
        {
            hash["assignedFighterTeam1"] = null;
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
        }
        return false;
       
    }

    private void UnassignAll(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        string assignedFighterTeam1 = (string) hash["assignedFighterTeam1"];
        string assignedFighterTeam2 = (string) hash["assignedFighterTeam2"];
        if (assignedFighterTeam1 == username)
        {
            hash["assignedFighterTeam1"] = null;
        }

        if (assignedFighterTeam2 == username)
        {
            hash["assignedFighterTeam2"] = null;
        }

        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);


    }

    public string GetAssignedFighterTeam2()
    {
        return (string) PhotonNetwork.CurrentRoom.CustomProperties["assignedFighterTeam2"];
    }

    public bool AssignFighterTeam2(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        string assignedFighterTeam2 = (string) hash["assignedFighterTeam2"];
        if (assignedFighterTeam2 == null)
        {
            UnassignAll(username);
            hash["assignedFighterTeam2"] = username;
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
            return true;
        }
        return false;
    }

    public bool UnassignFighterTeam2(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        string assignedFighterTeam2 = (string) hash["assignedFighterTeam2"];
        if (assignedFighterTeam2 == username)
        {
            hash["assignedFighterTeam2"] = null;
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
            return true;
        }
        return false;
        
    }

    public string GetLevelState()
    {
        return (string) PhotonNetwork.CurrentRoom.CustomProperties["levelState"];
    }

    public void SetLevelState(string levelState)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        hash["levelState"] = levelState;
        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
    }

    public int GetNumPlayersReady()
    {
        List<string> playersReady = (List<string>)PhotonNetwork.CurrentRoom.CustomProperties["playersReady"];
        return playersReady.Count;
    }

    public void StartGame()
    {
        List<string> playersReady = (List<string>)PhotonNetwork.CurrentRoom.CustomProperties["playersReady"];
        if (playersReady.Count > 0)
        {
            PhotonNetwork.CurrentRoom.CustomProperties["levelState"] = "RUNNING";
        }
        
    }

    public void SetHostPlayer(string username)
    {
        PhotonNetwork.CurrentRoom.CustomProperties["hostPlayer"] = username;
    }

    public bool IsPlayerReady(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        return hash["ready-"+username] != null;

    }

    public void SetReady(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;
        int numPlayersReady = (int) hash["numPlayersReady"];
        hash.Add("ready-" + username,"ready");
        hash["numPlayersReady"] = numPlayersReady++;
        
        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
    }

    public void SetNotReady(string username)
    {
        Hashtable hash = PhotonNetwork.CurrentRoom.CustomProperties;

        hash.Remove("ready-" + username);
        int numPlayersReady = (int) hash["numPlayersReady"];
        hash["numPlayersReady"] = numPlayersReady--;

        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
    }

    public void RemovePlayer(string username)
    {
        Debug.Log("Ñão implementado ainda");
    }


}
