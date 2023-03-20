using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapom.Projectile
{
    public class BulletPool : MonoBehaviour
    {
        #region SerializeField
        [SerializeField]
        private Bullet bulletPrefab = null;
        #endregion

        #region Private Variable
        private int poolSize = 7;
        private List<Bullet> pool = new List<Bullet>();
        #endregion

        void Awake()
        {
            FillPool();
        }

        public Bullet GetBullet()
        {
            Bullet retval = null;
            foreach (Bullet projectile in pool)
                if (!projectile.gameObject.activeSelf)
                {
                    retval = projectile;
                    break;
                }
            if (retval == null)
                retval = CreateInstance();
            retval.gameObject.SetActive(true);
            retval.transform.SetParent(null);
            return retval;
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
