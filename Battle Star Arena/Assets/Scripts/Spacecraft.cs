using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour
{
    [SerializeField]
    private string pilotName;
    [SerializeField]
    private string spacecraftName;
    [SerializeField]
    private int side;
    [SerializeField]
    private float maxShield = 100;
    private float shield;
    [SerializeField]
    private float maxHP = 100;
    private float hp;
    [SerializeField]
    private string state="SPAWNED";
    [SerializeField]
    private GameObject explosionPrefab;

    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("side: "+ side + "player: " + PhotonNetwork.LocalPlayer.NickName +  "-HP: " + hp);
        if(hp <= 0 && state == "FLYING")
        {
            if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
            {
                GetComponent<PhotonView>().RPC("Explode", RpcTarget.All);
                state = "DESTROYED";
            }
            else
            {
                Explode();
                state = "DESTROYED";
            }
            
        }
        
    }

    public string GetState()
    {
        return state;
    }

    public void SetState(string state)
    {
        this.state = state;
    }

    public string GetPilotName()
    {
        return pilotName;
    }

    public void SetPilotName(string pilotName)
    {
        this.pilotName = pilotName;
    }

    public string GetSpacecraftName()
    {
        return spacecraftName;
    }

    public int GetSide()
    {
        return side;
    }

    public void SetSide(int side)
    {
        this.side = side;
    }
    
    public float GetMaxShield()
    {
        return maxShield;
    }

    public float GetCurrentShield()
    {
        return shield;
    }

    public float GetShield()
    {
        return shield;
    }

    public void IncreaseShield(float amount)
    {
        shield = shield + amount > maxShield ? maxShield : shield + amount;    
    }

    public void DecreaseShield(float amount)
    {
        shield = shield - amount < 0 ? 0 : shield - amount;
    }

    public float GetHP()
    {
        return hp;
    }

    public void IncreaseHP(float amount)
    {
        hp = hp + amount > maxHP ? maxHP : hp + amount;
    }

    public void DecreaseHP(float amount)
    {
        hp = hp - amount < 0 ? 0 :hp - amount;
    }
    [PunRPC]
    public void GetDamage(float amount)
    {
        if(shield - amount < 0)
        {
            shield = 0;
            DecreaseHP(amount - shield);
        }
        else
        {
            DecreaseShield(amount);
        }
        
    }
    [PunRPC]
    public void Explode()
    {
        this.gameObject.SetActive(false);
        GameObject.Instantiate(explosionPrefab, transform.position, transform.rotation);

    }
    
    public void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.GetComponent<BulletBehaviour>()!= null)
        {
            GetComponent<PhotonView>().RPC("GetDamage", RpcTarget.All,10f);
           
        }
    }

    



}
