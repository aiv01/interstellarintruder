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
        private Camera _camera;
        private PlayerMgr _playerMgr;

        private float shootCoolDown = 0.2f;
        private float lastFire = -10.0f;
        private float reloadTime = 5.0f;
        private float counterReload = 0;
        private int ammo = 7;
        private int counterAmmo;
        #endregion

        private void Start()
        {
            _playerMgr = GetComponentInParent<PlayerMgr>();
        }

        private void Awake()
        {
            counterAmmo = ammo;
            _camera = Camera.main;
        }

        void Update()
        {
            if (!_playerMgr.IsMelee)
                GunShootPosition();
            else
                GunHoldPosition();

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
        private void GunShootPosition()
        {
            transform.position = _handPlayer.transform.position;
            transform.right = _handPlayer.transform.right;
        }

        private void GunHoldPosition()
        {
            transform.position = _gunHoldPosition.position;
            transform.rotation = _gunHoldPosition.rotation;
        }

        private void Shoot()
        {
            if (Time.time < lastFire + shootCoolDown)
                return;
            lastFire = Time.time;

            Bullet instance = bulletPool.GetBullet();
            instance.transform.position = transform.TransformPoint(mouthOfFire);
            instance.transform.forward = transform.right;
            if(_playerMgr.Is3rdPerson)
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
