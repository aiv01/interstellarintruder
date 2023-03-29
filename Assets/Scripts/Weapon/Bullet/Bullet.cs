using Stats.Health;
using UnityEngine;

namespace Weapon.Projectile
{
    public class Bullet : MonoBehaviour
    {
        public delegate void BulletDelegate(Bullet bulletDeath);
        public event BulletDelegate OnDeath = null;

        #region Private variables
        private float moveSpeed = 1.0f;
        private float lifetime = 5.0f;
        private float age = 0.0f;
        private float bulletDamage = 2.0f;
        #endregion

        void OnDisable()
        {
            age = 0.0f;
        }

        void Update()
        {
            age += Time.deltaTime;
            if (age >= lifetime)
                Die();
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
            {
                Die();
                var stats = other.gameObject.GetComponent<StatsModule>();
                stats.Health -= ((bulletDamage * stats.Damage / 100) + bulletDamage);
            }
        }

        private void Die()
        {
            OnDeath?.Invoke(this);
        }
    }
}
