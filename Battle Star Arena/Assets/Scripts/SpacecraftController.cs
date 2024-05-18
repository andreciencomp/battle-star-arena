using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftController : MonoBehaviour
{
    private PlayerControls playerControls;
    [SerializeField]
    private Spacecraft spacecraft;
    private AvengerI avenger;
    void Start()
    {
        playerControls = new PlayerControls();
        spacecraft = GetComponent<Spacecraft>();
        avenger = GetComponent<AvengerI>();
        playerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float rollAxis = playerControls.Spacecraft.Roll.ReadValue<float>();
        float pitchAxis = playerControls.Spacecraft.Pitch.ReadValue<float>();
        float yawAxis = playerControls.Spacecraft.Yaw.ReadValue<float> ();
        bool normalShotButton = playerControls.Spacecraft.NormalShot.IsPressed();

        spacecraft.SetRollAxis(rollAxis);
        spacecraft.SetPithAxis(pitchAxis);
        spacecraft.SetYawAxis(yawAxis);

        if(normalShotButton)
        {
            avenger.NormalShot();
        }
       
    }
}
