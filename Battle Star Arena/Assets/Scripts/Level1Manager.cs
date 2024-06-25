using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    private CinemachineVirtualCamera spacecraftCamera;
    // Start is called before the first frame update
    void Start()
    {
        GameObject spacecraft = PhotonNetwork.Instantiate("Avenger I", spawnPoint.position, spawnPoint.rotation);
        if(spacecraft != null )
        {
            spacecraftCamera.LookAt = spacecraft.transform;
            spacecraftCamera.Follow = spacecraft.transform;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
