using UnityEngine;

namespace Weapon.Projectile
{
    public class BulletEnemy : Bullet
    {
        PlayerMovement _playerTarget;
        Vector3 offSetY = new Vector3(0, 1f);
        private void Awake()
        {
            _playerTarget = GameObject.Find("Ellen").GetComponent<PlayerMovement>();
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= lifetime)
                Die();
            var targetPos = _playerTarget.transform.position + offSetY;
            transform.LookAt(targetPos);
            transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                var stats = other.gameObject.GetComponent<PlayerStats>();
                stats.Health -= bulletDamage;
                if (_playerTarget.IsDeath)
                    _playerTarget.Death();
                else
                    _playerTarget.HurtDirection(transform);
            }
            Die();
        }
    }
}