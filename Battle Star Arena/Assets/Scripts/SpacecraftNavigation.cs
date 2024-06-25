using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftNavigation : MonoBehaviour
{
    private Rigidbody rig;
    private float rollAxis;
    private float pitchAxis;
    private float yawAxis;

    [SerializeField]
    private float rollForce = 5;
    [SerializeField]
    private float pithForce = 5;
    [SerializeField]
    private float yawForce = 1;
    [SerializeField]
    private float thurst = 500;
    [SerializeField]
    private float maxBoostStrength = 500;
    [SerializeField]
    private float boostIncrementRate = 100;
    private float boostStrength;
    private bool boostActivated;
    [SerializeField]
    private float maxBoostAmount = 100;
    [SerializeField]
    private float boostAmountConsumitonRate = 20;
    [SerializeField]
    private float boostAmountRechargeRate = 20;
    private float boostAmount;
    private bool boostReady;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        boostStrength = 0;
        boostAmount = 0;
        boostReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (boostActivated && boostReady)
        {
            boostStrength = (boostStrength + boostIncrementRate * Time.deltaTime) >= maxBoostStrength ? maxBoostStrength : boostStrength + boostIncrementRate * Time.deltaTime;
            boostAmount -= boostAmountConsumitonRate * Time.deltaTime;
            if(boostAmount <= 0)
            {
                boostAmount = 0;
                boostReady = false;
                boostStrength = 0;
            }  
        }

        if (!boostActivated && boostStrength > 0)
        {
            boostReady = false;
            boostStrength = 0;
        }

        

        if((boostAmount < maxBoostAmount) && boostReady == false)
        {
            boostAmount = boostAmount + (boostAmountRechargeRate * Time.deltaTime);
            if(boostAmount >= maxBoostAmount)
            {
                boostAmount = maxBoostAmount;
                boostReady = true;
            }
        }

        //Debug.Log("boostReady: " + boostReady + " boostAmount: " + boostAmount + " boostStrength: " +  boostStrength + " boostActivated: " + boostActivated);

    }

    private void FixedUpdate()
    {
        

        rig.AddForce((thurst + boostStrength) * transform.forward);
        rig.AddTorque(- rollAxis * rollForce * transform.forward);
        rig.AddTorque(- pitchAxis * pithForce * transform.right);
        rig.AddTorque(yawAxis * yawForce * transform.up);
        
    }

    public float GetRollAxis()
    {
        return rollAxis;
    }

    public void SetRollAxis(float rollAxis)
    {
        this.rollAxis = rollAxis;
    }

    public float GetPithAxis()
    {
        return pitchAxis;
    }

    public void SetPithAxis(float pitchAxis)
    {
        this.pitchAxis = pitchAxis;
    }

    public float GetYawAxis()
    {
        return yawAxis;
    }

    public void SetYawAxis(float yawAxis)
    {
        this.yawAxis = yawAxis;
    }

    public float GetThurst()
    {
        return thurst;
    }

    public bool IsBoostReady()
    {
        return boostReady;
    }

    public bool GetBoostActivated()
    {
        return boostActivated;
    }

    public void SetBoostActivated(bool boostActivated)
    {
        this.boostActivated = boostActivated;
    }

    public float GetBoostAmount()
    {
        return boostAmount;
    }

    public void SetBoostAmount(float boostAmount)
    {
        this.boostAmount = boostAmount;
    }

 

    
}
