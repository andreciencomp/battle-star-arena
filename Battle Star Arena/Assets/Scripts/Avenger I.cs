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
    private Rigidbody rigSpacecraft;


    
    void Start()
    {
        rigSpacecraft = GetComponent<Rigidbody>();
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
        Spacecraft spacecraft = GetComponent<Spacecraft>();
        Debug.Log(spacecraft.GetHP());
        
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
    [PunRPC]
    public void InstantiateNormalBulletLeft(PhotonMessageInfo info)
    {
        float delta = Mathf.Abs((float) (PhotonNetwork.Time - info.SentServerTime));
        BulletBehaviour bulletBehaviour = Instantiate(normalCannonBullet, mainCannonLeftSpawnPoint.position, mainCannonLeftSpawnPoint.rotation);
        Rigidbody rigBullet = bulletBehaviour.gameObject.GetComponent<Rigidbody>();
        rigBullet.position += rigSpacecraft.velocity * delta; 
        bulletBehaviour.SetShooterSpeed(rigSpacecraft.velocity.magnitude);
        bulletBehaviour.SetProjectileSpeed(normalShootSpeed);
        bulletBehaviour.SetDamage(normalShootDamage);

    }
    public void InstantiateNormalBulletLeft()
    {
        BulletBehaviour bulletBehaviour = Instantiate(normalCannonBullet, mainCannonLeftSpawnPoint.position, mainCannonLeftSpawnPoint.rotation);
        bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
        bulletBehaviour.SetProjectileSpeed(normalShootSpeed);
        bulletBehaviour.SetDamage(normalShootDamage);
    }
    [PunRPC]
    public void InstantiateNormalBulletRight(PhotonMessageInfo info)
    {
        float delta = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
        BulletBehaviour bulletBehaviour = Instantiate(normalCannonBullet, mainCannonRightSpawnPoint.position, mainCannonRightSpawnPoint.rotation);

        Rigidbody rigBullet = bulletBehaviour.gameObject.GetComponent<Rigidbody>();
        rigBullet.position += rigSpacecraft.velocity * delta;
        bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
        bulletBehaviour.SetProjectileSpeed(normalShootSpeed);
        bulletBehaviour.SetDamage(normalShootDamage);

       
    }
    public void InstantiateNormalBulletRight()
    {
        BulletBehaviour bulletBehaviour = Instantiate(normalCannonBullet, mainCannonRightSpawnPoint.position, mainCannonRightSpawnPoint.rotation);
        bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
        bulletBehaviour.SetProjectileSpeed(normalShootSpeed);
        bulletBehaviour.SetDamage(normalShootDamage);
    }
    [PunRPC]
    public void InstantiatePowerfulBulletLeft(PhotonMessageInfo info)
    {
        float delta = (float)(PhotonNetwork.Time - info.SentServerTime);
        BulletBehaviour bulletBehaviour = Instantiate(powerfulCannonBullet, powerfulCannonLeftSpawnPoint.position * Mathf.Abs(delta), powerfulCannonLeftSpawnPoint.rotation);
        bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
        bulletBehaviour.SetProjectileSpeed(powerfulShootSpeed);
        bulletBehaviour.SetDamage(powerfulShootDamage);
    }
    public void InstantiatePowerfulBulletLeft()
    {
        BulletBehaviour bulletBehaviour = Instantiate(powerfulCannonBullet, powerfulCannonLeftSpawnPoint.position, powerfulCannonLeftSpawnPoint.rotation);
        bulletBehaviour.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
        bulletBehaviour.SetProjectileSpeed(powerfulShootSpeed);
        bulletBehaviour.SetDamage(powerfulShootDamage);
    }
    [PunRPC]
    public void InstantiatePowerfulBulletRight(PhotonMessageInfo info)
    {
        float delta = (float)(PhotonNetwork.Time - info.SentServerTime);
        BulletBehaviour bulletBehaviour2 = Instantiate(powerfulCannonBullet, powerfulCannonRightSpawnPoint.position * delta, powerfulCannonRightSpawnPoint.rotation);
        bulletBehaviour2.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
        bulletBehaviour2.SetProjectileSpeed(powerfulShootSpeed);
        bulletBehaviour2.SetDamage(powerfulShootDamage);
    }
    public void InstantiatePowerfulBulletRight()
    {
        BulletBehaviour bulletBehaviour2 = Instantiate(powerfulCannonBullet, powerfulCannonRightSpawnPoint.position, powerfulCannonRightSpawnPoint.rotation);
        bulletBehaviour2.SetShooterSpeed(GetComponent<Rigidbody>().velocity.magnitude);
        bulletBehaviour2.SetProjectileSpeed(powerfulShootSpeed);
        bulletBehaviour2.SetDamage(powerfulShootDamage);
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
                    GetComponent<PhotonView>().RPC("InstantiateNormalBulletLeft", RpcTarget.All);
                }
                else
                {
                    InstantiateNormalBulletLeft();
                }
            }
            else
            {
                if (PhotonNetwork.IsConnected)
                {
                    GetComponent<PhotonView>().RPC("InstantiateNormalBulletRight", RpcTarget.All);
                }
                else
                {
                    InstantiateNormalBulletRight();
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
                        GetComponent<PhotonView>().RPC("InstantiatePowerfulBulletLeft",RpcTarget.All);
                    }
                    else
                    {
                        InstantiatePowerfulBulletLeft();
                    }

                }
                else
                {
                    if (PhotonNetwork.IsConnected)
                    {
                        GetComponent<PhotonView>().RPC("InstantiatePowerfulBulletRight",RpcTarget.All);
                    }
                    else
                    {
                        InstantiatePowerfulBulletRight();
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
