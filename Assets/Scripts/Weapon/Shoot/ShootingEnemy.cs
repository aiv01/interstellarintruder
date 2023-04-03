using UnityEngine;
using Weapon.Projectile;

namespace Weapon.Shoot
{
    public class ShootingEnemy : MonoBehaviour
    {
        #region SerializeField
        [SerializeField]
        private BulletPool bulletPool = null;
        [SerializeField]
        private Vector3 mouthOfFire;
        #endregion

        #region Private variable
        private float shootCoolDown = 2.5f;
        private float lastFire = -10.0f;
        #endregion

        public void ShootEnemy()
        {
            if (Time.time < lastFire + shootCoolDown)
                return;
            lastFire = Time.time;
            Bullet instance = bulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.forward = transform.forward;
        }
    }
}
