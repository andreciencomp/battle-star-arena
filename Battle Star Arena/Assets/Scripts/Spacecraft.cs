using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour
{
    [SerializeField]
    private string spacecraftName;
    [SerializeField]
    private int side;
    [SerializeField]
    private float maxShield = 1000f;
    private float shield;
    [SerializeField]
    private float maxHP = 1000;
    private float hp;

    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
