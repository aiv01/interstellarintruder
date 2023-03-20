using UnityEngine;

namespace PowerUp
{
    public class SpeedMovementUp : PowerUp
    {
        [SerializeField]
        [Range(.1f, 10.0f)]
        private float amountSpeedMovement = .5f;

        protected event StatsChange SpeedMovementStatUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                SpeedMovementStatUp?.Invoke(amountSpeedMovement);
                Despawn();
            }
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
