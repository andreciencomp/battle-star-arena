using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLookAt(Transform transform)
    {
        virtualCamera.LookAt = transform;
    }

    void SetFollow(Transform transform)
    {
        virtualCamera.Follow = transform;
    }
}
