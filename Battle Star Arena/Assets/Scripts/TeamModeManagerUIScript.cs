using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamModeManagerUIScript : MonoBehaviour
{
    private OnlineVsModeConfig gameConfig;
    private TextMeshProUGUI team1FighterPlayerName;
    private Button team1FighterSelectButton;
    private TextMeshProUGUI team1FighterSelectButtonText;
    private TextMeshProUGUI team2FighterPlayerName;
    private Button team2FighterSelectButton;
    private TextMeshProUGUI team2FighterSelectButtonText;

    private TextMeshProUGUI delta;

    private string playerUserName;

    private Button buttonStartReadyOrNot;

    void Start()
    {
        playerUserName = PhotonNetwork.LocalPlayer.NickName;
        team1FighterPlayerName = GameObject.Find("Team1FighterPlayerName").GetComponent<TextMeshProUGUI>();
        team1FighterSelectButton = GameObject.Find("Team1FighterSelectButton").GetComponent<Button>();
        team1FighterSelectButtonText = GameObject.Find("Team1FighterSelectButtonText").GetComponent<TextMeshProUGUI>();

        team2FighterPlayerName = GameObject.Find("Team2FighterPlayerName").GetComponent<TextMeshProUGUI>();
        team2FighterSelectButton = GameObject.Find("Team2FighterSelectButton").GetComponent<Button>();
        team2FighterSelectButtonText = GameObject.Find("Team2FighterSelectButtonText").GetComponent<TextMeshProUGUI>();
        delta = GameObject.Find("Delta").GetComponent<TextMeshProUGUI>();

       

        buttonStartReadyOrNot = GameObject.Find("Button Start-ReadyOrNot").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUserName = PhotonNetwork.LocalPlayer.NickName;
        
        Debug.Log("playerName: " +  playerUserName);
        delta.SetText(playerUserName);
        if (gameConfig == null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("OnlineGameConfig");
            if(gameObject == null)
            {
                return;
            }
            else
            {
                gameConfig = gameObject.GetComponent<OnlineVsModeConfig>();
            }
        }
        if(gameConfig.GetAssignedFighterTeam1() == null)
        {
            team1FighterPlayerName.SetText("--empty--");
            team1FighterSelectButtonText.SetText("Select");
            team1FighterSelectButton.enabled = true;
        }
        else if (gameConfig.GetAssignedFighterTeam1() == playerUserName)
        {
            team1FighterPlayerName.SetText(gameConfig.GetAssignedFighterTeam1());
            team1FighterSelectButtonText.SetText("Unselect");
            team1FighterSelectButton.enabled = true;
        }
        else if(gameConfig.GetAssignedFighterTeam1() != playerUserName)
        {
            team1FighterPlayerName.SetText(gameConfig.GetAssignedFighterTeam1());
            team1FighterSelectButton.enabled = false;
            team1FighterSelectButtonText.SetText("Already taken");
        }

        if (gameConfig.GetAssignedFighterTeam2() == null)
        {
            team2FighterPlayerName.SetText("--empty--");
            team2FighterSelectButtonText.SetText("Select");
            team2FighterSelectButton.enabled = true;
        }
        else if (gameConfig.GetAssignedFighterTeam2() == playerUserName)
        {
            team2FighterPlayerName.SetText(gameConfig.GetAssignedFighterTeam2());
            team2FighterSelectButtonText.SetText("Unselect");
            team2FighterSelectButton.enabled = true;
        }
        else if(gameConfig.GetAssignedFighterTeam2() != playerUserName)
        {
            team2FighterPlayerName.SetText(gameConfig.GetAssignedFighterTeam2());
            team2FighterSelectButton.enabled = false;
            team2FighterSelectButtonText.SetText("Already taken");
        }


    }

    public void SelectOrDeselectTeam1Fighter()
    {
        string playerUsername = PhotonNetwork.LocalPlayer.NickName;
        if (gameConfig.GetAssignedFighterTeam1() == playerUsername)
        {
            gameConfig.UnassignFighterTeam1(playerUsername);

        }
        else
        {
            bool available = gameConfig.AssignFighterTeam1(PhotonNetwork.LocalPlayer.NickName);
            if (available)
            {
                //Tocar som
            }
        }
        
    }

    public void SelectOrDeselectTeam2Fighter()
    {
        string playerUsername = PhotonNetwork.LocalPlayer.NickName;
        if (gameConfig.GetAssignedFighterTeam2() == playerUsername)
        {
            gameConfig.UnassignFighterTeam2(playerUsername);

        }
        else
        {
            bool available = gameConfig.AssignFighterTeam2(PhotonNetwork.LocalPlayer.NickName);
            if (available)
            {
                //Tocar som
            }
        }

    }

    public void StartReadyOrNotReadyButtonEvent()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            gameConfig.StartGame();
        }
    }


}
