using UnityEngine;
using Weapom.Projectile;

namespace PowerUp
{
    public class PowerUp : MonoBehaviour
    {
        #region Delegate Event
        protected delegate void StatsChange(float amount);

        public delegate void PowerUpDelegate(PowerUp powerUpDespawn);
        public event PowerUpDelegate OnDespawn = null;
        #endregion

        [SerializeField]
        private PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GameObject.Find("Ellen").GetComponent<PlayerStats>();
        }

        protected void Despawn()
        {
            OnDespawn?.Invoke(this);
        }

        #region Protected Event
        protected void HP_Up(float amount)
        {
            _playerStats.HP += amount;
        }

        protected void AttackUp_Stat(float amount)
        {
            _playerStats.Attack += amount;
        }

        protected void SpeedMovementUp_Stat(float amount)
        {
            _playerStats.SpeedMovement += amount;
        }

        protected void SpeedAttackUp_Stat(float amount)
        {
            _playerStats.SpeedAttack += amount;
        }
        #endregion
    }
}