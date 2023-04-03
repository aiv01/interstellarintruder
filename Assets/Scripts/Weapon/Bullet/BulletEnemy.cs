using Stats.Health;
using UnityEngine;

namespace Weapon.Projectile
{
    public class BulletEnemy : Bullet
    {
        private void Start()
        {
        }

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
                Die();
                var stats = other.gameObject.GetComponent<StatsModule>();
                stats.Health -= ((bulletDamage * stats.Damage / 100) + bulletDamage);
            }
        }
    }
}