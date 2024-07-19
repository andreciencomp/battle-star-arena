using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerIGauges : MonoBehaviour
{
    private Rigidbody spacecraftRigidbody;
    private SpacecraftNavigation spacecraftNavigation;
    private AvengerI avengerI;
    [SerializeField]
    private TMPro.TextMeshProUGUI speedText;
    [SerializeField]
    private TMPro.TextMeshProUGUI powerfulCannonText;
    [SerializeField]
    private TMPro.TextMeshProUGUI boostAmountText;
    void Start()
    {
        
    }

    public void SetUPGauges(GameObject spacecraft)
    {
        spacecraftRigidbody = spacecraft.GetComponent<Rigidbody>();
        spacecraftNavigation = spacecraft.GetComponent<SpacecraftNavigation>();
        avengerI = spacecraft.GetComponent<AvengerI>();
    }

    // Update is called once per frame
    void Update()
    {
        float kmh = spacecraftRigidbody.velocity.magnitude * 3.6f;
        speedText.SetText("speed: " + Mathf.Floor(kmh));
        boostAmountText.SetText("boost: "+ Math.Floor(spacecraftNavigation.GetBoostAmount()));

        if (avengerI.IsSkillActivated()==false && avengerI.GetSkillCooldown() == avengerI.GetMaxSillCooldown())
        {
            powerfulCannonText.SetText("powerful cannon: ready");
        }
        else if (avengerI.IsSkillActivated())
        {
            powerfulCannonText.SetText("powerful cannon: activated");
        }
        else
        {
            powerfulCannonText.SetText("powerful cannon: recharging");
        }


    }

    public void SetSpacecraftAvenger(GameObject spacecraft)
    {
        spacecraftRigidbody = spacecraft.GetComponent<Rigidbody>();
        spacecraftNavigation = spacecraft.GetComponent<SpacecraftNavigation>();
        avengerI = spacecraft.GetComponent<AvengerI>();
        speedText = GameObject.Find("SpacecraftSpeedText").GetComponent<TMPro.TextMeshProUGUI>();
        boostAmountText = GameObject.Find("SpacecraftBoostText").GetComponent <TMPro.TextMeshProUGUI>();
        powerfulCannonText = GameObject.Find("PowerfulCannonInfoText").GetComponent<TMPro.TextMeshProUGUI>();



    }
        
}
