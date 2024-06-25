using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerI : MonoBehaviour,ISpacecraftInterface
{
    [SerializeField]
    private float timeToNextNormalShoot = 0.5f;
    [SerializeField]
    private float timeToNextPowerfulShoot = 0.4f;
    private float normalShootTimer;
    private float powerfulShootTimer;
    private bool readyToNormalShoot;
    private bool powerfullCannonReady;
    [SerializeField]
    private float normalShootDamage = 2;
    [SerializeField]
    private float powerfulShootDamage = 2;
    [SerializeField]
    private Transform mainCannonLeftSpawnPoint;
    [SerializeField]
    private Transform mainCannonRightSpawnPoint;
    [SerializeField]
    private BulletBehaviour normalCannonBullet;
    [SerializeField]
    private BulletBehaviour powerfulCannonBullet;
    [SerializeField]
    private Transform powerfulCannonLeftSpawnPoint;
    [SerializeField]
    private Transform powerfulCannonRightSpawnPoint;
    private int mainCannonSelected;
    private int powerfulCannonSelected;
    [SerializeField]
    private float normalShootSpeed = 500;
    [SerializeField]
    private float powerfulShootSpeed = 600;
    [SerializeField]
    private float maxSkillTimer = 10;
    private float skillTimer;
    [SerializeField]
    private float maxSkillCooldown = 360;
    private float skillCooldown;
    private bool skillActivated;

    
    void Start()
    {
        mainCannonSelected = 1;
        powerfulCannonSelected = 1;
        normalShootTimer = timeToNextNormalShoot;
        powerfulShootTimer = timeToNextPowerfulShoot;
        readyToNormalShoot = true;
        powerfullCannonReady = true;
        skillActivated = false;
        skillTimer = maxSkillTimer;
        skillCooldown = maxSkillCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(normalShootTimer <= 0)
        {
            normalShootTimer = timeToNextNormalShoot;
            readyToNormalShoot = true;
            mainCannonSelected = (mainCannonSelected == 1) ? 0 : 1;

        }
        if(!readyToNormalShoot )
        {
            normalShootTimer -=  1 * Time.deltaTime;
        }

        if (powerfulShootTimer <= 0)
        {
            powerfulShootTimer = timeToNextPowerfulShoot;
            powerfullCannonReady = true;
            powerfulCannonSelected = (powerfulCannonSelected == 1) ? 0 : 1;

        }
        if (!powerfullCannonReady)
        {
            powerfulShootTimer -= 1 * Time.deltaTime;
        }

        if (skillActivated)
        {
            skillTimer -= Time.deltaTime;
            if(skillTimer <= 0)
            {
                skillCooldown = maxSkillCooldown;
                skillActivated = false;
            }
        }
        if (skillTimer <= 0)
        {
            skillCooldown -= Time.deltaTime;
        }
        if(skillCooldown <= 0)
        {
            skillCooldown = maxSkillCooldown;
            skillTimer = maxSkillTimer;
            skillActivated = false;
        }

    }

    public bool IsSkillActivated()
    {
        return skillActivated;
    }

    public float GetMaxSillCooldown()
    {
        return maxSkillCooldown;
    }

    public float GetSkillCooldown()
    {
        return skillCooldown;
    }

    public void NormalShot()
    {
        if ( readyToNormalShoot )
        {
            readyToNormalShoot = false;
            if( mainCannonSelected == 1)
            {  
                if (PhotonNetwork.IsConnected)
                {
                    GameObject bullet = PhotonNetwork.Instantiate("Cannon Bullet blue", mainCannonLeftSpawnPoint.position, mainCannonLeftSpawnPoint.rotation);
                    BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
                    bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                    bulletBehaviour.SetProjectileSpeed(normalShootSpeed);
                    bulletBehaviour.SetDamage(normalShootDamage);
                }
                else
                {
                    BulletBehaviour bulletBehaviour = Instantiate(normalCannonBullet, mainCannonLeftSpawnPoint.position, mainCannonLeftSpawnPoint.rotation);
                    bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                    bulletBehaviour.SetProjectileSpeed(normalShootSpeed);
                    bulletBehaviour.SetDamage(normalShootDamage);
                }
                

            }
            else
            {
                if (PhotonNetwork.IsConnected)
                {
                    GameObject bullet = PhotonNetwork.Instantiate("Cannon Bullet blue", mainCannonRightSpawnPoint.position, mainCannonRightSpawnPoint.rotation);
                    BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
                    bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                    bulletBehaviour.SetProjectileSpeed(normalShootSpeed);
                    bulletBehaviour.SetDamage(normalShootDamage);
                }
                else
                {
                    BulletBehaviour bulletBehaviour2 = Instantiate(normalCannonBullet, mainCannonRightSpawnPoint.position, mainCannonRightSpawnPoint.rotation);
                    bulletBehaviour2.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                    bulletBehaviour2.SetProjectileSpeed(normalShootSpeed);
                    bulletBehaviour2.SetDamage(normalShootDamage);
                }
                
            }
            
        }

        if (skillActivated)
        {
            if (powerfullCannonReady)
            {
                powerfullCannonReady = false;
                if (powerfulCannonSelected == 1)
                {
                    if (PhotonNetwork.IsConnected)
                    {
                        GameObject bullet = PhotonNetwork.Instantiate("Cannon Bullet red", mainCannonLeftSpawnPoint.position, mainCannonLeftSpawnPoint.rotation);
                        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
                        bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                        bulletBehaviour.SetProjectileSpeed(powerfulShootSpeed);
                        bulletBehaviour.SetDamage(powerfulShootDamage);
                    }
                    else
                    {
                    BulletBehaviour bulletBehaviour = Instantiate(powerfulCannonBullet, powerfulCannonLeftSpawnPoint.position, powerfulCannonLeftSpawnPoint.rotation);
                    bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                    bulletBehaviour.SetProjectileSpeed(powerfulShootSpeed);
                    bulletBehaviour.SetDamage(powerfulShootDamage);
                    }

                }
                else
                {
                    if (PhotonNetwork.IsConnected)
                    {
                        GameObject bullet = PhotonNetwork.Instantiate("Cannon Bullet red", mainCannonRightSpawnPoint.position, mainCannonRightSpawnPoint.rotation);
                        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
                        bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                        bulletBehaviour.SetProjectileSpeed(powerfulShootSpeed);
                        bulletBehaviour.SetDamage(powerfulShootDamage);
                    }
                    else
                    {
                        BulletBehaviour bulletBehaviour2 = Instantiate(powerfulCannonBullet, powerfulCannonRightSpawnPoint.position, powerfulCannonRightSpawnPoint.rotation);
                        bulletBehaviour2.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
                        bulletBehaviour2.SetProjectileSpeed(powerfulShootSpeed);
                        bulletBehaviour2.SetDamage(powerfulShootDamage);
                    }

                    
                }

            }
        }


    }

    public void ActivateSkill()
    {
        if(skillCooldown == maxSkillCooldown && !skillActivated)
        {
            skillActivated = true;
        }
    }

    public void ActivateSpecial()
    {

    }

    



}
