using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Private variable
    //Health Point
    private readonly float maxHP = 100.0f;
    private float totalHP = 10.0f;
    private float currentHP;
    //Attack Damage
    private readonly float maxAttackDamage = 50.0f;
    private float currentAttackDamage = 2.0f;
    //Attack Speed
    private readonly float maxAttackSpeed = 20.0f;
    private float currentAttackSpeed = 1.0f;
    //Speed Movement
    private readonly float maxSpeedMovement = 20.0f;
    private float currentSpeedMovement = 1.0f;
    #endregion

    #region Propriety
    public float HP
    {
        get { return totalHP; }
        set 
        {
            if (value > maxHP) return;
            totalHP = value;
            currentHP = value;
        }
    }
    public float Attack
    {
        get { return currentAttackDamage; }
        set 
        {
            if(value > maxAttackDamage) return;
            currentAttackDamage = value;
        }
    }
    public float SpeedMovement
    {
        get { return currentSpeedMovement; }
        set 
        {
            if(value > maxSpeedMovement) return;
            currentSpeedMovement = value;
        }
    }
    public float SpeedAttack
    {
        get { return currentAttackSpeed; }
        set 
        {
            if (value > maxAttackSpeed) return;
            currentAttackSpeed = value;
        }
    }
    #endregion

    private void Start()
    {
        currentHP = totalHP;
    }
}
