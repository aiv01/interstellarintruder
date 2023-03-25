using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Staff : MonoBehaviour
    {
        #region
        [SerializeField]
        private Transform staffHandPos;
        #endregion

        #region Property
        private float damage = 2.0f;
        public float Damage
        {
            get => damage;
        }
        #endregion

        void Update()
        {
            transform.position = staffHandPos.position;
            transform.rotation = staffHandPos.rotation;
        }
    }
}
