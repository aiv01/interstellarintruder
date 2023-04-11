using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Health Variable - Property
    //Health Point
    protected float maxHP = 100f;
    protected float totalHP = 20f;
    protected float health;
    public float Health
    {
        get => health;
        set
        {
            if (value + totalHP > maxHP) return;
            if (value + health > maxHP)
                health = maxHP;
            else
                health = value;
            totalHP = value;
        }
    }
    #endregion

    #region Damage Variable - Property
    //Attack Damage
    protected float maxDamage = 20f;
    protected float damage = 2f;
    [SerializeField] Save saves;
    public float Damage
    {
        get => damage;
        set
        {
            if (value + damage > maxDamage) return;
            damage = value;
        }
    }
    #endregion

    #region Speed Attack Variable - Property
    //Attack Speed
    private readonly float maxAttackSpeed = 2.0f;
    private float currentAttackSpeed = .5f;
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
    private readonly float maxSpeedMovement = 2.0f;
    private float currentSpeedMovement = .1f;
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

    private void Start()
    {
        if(health<= 0)
        health = totalHP;
    }
    private void OnEnable()
    {
        saves.LoadStats();
    }
}
