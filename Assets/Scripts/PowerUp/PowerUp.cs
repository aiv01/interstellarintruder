using UnityEngine;
using UnityEngine.UI;
using Weapon.Projectile;

namespace PowerUp
{
    public class PowerUp : MonoBehaviour
    {
        #region Delegate Event
        protected delegate void StatsChange(float amount);

        public delegate void PowerUpDelegate(PowerUp powerUpDespawn);
        public event PowerUpDelegate OnDespawn = null;
        #endregion

        private PlayerStats _playerStats;
        private Text _textHP;

        private void Awake()
        {
            _playerStats = GameObject.Find("Ellen").GetComponent<PlayerStats>();
            _textHP = GameObject.Find("HP Player").GetComponent<Text>();
        }

        protected void Despawn()
        {
            OnDespawn?.Invoke(this);
        }

        #region Protected Event
        protected void HP_Up(float amount)
        {
            _playerStats.HP += amount;
            _textHP.text = _playerStats.HP.ToString();
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