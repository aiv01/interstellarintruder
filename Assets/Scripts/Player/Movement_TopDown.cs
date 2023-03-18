using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_TopDown : MonoBehaviour
{
    #region SerializeField 
    #endregion

    #region Private Variable
    private PlayerInput _playerInput;
    private CharacterController _controller;
    private Animator _animator;

    private Vector2 inputVector;
    private float walkSpeed = 1.0f;
    private float runSpeed = 6.0f;
    #endregion

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        Vector3 mousePos = _playerInput.Input.MousePosition.ReadValue<Vector2>();
        Vector3 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.eulerAngles = new Vector3(0, angle);
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

    #region Movement
    private void Move()
    {
        inputVector = _playerInput.Input.Move.ReadValue<Vector2>();

        if (_playerInput.Input.Run.IsPressed())
            RunMove();
        else
            WalkMove();

        _controller.Move(
            _animator.GetFloat("ForwardSpeed") * Time.deltaTime * _controller.transform.forward +
            _animator.GetFloat("HorizontalSpeed") * Time.deltaTime * _controller.transform.right
            );
    }

    private void RunMove()
    {
        //Horizontal Movement
        _animator.SetFloat("HorizontalSpeed", inputVector.x * runSpeed);
        //Vertical Movement
        _animator.SetFloat("ForwardSpeed", inputVector.y * runSpeed);
    }
    private void WalkMove()
    {
        //Horizontal Movement
        _animator.SetFloat("HorizontalSpeed", inputVector.x * walkSpeed);
        //Vertical Movement
        _animator.SetFloat("ForwardSpeed", inputVector.y * walkSpeed);
    }
    #endregion
}
