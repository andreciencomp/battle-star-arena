using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour
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

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rig.AddForce(thurst * transform.forward);
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

    
}
