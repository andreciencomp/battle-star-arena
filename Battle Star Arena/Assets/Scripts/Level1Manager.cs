using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    private string levelState;
    [SerializeField]
    private OnlineVsModeConfig onlineConfig;
    [SerializeField]
    private GameObject canvasSelectionTeam;
    [SerializeField] 
    private TextMeshProUGUI textStartReadyOrNot;
    [SerializeField]
    Transform spawnPointFighterTeam1;
    [SerializeField]
    Transform spawnPointFighterTeam2;
    [SerializeField]
    private CinemachineVirtualCamera spacecraftCamera;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            textStartReadyOrNot.text = "Start";
            onlineConfig = (PhotonNetwork.Instantiate("OnlineGameConfig", Vector3.zero, Quaternion.identity)).GetComponent<OnlineVsModeConfig>();
        }
        else
        {
            textStartReadyOrNot.text = "Pronto";
        }

        spawnPointFighterTeam1 = GameObject.Find("SpawnPointFighterTeam1").transform;
        spawnPointFighterTeam2 = GameObject.Find("SpawnPointFighterTeam2").transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(onlineConfig == null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("OnlineGameConfig");
            if (gameObject == null)
            {
                return;
            }
            else
            {
                onlineConfig = gameObject.GetComponent<OnlineVsModeConfig>();
            }
        }

       string onlineGameState = onlineConfig.GetLevelState();
       if(onlineGameState == "TEAM_SELECT")
        {
            levelState = "TEAM_SELECT";
            
        }
        if(levelState == "TEAM_SELECT" && onlineGameState == "RUNNING")
        {
            levelState = "INITIALIZING";

        }

        switch(levelState)
        {
            case "TEAM_SELECT":
                canvasSelectionTeam.SetActive(true);
                break;
            case "INITIALIZING":
                canvasSelectionTeam.SetActive(false);
                InstantiateSpaceCraft();
                levelState = "RUNNING";
                break;
            case "RUNNING":
                break;
        }
        Debug.Log("level-state: " + levelState);
    }

    public void InstantiateSpaceCraft()
    {
        if(onlineConfig.GetAssignedFighterTeam1() != null && onlineConfig.GetAssignedFighterTeam1() == PhotonNetwork.LocalPlayer.NickName)
        {
            GameObject spacecraftObject = PhotonNetwork.Instantiate("Avenger I", spawnPointFighterTeam1.position, spawnPointFighterTeam1.rotation);
            Spacecraft spacecraft = spacecraftObject.GetComponent<Spacecraft>();
            spacecraft.SetSide(1);
            spacecraft.SetState("FLYING");
            spacecraft.SetPilotName(PhotonNetwork.LocalPlayer.NickName);
            GameObject gaugesPrefab = Resources.Load("AvengerIGauges") as GameObject;
            GameObject gauges = Instantiate(gaugesPrefab,Vector3.zero,Quaternion.identity);
            AvengerIGauges avengerIGauges = gauges.GetComponent<AvengerIGauges>();
            avengerIGauges.SetUPGauges(spacecraftObject);

            if (spacecraftObject != null)
            {
                spacecraftCamera.LookAt = spacecraftObject.transform;
                spacecraftCamera.Follow = spacecraftObject.transform;
            }
        }
        else if (onlineConfig.GetAssignedFighterTeam2() != null && onlineConfig.GetAssignedFighterTeam2() == PhotonNetwork.LocalPlayer.NickName)
        {
            GameObject spacecraftObject = PhotonNetwork.Instantiate("Avenger I", spawnPointFighterTeam2.position, spawnPointFighterTeam2.rotation);
            Spacecraft spacecraft = spacecraftObject.GetComponent<Spacecraft>();
            spacecraft.SetSide(2);
            spacecraft.SetState("FLYING");
            spacecraft.SetPilotName(PhotonNetwork.LocalPlayer.NickName);
            GameObject gaugesPrefab = Resources.Load("AvengerIGauges") as GameObject;
            GameObject gauges = Instantiate(gaugesPrefab, Vector3.zero, Quaternion.identity);
            AvengerIGauges avengerIGauges = gauges.GetComponent<AvengerIGauges>();
            avengerIGauges.SetUPGauges(spacecraftObject);
            if (spacecraftObject != null)
            {
                spacecraftCamera.LookAt = spacecraftObject.transform;
                spacecraftCamera.Follow = spacecraftObject.transform;
            }
        }


    }

    public void StartOrMakeReadyOrNotReady()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            onlineConfig.SetLevelState("RUNNING");
            
        }
    }
}
