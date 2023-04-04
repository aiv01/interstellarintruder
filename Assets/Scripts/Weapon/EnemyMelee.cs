using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    EnemyAI _enemyAI;
    PlayerStats _playerStats;

    private void Awake()
    {
        _enemyAI = GetComponentInParent<EnemyAI>();
        _playerStats = GameObject.Find("Ellen").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            var stats = _playerStats.gameObject.GetComponent<PlayerStats>();
            stats.Health -= _enemyAI.currentAttackDamage;
        }
    }
}
