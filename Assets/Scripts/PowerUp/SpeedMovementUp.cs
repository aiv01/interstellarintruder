using UnityEngine;

namespace PowerUp
{
    public class SpeedMovementUp : PowerUpBase
    {
        [SerializeField]
        [Range(.1f, 10.0f)]
        private float amountSpeedMovement = .5f;

        protected event StatsChange SpeedMovementStatUp;

        private void Awake()
        {
            _powerUpType = PowerUpType.Movement_Speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                SpeedMovementStatUp?.Invoke(amountSpeedMovement, other.gameObject.GetComponent<PlayerStats>());
                Despawn();
            }
        }
        private void SpeedMovementUp_Stat(float amount, PlayerStats _stats)
        {
            _stats.SpeedAttack += amount;
        }

        #region Enable Disable
        private void OnEnable()
        {
            SpeedMovementStatUp += SpeedMovementUp_Stat;
        }

        private void OnDisable()
        {
            SpeedMovementStatUp -= SpeedMovementUp_Stat;
        }
        #endregion

    }
}
