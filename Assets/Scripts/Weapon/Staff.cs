using UnityEngine;

namespace Weapon
{
    public class Staff : MonoBehaviour
    {
        #region Property
        private float damage = 2.0f;
        public float Damage
        {
            get => damage;
        }
        #endregion

        PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GetComponentInParent<PlayerStats>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hit Collider Staff");
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit Melee");
                var enemy = other.gameObject.GetComponent<EnemyAI>();
                enemy.currentHp -= ((damage * _playerStats.Damage / 100) + damage);
            }
        }
    }
}
