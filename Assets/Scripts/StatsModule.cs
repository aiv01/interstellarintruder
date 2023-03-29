using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stats.Health
{
    public abstract class StatsModule : MonoBehaviour
    {
        #region Health Variable - Property
        protected float maxHP = 100f;
        protected float totalHP = 20f;
        protected float health;
        public float Health
        {
            get => health;
            set
            {
                if (value + totalHP > maxHP) return;
                if (value + health > maxHP)
                    health = maxHP;
                else
                    health = value;
                totalHP = value;
            }
        }
        #endregion

        #region Damage Variable - Property
        protected float maxDamage = 20f;
        protected float damage = 2f;
        public float Damage
        {
            get => damage;
            set
            {
                if (value + damage > maxDamage) return;
                damage = value;
            }
        }
        #endregion

        private void Start()
        {
            health = totalHP;
        }
    }
}
