using Stats.Health;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private EnemyAI _enemyAI;
    private void DamageMelee(PlayerStats _playerStats)
    {
        var stats = _playerStats.gameObject.GetComponent<PlayerStats>();
        stats.Health -= _enemyAI.currentAttackDamage;
    }
}
