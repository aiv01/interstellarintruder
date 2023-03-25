using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Private Variable
    private PlayerInput _playerInput;
    private CharacterController _controller;
    private Animator _animator;

    private Vector3 inputVector;
    private float walkSpeed = 1.0f;
    private float runSpeed = 6.0f;
    private bool is3rdPerson = true;
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
        if (_playerInput.Input.ChangeCamera.triggered)
            is3rdPerson = !is3rdPerson;

        if (is3rdPerson)
            PlayerRotation_3rdPerson();
        else
            PlayerRotation_TopDown();
    }

    #region Rotation
    private void PlayerRotation_TopDown()
    {
        var mouse = _playerInput.Input.MousePosition.ReadValue<Vector2>();
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle + 90, 0);
    }

    private void PlayerRotation_3rdPerson()
    {
        var mouse = _playerInput.Input.MousePosition.ReadValue<Vector2>();
        transform.Rotate(new Vector3(0, mouse.x));
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (other.transform.position.x < transform.position.x)
                _animator.SetFloat("HurtFromX", -1);
            else if (other.transform.position.x > transform.position.x)
                _animator.SetFloat("HurtFromX", 1);

            if (other.transform.position.y < transform.position.y)
                _animator.SetFloat("HurtFromY", -1);
            else if (other.transform.position.y > transform.position.y)
                _animator.SetFloat("HurtFromY", 1);
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

    #region Movement
    private void Move()
    {
        inputVector = _playerInput.Input.Move.ReadValue<Vector2>();

        if (_playerInput.Input.Run.IsPressed())
            RunMove();
        else
            WalkMove();

        _controller.Move(
                (
                    _animator.GetFloat("ForwardSpeed") * _controller.transform.forward +
                    _animator.GetFloat("HorizontalSpeed") * _controller.transform.right
                ) *
                Time.deltaTime
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
