using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using Weapom.Projectile;

namespace Weapom
{
    public class Gun : MonoBehaviour
    {
        #region SerializeField 
        [SerializeField]
        private GameObject _player;
        [SerializeField]
        private Transform targetPosition;
        [SerializeField]
        private BulletPool bulletPool = null;
        [SerializeField]
        private Vector3 mouthOfFire = Vector3.zero;
        #endregion

        #region Private Variable
        private float shootCoolDown = 0.2f;
        private float lastFire = -10.0f;
        #endregion

        void Update()
        {
            GunForward();
        }

        #region Private Method
        private void GunForward()
        {
            transform.position = targetPosition.position;
            transform.right = _player.transform.forward;
        }

        public void Shoot()
        {
            if (Time.time < lastFire + shootCoolDown)
                return;
            lastFire = Time.time;

            Bullet instance = bulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.rotation = _player.transform.rotation;
        }
        #endregion
    }
}
