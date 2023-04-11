using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    EnemyAI _enemyAI;
    PlayerMovement _playerTarget;

    private void Awake()
    {
        _enemyAI = GetComponentInParent<EnemyAI>();
        _playerTarget = GameObject.Find("Ellen").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            var stats = other.gameObject.GetComponent<PlayerStats>();
            stats.Health -= _enemyAI.currentAttackDamage;
            if (_playerTarget.IsDeath)
                _playerTarget.Death();
            else
                _playerTarget.HurtDirection(transform);
        }
    }
}
