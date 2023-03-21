using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerFile.SpecialSkill
{
    public class DodgeSkill : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private CharacterController _controller;
        private Vector3 dodgeDirection;
        private float distanceDodge = 1.5f;
        private float coolDown = 3.0f;
        private float timerCoolDown = 0.0f;
        private float timeTeleport = 2.0f;
        private float timerTeleport = 0.0f;
        private bool isTeleporting = false;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            timerCoolDown += Time.deltaTime;
            if (timerCoolDown > coolDown)
            {
                isTeleporting = false;
            }

            #region Teleport Player Direction
            if (!isTeleporting)
                if (_playerInput.Input.ActiveSkill.triggered)
                {
                    dodgeDirection = _playerInput.Input.Move.ReadValue<Vector2>();
                    _controller.Move(
                            (
                                dodgeDirection.x * transform.right + 
                                dodgeDirection.y * transform.forward
                            ) * 
                        distanceDodge
                        );
                }
            #endregion

            timerTeleport += Time.deltaTime;
            if(timerTeleport > timeTeleport)
            {
                isTeleporting = true;
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
}
