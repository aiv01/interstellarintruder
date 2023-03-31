using Stats.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon.Projectile
{
    public class BulletEnemy : Bullet
    {
        #region Private variables
        private float bulletDamage = 2.0f;
        #endregion


        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= lifetime)
                Die();
            transform.LookAt(transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Hit " + other.gameObject.tag);
                Die();
                var stats = other.gameObject.GetComponent<StatsModule>();
                stats.Health -= ((bulletDamage * stats.Damage / 100) + bulletDamage);
            }
        }
    }
}