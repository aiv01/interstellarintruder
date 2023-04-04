using UnityEngine;

namespace Weapon.Projectile
{
    public class Bullet : MonoBehaviour
    {
        public delegate void BulletDelegate(Bullet bulletDeath);
        public event BulletDelegate OnDeath = null;

        #region Protected variables
        protected float bulletSpeed = 5.0f;
        protected float lifetime = 3.0f;
        protected float timer = 0.0f;
        protected float bulletDamage = 2.0f;
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
                var enemy = other.gameObject.GetComponent<EnemyAI>();
                enemy.currentHp -= bulletDamage;
                enemy.Hitted = true;
            }
            Die();
        }

        protected void Die()
        {
            OnDeath?.Invoke(this);
        }
    }
}
