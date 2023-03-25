using System.Collections.Generic;
using UnityEngine;
using Weapon.Projectile;

namespace PowerUp
{
    public class PowerUpPool : MonoBehaviour
    {
        #region SerializeField
        [SerializeField]
        private List<PowerUp> powerUpPrefabs = new List<PowerUp>();
        #endregion

        #region Private Variable
        private int poolSize = 4;
        private List<PowerUp> powerUps = new List<PowerUp>();
        #endregion

        void Awake()
        {
            FillPool();
        }

        #region Private Method
        private void FillPool()
        {
            for (int i = 0; i < poolSize; i++)
                CreateInstance(powerUpPrefabs[i]);
        }

        private PowerUp CreateInstance(PowerUp powerUpPrefabs)
        {
            PowerUp instance = Instantiate<PowerUp>(powerUpPrefabs);
            instance.transform.position = new Vector3(Random.Range(0, 10), .5f, Random.Range(0, 10));
            instance.gameObject.SetActive(true);
            instance.transform.SetParent(transform);
            instance.OnDespawn += HandlePowerUpDespawn;
            powerUps.Add(instance);
            return instance;
        }

        private void HandlePowerUpDespawn(PowerUp powerUpDespawn)
        {
            powerUpDespawn.gameObject.SetActive(false);
            powerUpDespawn.transform.SetParent(transform);
        }
        #endregion
    }
}
