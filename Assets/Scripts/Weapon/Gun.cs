using UnityEngine;
using Weapon.Shoot;

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
        private Shooting _shooting;
        private PlayerStats _playerStats;

        private float reloadTime = 5.0f;
        private float counterReload = 0;
        private int ammo = 7;
        private int counterAmmo;
        #endregion

        private void Awake()
        {
            counterAmmo = ammo;
            _shooting = GetComponent<Shooting>();
            _playerStats = GetComponentInParent<PlayerStats>();
        }

        void Update()
        {
            if(counterAmmo <= 0)
            {
                counterReload += Time.deltaTime;
                if (counterReload > reloadTime - _playerStats.SpeedAttack)
                {
                    counterAmmo = ammo;
                    counterReload = 0;
                }
            }
        }

        #region Private Method
        public void GunShootPosition()
        {
            transform.SetParent(_handPlayer);
            transform.localPosition = new Vector3(0.15f, 0.033f, -0.042f);
        }

        public void GunHoldPosition()
        {
            transform.SetParent(_gunHoldPosition);
            transform.position = _gunHoldPosition.position;
            transform.rotation = _gunHoldPosition.rotation;
        }
        #endregion

        public bool CountAmmo()
        {
            if (counterAmmo > 0 && _shooting.ShootPlayer())
            {
                counterAmmo--;
                return true;
            }
            return false;
        }
    }
}
