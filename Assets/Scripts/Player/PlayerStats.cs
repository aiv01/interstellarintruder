using Stats.Health;
using UnityEngine;

public class PlayerStats : StatsModule
{
    #region Private variable
    //Attack Speed
    private readonly float maxAttackSpeed = 20.0f;
    private float currentAttackSpeed = 1.0f;
    //Speed Movement
    private readonly float maxSpeedMovement = 20.0f;
    private float currentSpeedMovement = 1.0f;
    #endregion

    #region Property
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
}
