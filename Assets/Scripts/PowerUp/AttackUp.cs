using UnityEngine;

namespace PowerUp
{
    public class AttackUp : PowerUpBase
    {
        [SerializeField]
        [Range(1.0f, 10.0f)]
        private float amountAttackDamage = 2.0f;

        protected event StatsChange AttackStatUp;

        private void Awake()
        {
            _powerUpType = PowerUpType.Damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                AttackStatUp?.Invoke(amountAttackDamage, other.gameObject.GetComponent<PlayerStats>());
                Despawn();
            }
        }

        private void AttackUp_Stat(float amount, PlayerStats _stats)
        {
            _stats.Damage += amount;
        }

        #region Enable Disable
        private void OnEnable()
        {
            AttackStatUp += AttackUp_Stat;
        }

        private void OnDisable()
        {
            AttackStatUp -= AttackUp_Stat;
        }
        #endregion

    }
}
