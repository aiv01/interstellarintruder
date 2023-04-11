using UnityEngine;

namespace Weapon
{
    public class Staff : MonoBehaviour
    {
        PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                var enemy = other.gameObject.GetComponent<EnemyAI>();
                enemy.currentHp -= _playerStats.Damage;
            }
        }
    }
}
