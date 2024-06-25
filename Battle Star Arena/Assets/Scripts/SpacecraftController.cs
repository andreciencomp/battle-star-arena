using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftController : MonoBehaviour
{
    private PlayerControls playerControls;
    private SpacecraftNavigation spacecraftNavigation;
    private ISpacecraftInterface spacecraft;
    private PhotonView view;
    void Start()
    {
        playerControls = new PlayerControls();
        spacecraftNavigation = GetComponent<SpacecraftNavigation>();
        spacecraft = GetComponent<ISpacecraftInterface>();
        playerControls.Enable();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine || (PhotonNetwork.IsConnected == false))
        {
            float rollAxis = playerControls.Spacecraft.Roll.ReadValue<float>();
            float pitchAxis = playerControls.Spacecraft.Pitch.ReadValue<float>();
            float yawAxis = playerControls.Spacecraft.Yaw.ReadValue<float>();
            bool normalShotButton = playerControls.Spacecraft.NormalShot.IsPressed();
            bool activateSkillButton = playerControls.Spacecraft.ActivateSkill.IsPressed();
            bool boost = playerControls.Spacecraft.Boost.IsPressed();

            spacecraftNavigation.SetRollAxis(rollAxis);
            spacecraftNavigation.SetPithAxis(pitchAxis);
            spacecraftNavigation.SetYawAxis(yawAxis);
            spacecraftNavigation.SetBoostActivated(boost);

            if (normalShotButton)
            {
                spacecraft.NormalShot();
            }
            if (activateSkillButton)
            {
                spacecraft.ActivateSkill();
            }
        }
        
       
    }
}
