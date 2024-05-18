using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 500;
    [SerializeField]
    private float maximumRange = 800;
    private Vector3 shotPosition;
    private Rigidbody rig;
    [SerializeField]
    private float damage = 5;
    private string username = "unknown";
    private float shooterSpeed;
    
       

    void Start()
    {
        shotPosition = transform.position;
        rig = GetComponent<Rigidbody>();
       // rig.velocity = (speed + shooterSpeed)  * transform.forward;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        rig.velocity = (speed + shooterSpeed) * transform.forward;
        if (Vector3.Distance(shotPosition, transform.position) > maximumRange)
        {
            Destroy(this.gameObject);

        }
        Debug.Log("shooter speed: " + shooterSpeed);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public string GetUsername()
    {
        return username;
    }

    public void SetUsername(string username)
    {
        this.username = username;
    }

    public float GetShooterSpeed()
    {
        return shooterSpeed;
    }

    public void SetShooterSpeed(float speed)
    {
        shooterSpeed = speed;
    } 
}
