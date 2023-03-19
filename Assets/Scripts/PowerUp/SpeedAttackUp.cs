using UnityEngine;

namespace PowerUp
{
    public class SpeedAttackUp : PowerUp
    {
        [SerializeField]
        [Range(.1f, 10.0f)]
        private float amountAttackSpeed = .5f;
        
        protected static event StatsChange SpeedAttackStatUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                SpeedAttackStatUp?.Invoke(amountAttackSpeed);
                gameObject.SetActive(false);
            }
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
