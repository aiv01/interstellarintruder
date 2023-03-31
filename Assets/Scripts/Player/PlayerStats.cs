using Stats.Health;
using UnityEngine;

public class PlayerStats : StatsModule
{
    #region Speed Attack Variable - Property
    //Attack Speed
    private readonly float maxAttackSpeed = 20.0f;
    private float currentAttackSpeed = 1.0f;
    public float SpeedAttack
    {
        get => currentAttackSpeed;
        set
        {
            if (value > maxAttackSpeed) return;
            currentAttackSpeed = value;
        }
    }
    #endregion

    #region Speed Movement Variable - Property
    //Speed Movement
    private readonly float maxSpeedMovement = 20.0f;
    private float currentSpeedMovement = 1.0f;
    public float SpeedMovement
    {
        get => currentSpeedMovement;
        set
        {
            if (value > maxSpeedMovement) return;
            currentSpeedMovement = value;
        }
    }
    #endregion
}
