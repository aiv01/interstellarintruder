using Stats.Health;
using UnityEngine;

namespace Weapon.Projectile
{
    public class Bullet : MonoBehaviour
    {
        public delegate void BulletDelegate(Bullet bulletDeath);
        public event BulletDelegate OnDeath = null;

        #region Protected variables
        protected float bulletSpeed = 1.0f;
        protected float lifetime = 5.0f;
        protected float timer = 0.0f;
        private float bulletDamage = 2.0f;
        #endregion

        void OnDisable()
        {
            timer = 0.0f;
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
            if(other.gameObject.tag == "Enemy")
            {
                Die();
                var enemy = other.gameObject.GetComponent<EnemyAI>();
                enemy.stats.healthPoint -= ((bulletDamage * enemy.stats.attackDamage / 100) + bulletDamage);
            }
        }

        protected void Die()
        {
            OnDeath?.Invoke(this);
        }
    }
}
