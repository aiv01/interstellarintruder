using Stats.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon.Projectile
{
    public class BulletEnemy : Bullet
    {
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= lifetime)
                Die();
            transform.position += transform.forward * bulletSpeed * Time.deltaTime;
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