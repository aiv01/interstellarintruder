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
        #endregion

        #region Private Variable
        private PlayerMgr _playerMgr;
        private Shooting _shooting;

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
            _shooting = GetComponent<Shooting>();
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
        #endregion

        public bool CountAmmo()
        {
            counterAmmo--;
            if (counterAmmo >= 0)
                _shooting.ShootPlayer();
            
            return counterAmmo >= 0;
        }
    }
}
