using UnityEngine;
using Weapon.Projectile;

namespace Weapon.Shoot
{
    public class ShootingEnemy : MonoBehaviour
    {
        #region SerializeField
        [SerializeField]
        private Vector3 mouthOfFire;
        #endregion

        #region Private variable
        private BulletPool bulletPool = null;
        private float shootCoolDown = 2.5f;
        private float lastFire = -10.0f;
        #endregion

        public BulletPool BulletPool
        {
            get
            {
                if (bulletPool == null)
                    bulletPool = GameObject.Find("BulletPool Enemy").GetComponent<BulletPool>();
                return bulletPool;
            }
        }

        public void ShootEnemy()
        {
            Bullet instance = BulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.forward = transform.forward;
        }
    }
}
