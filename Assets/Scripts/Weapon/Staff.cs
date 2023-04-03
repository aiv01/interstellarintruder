using Stats.Health;
using System.Collections;
using System.Collections.Generic;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                var enemy = other.gameObject.GetComponent<EnemyAI>();
                enemy.currentHp -= ((damage * enemy.stats.attackDamage / 100) + damage);
            }
        }
    }
}
