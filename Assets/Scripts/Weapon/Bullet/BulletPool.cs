using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon.Projectile
{
    public class BulletPool : MonoBehaviour
    {
        #region SerializeField
        [SerializeField]
        private Bullet bulletPrefab = null;
        #endregion

        #region Private Variable
        private int poolSize = 50;
        private List<Bullet> pool = new List<Bullet>();
        #endregion

        void Awake()
        {
            FillPool();
        }

        public Bullet GetBullet()
        {
            Bullet val = null;
            foreach (Bullet projectile in pool)
                if (!projectile.gameObject.activeSelf)
                {
                    val = projectile;
                    break;
                }
            if (val == null)
                val = CreateInstance();
            val.gameObject.SetActive(true);
            return val;
        }

        private void FillPool()
        {
            for (int i = 0; i < poolSize; i++)
                CreateInstance();
        }

        private Bullet CreateInstance()
        {
            Bullet instance = Instantiate<Bullet>(bulletPrefab);
            instance.gameObject.SetActive(false);
            instance.transform.SetParent(transform);
            instance.OnDeath += HandleBulletDeath;
            pool.Add(instance);
            return instance;
        }

        private void HandleBulletDeath(Bullet bulletDeath)
        {
            bulletDeath.gameObject.SetActive(false);
            bulletDeath.transform.SetParent(transform);
        }
    }
}
