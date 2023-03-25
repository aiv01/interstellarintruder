using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon.Projectile;

namespace Weapon
{
    public class Gun : MonoBehaviour
    {
        #region SerializeField 
        [SerializeField]
        private Transform _handPlayer;
        [SerializeField]
        private Transform _gunHoldPosition;
        [SerializeField]
        private BulletPool bulletPool = null;
        [SerializeField]
        private Vector3 mouthOfFire = Vector3.zero;
        #endregion

        #region Private Variable
        private float shootCoolDown = 0.2f;
        private float lastFire = -10.0f;
        private float reloadTime = 5.0f;
        private float counterReload = 0;
        private int ammo = 7;
        private int counterAmmo;
        #endregion

        #region Propriety
        private bool isRanged = false;
        public bool IsRanged
        {
            get => isRanged;
            set { isRanged = value; }
        }
        #endregion

        private void Start()
        {
            counterAmmo = ammo;
        }

        void Update()
        {
            if (IsRanged)
                GunPosition();
            else
            {
                transform.position = _gunHoldPosition.position;
                transform.rotation = _gunHoldPosition.rotation;
            }

            if(counterAmmo < 0)
            {
                counterReload += Time.deltaTime;
                if (counterReload > reloadTime)
                {
                    counterAmmo = ammo;
                    counterReload = 0;
                }
            }
        }

        #region Private Method
        private void GunPosition()
        {
            transform.position = _handPlayer.transform.position;
            transform.right = _handPlayer.transform.right;
        }

        private void Shoot()
        {
            if (Time.time < lastFire + shootCoolDown)
                return;
            lastFire = Time.time;

            Bullet instance = bulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.rotation = _handPlayer.transform.rotation;
        }
        #endregion

        public bool CountAmmo()
        {
            counterAmmo--;
            if (counterAmmo >= 0)
                Shoot();
            
            return counterAmmo >= 0;
        }
    }
}
