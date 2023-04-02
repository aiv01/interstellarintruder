using UnityEngine;

namespace PowerUp
{
    public class SpeedAttackUp : PowerUpBase
    {
        [SerializeField]
        [Range(.1f, 10.0f)]
        private float amountAttackSpeed = .5f;

        protected event StatsChange SpeedAttackStatUp;

        private void Awake()
        {
            _powerUpType = PowerUpType.Attack_Speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                SpeedAttackStatUp?.Invoke(amountAttackSpeed, other.gameObject.GetComponent<PlayerStats>());
                Despawn();
            }
        }

        private void SpeedAttackUp_Stat(float amount, PlayerStats _stats)
        {
            _stats.SpeedMovement += amount;
        }

        #region Enable Disable
        private void OnEnable()
        {
            SpeedAttackStatUp += SpeedAttackUp_Stat;
        }

        private void OnDisable()
        {
            SpeedAttackStatUp -= SpeedAttackUp_Stat;
        }
        #endregion

    }
}
