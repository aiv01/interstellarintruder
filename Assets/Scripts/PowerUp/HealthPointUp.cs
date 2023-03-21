using UnityEngine;

namespace PowerUp
{
    public class HealthPointUp : PowerUp
    {
        [SerializeField]
        [Range(1.0f, 10.0f)]
        private float amountHP = 10.0f;

        protected event StatsChange HPStatUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                HPStatUp?.Invoke(amountHP);
                Despawn();
            }
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