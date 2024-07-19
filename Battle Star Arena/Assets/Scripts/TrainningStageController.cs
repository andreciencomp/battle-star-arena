using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainningStageController : MonoBehaviour
{
    private TrainningStageConfig trainningConfig;
    [SerializeField]
    private Transform spacecraftSpawnPoint;
    [SerializeField]
    private CinemachineVirtualCamera spacecraftCamera;
    [SerializeField]
    private GameObject avengerGaugesPrefab;
    void Start()
    {
        trainningConfig = GameObject.Find("TrainningAreaConfig").GetComponent<TrainningStageConfig>();
        GameObject spacecraft = Instantiate(trainningConfig.GetSelectedSpacecraftPrefab(), spacecraftSpawnPoint.position, spacecraftSpawnPoint.rotation);
        Spacecraft spacecraftBehaviour = spacecraft.GetComponent<Spacecraft>();
        spacecraftBehaviour.SetState("FLYING");
        spacecraftCamera.m_Follow = spacecraft.transform;
        spacecraftCamera.m_LookAt = spacecraft.transform;
        if (spacecraftBehaviour.GetSpacecraftName() == "Avenger I")
        {
            GameObject avengerGauges = Instantiate(avengerGaugesPrefab,Vector3.zero, Quaternion.identity);
            avengerGauges.GetComponent<AvengerIGauges>().SetSpacecraftAvenger(spacecraft);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
