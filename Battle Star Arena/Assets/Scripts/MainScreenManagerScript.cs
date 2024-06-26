using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenManagerScript : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadLobbyScreen()
    {
        PhotonNetwork.LocalPlayer.NickName = "teste" + Random.Range(0, 10000);
        PhotonNetwork.ConnectUsingSettings();
    }

    public void LoadTrainningStage()
    {
        SceneManager.LoadScene("Spacecraft Selection Screen");
    }

   
}
