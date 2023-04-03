using UnityEngine;

namespace PowerUp
{
    public enum PowerUpType
    {
        Health = 0,
        Damage = 1,
        Attack_Speed = 2,
        Movement_Speed = 4
    }

    public class PowerUpBase : MonoBehaviour
    {
        #region Delegate Event
        protected delegate void StatsChange(float amount, PlayerStats _stats);

        public delegate void PowerUpDelegate(PowerUpBase powerUpDespawn);
        public event PowerUpDelegate OnDespawn = null;
        #endregion

        public PowerUpType _powerUpType;

        protected void Despawn()
        {
            OnDespawn?.Invoke(this);
        }
    }
}