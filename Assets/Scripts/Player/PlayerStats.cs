using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    [Range(10.0f, 100.0f)]
    private float hp = 10f;
    [SerializeField]
    [Range(1.0f, 50.0f)]
    private float attackDamage = 2f;
    [SerializeField]
    [Range(0.1f, 10.0f)]
    private float attackSpeed = 0.1f;
    [SerializeField]
    [Range(0.1f, 10.0f)]
    private float speedMovement = 1f;
    #endregion

    void Update()
    {
        
    }
}
