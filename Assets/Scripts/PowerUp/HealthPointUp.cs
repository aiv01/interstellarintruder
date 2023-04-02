using UnityEngine;

namespace PowerUp
{
    public class HealthPointUp : PowerUpBase
    {
        [SerializeField]
        [Range(1.0f, 10.0f)]
        private float amountHP = 10.0f;

        protected event StatsChange HPStatUp;

        private void Awake()
        {
            _powerUpType = PowerUpType.Health;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                HPStatUp?.Invoke(amountHP, other.gameObject.GetComponent<PlayerStats>());
                Despawn();
            }
        }

        private void HP_Up(float amount, PlayerStats _stats)
        {
            _stats.Health += amount;
        }

        #region Enable Disable
        private void OnEnable()
        {
            HPStatUp += HP_Up;
        }

        private void OnDisable()
        {
            HPStatUp -= HP_Up;
        }
        #endregion

    }
}