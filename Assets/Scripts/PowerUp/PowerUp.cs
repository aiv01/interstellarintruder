using UnityEngine;

namespace PowerUp
{
    public class PowerUp : MonoBehaviour
    {
        protected delegate void StatsChange(float amount);

        [SerializeField]
        private PlayerStats _playerStats;

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