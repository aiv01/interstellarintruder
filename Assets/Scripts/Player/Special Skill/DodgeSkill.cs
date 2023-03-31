using UnityEngine;

namespace PlayerFile.SpecialSkill
{
    public class DodgeSkill : MonoBehaviour
    {
        #region Private Variable
        private PlayerInput _playerInput;
        private CharacterController _controller;

        private Vector3 lastDirection;
        
        private float distanceDodge = 1.5f;
        private float coolDown = 3.0f;
        private float timerCoolDown = 0.0f;
        private bool isTeleporting = false;
        #endregion

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _controller = GetComponent<CharacterController>();
            lastDirection = new Vector3(distanceDodge, 0);
        }

        void Update()
        {
            timerCoolDown += Time.deltaTime;
            if (timerCoolDown > coolDown)
                isTeleporting = false;

            #region Teleport Player Direction
            if (_playerInput.Input.Move.triggered)
                lastDirection = _playerInput.Input.Move.ReadValue<Vector2>();

            if (_playerInput.Input.ActiveSkill.triggered && !isTeleporting)
            {
                isTeleporting = true;
                timerCoolDown = 0.0f;
                ControlDistanceDodge();
                _controller.Move(
                            (
                                lastDirection.x * transform.right +
                                lastDirection.y * transform.forward
                            ) *
                    distanceDodge
                );
            }
            #endregion
        }

        private void ControlDistanceDodge()
        {
            if (lastDirection.x > 0.1)
                lastDirection.x = 1;
            else if(lastDirection.x < -0.1)
                lastDirection.x = -1;

            if (lastDirection.y > 0.1)
                lastDirection.y = 1;
            else if (lastDirection.y < -0.1)
                lastDirection.y = -1;
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
