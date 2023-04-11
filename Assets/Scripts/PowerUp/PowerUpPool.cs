using System.Collections.Generic;
using UnityEngine;
using Weapon.Projectile;

namespace PowerUp
{
    public class PowerUpPool : MonoBehaviour
    {
        #region SerializeField
        [SerializeField]
        private PowerUpBase[] powerUpPrefabs;
        #endregion

        #region Private Variable
        private int poolSize = 4;
        private List<PowerUpBase> powerUps = new List<PowerUpBase>();
        #endregion

        void Start()
        {
            FillPool();
        }

        #region Private Method
        private void FillPool()
        {
            for (int i = 0; i < poolSize; i++)
                CreateInstance(powerUpPrefabs[i]);
        }

        private PowerUpBase CreateInstance(PowerUpBase powerUpPrefabs)
        {
            PowerUpBase instance = Instantiate(powerUpPrefabs);
            instance.gameObject.SetActive(false);
            instance.transform.SetParent(transform);
            instance.OnDespawn += HandlePowerUpDespawn;
            powerUps.Add(instance);
            return instance;
        }

        private void HandlePowerUpDespawn(PowerUpBase powerUpDespawn)
        {
            powerUpDespawn.gameObject.SetActive(false);
            powerUpDespawn.transform.SetParent(transform);
        }
        #endregion

        #region Get
        public PowerUpBase GetPowerUp()
        {
            PowerUpBase val = null;
            foreach (PowerUpBase powerUp in powerUps)
                if (!powerUp.gameObject.activeSelf)
                {
                    val = powerUp;
                    break;
                }
            val.gameObject.SetActive(true);
            return val;
        }

        public PowerUpBase GetTypePowerUp(PowerUpType _type)
        {
            PowerUpBase val = null;

            foreach (PowerUpBase powerUp in powerUps)
                if (powerUp._powerUpType == _type)
                {
                    val = powerUp;
                    break;
                }
            return val;
        }

        public PowerUpBase GetRandomPowerUp()
        {
            PowerUpBase val = null;

            val = powerUps[Random.Range(0, powerUps.Count)];
            val.gameObject.SetActive(true);
            return val;
        }
        #endregion
    }
}
