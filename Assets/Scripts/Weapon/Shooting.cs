using UnityEngine;
using Weapon.Projectile;

namespace Weapon
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField]
        private BulletPool bulletPool = null;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private Vector3 mouthOfFire;

        private Camera _camera;
        private PlayerMgr _playerMgr;
        private float shootCoolDown = 0.2f;
        private float lastFire = -10.0f;

        private void Awake()
        {
            _playerMgr = GetComponentInParent<PlayerMgr>();
            _camera = Camera.main;
        }

        private bool CanShoot()
        {
            if (Time.time < lastFire + shootCoolDown)
                return false;
            lastFire = Time.time;
            return true;
        }

        public void ShootEnemy()
        {
            if (Time.time < lastFire + 2.5f)
                return;
            lastFire = Time.time;
            Bullet instance = bulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.forward = -transform.right;
        }

        public void ShootPlayer()
        {
            var canShoot = CanShoot();
            if (!canShoot)
                return;
            animator.SetTrigger("RangedAttack");
            Bullet instance = bulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.forward = transform.right;
            if (_playerMgr.Is3rdPerson)
                Aim(instance);
        }

        private void Aim(Bullet instance)
        {
            float screenX = Screen.width / 2;
            float screenY = Screen.height / 2;

            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(new Vector3(screenX, screenY));

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 aimSpot = _camera.transform.position;
                aimSpot += _camera.transform.forward * 50.0f;
                instance.transform.LookAt(aimSpot);
            }
        }
    }
}
