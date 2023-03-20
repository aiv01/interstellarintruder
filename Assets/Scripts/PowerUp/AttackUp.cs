using UnityEngine;

namespace PowerUp
{
    public class AttackUp : PowerUp
    {
        [SerializeField]
        [Range(1.0f, 10.0f)]
        private float amountAttackDamage = 2.0f;

        protected event StatsChange AttackStatUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                AttackStatUp?.Invoke(amountAttackDamage);
                Despawn();
            }
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
