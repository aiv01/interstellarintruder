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
        var mouse = _playerInput.Input.MousePosition.ReadValue<Vector2>();
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle + 90, 0);
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
