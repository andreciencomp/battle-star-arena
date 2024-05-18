using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerI : MonoBehaviour
{

    [SerializeField]
    private float timeToNextShot = 0.5f;
    private float shotTimer;
    private bool readyToShoot;
    [SerializeField]
    Transform mainCannonLeftSpawnPoint;
    [SerializeField]
    private BulletBehaviour bullet1;
    
    void Start()
    {
        shotTimer = timeToNextShot;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(shotTimer <= 0)
        {
            shotTimer = timeToNextShot;
            readyToShoot = true;
        }
        if(!readyToShoot )
        {
            shotTimer -=  1 * Time.deltaTime;
        }
        
       
    }

    public void NormalShot()
    {
        if ( readyToShoot )
        {
            readyToShoot = false;
            
            BulletBehaviour bulletBehaviour = Instantiate(bullet1, mainCannonLeftSpawnPoint.position, mainCannonLeftSpawnPoint.rotation);
            bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
            bulletBehaviour.SetUsername("namcexxx");
        }
    }

    public void ActivateSkill()
    {

    }

    public void ActivateSpecial()
    {

    }


}
