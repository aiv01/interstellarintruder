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
                Die();
                var stats = other.gameObject.GetComponent<PlayerStats>();
                stats.Health -= bulletDamage;
            }
        }
    }
}