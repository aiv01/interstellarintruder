using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    #region Private Variable
    private PlayerInput _playerInput;
    private CharacterController _controller;
    private Animator _animator;

    private bool attackMelee = true;
    #endregion

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_playerInput.Input.ChangeWeapon.triggered)
        {
            attackMelee = !attackMelee;
            _animator.SetBool("IsMeleeAttack", attackMelee);
        }

        if(_playerInput.Input.Attack.triggered)
        {
            if(!attackMelee)
                _animator.SetTrigger("RangedAttack");
            else
                _animator.SetTrigger("MeleeAttack");
        }
    }

    #region Enable Disable
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    #endregion

}
