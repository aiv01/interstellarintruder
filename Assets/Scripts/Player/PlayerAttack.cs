    using UnityEngine;

namespace Attack
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Private Variable
        private Animator _animator;
        #endregion

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void MeleeAnimation()
        {
            _animator.SetTrigger("MeleeAttack");
        }

        public void RangedAnimation()
        {
            _animator.SetTrigger("RangedAttack");
        }
    }
}
