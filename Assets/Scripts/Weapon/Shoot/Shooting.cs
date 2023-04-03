using UnityEngine;
using Weapon.Projectile;

namespace Weapon.Shoot
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField]
        private BulletPool bulletPool = null;
        [SerializeField]
        private Vector3 mouthOfFire;

        private Camera _camera;
        private PlayerMgr _playerMgr;
        private PlayerStats _playerStats;
        private bool _shooted = false;
        private float shootCount = 1.0f;
        private float shootCounter = 0.0f;

        private void Awake()
        {
            _playerMgr = GetComponentInParent<PlayerMgr>();
            _playerStats = GetComponent<PlayerStats>();
            _camera = Camera.main;
        }

        void Update()
        {
            CanShoot();
        }

        /*
        public bool CanShoot()
        {
            if (Time.time < lastFire + shootCoolDown)
                return false;
            lastFire = Time.time;
            return true;
        }
        */

        private void CanShoot()
        {
            if (_shooted)
            {
                shootCounter += Time.deltaTime;
                if (shootCounter > shootCount - (shootCount * _playerStats.SpeedAttack / 10))
                {
                    shootCounter = 0.0f;
                    _shooted = false;
                }
            }
        }

        public bool ShootPlayer()
        {
            if (_shooted)
                return false;
            _shooted = true;
            Bullet instance = bulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.forward = transform.right;
            if (_playerMgr.Is3rdPerson)
                Aim(instance);
            return true;
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
