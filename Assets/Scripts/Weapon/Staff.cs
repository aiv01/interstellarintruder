using Stats.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Staff : MonoBehaviour
    {
        #region
        [SerializeField]
        private Transform staffHandPos;
        #endregion

        #region Property
        private float damage = 2.0f;
        public float Damage
        {
            get => damage;
        }
        #endregion

        void Update()
        {
            transform.position = staffHandPos.position;
            transform.rotation = staffHandPos.rotation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                var enemy = other.gameObject.GetComponent<EnemyAI>();
                enemy.stats.healthPoint-= ((damage * enemy.stats.attackDamage / 100) + damage);
            }
        }
    }
}
