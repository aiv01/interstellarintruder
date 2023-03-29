using Attack;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Private Variable
    private PlayerInput _playerInput;
    private CharacterController _controller;
    private Animator _animator;

    private PlayerStats _stats;
    private PlayerMgr _playerMgr;

    private PlayerAttack _attack;
    private PlayerMovement _movement;
    private PlayerRotation _rotation;

    private Vector3 inputVector;
    private Vector2 mousePos;
    private float walkSpeed = 1.0f;
    private float runSpeed = 6.0f;
    #endregion

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _stats = GetComponent<PlayerStats>();
        _playerMgr = GetComponentInParent<PlayerMgr>();

        _attack = GetComponent<PlayerAttack>();
        _movement = GetComponent<PlayerMovement>();
        _rotation = GetComponent<PlayerRotation>();
    }

    void Update()
    {
        Move();

        _animator.SetBool("isRanged", !_playerMgr.IsMelee);
    }

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
            _animator.SetTrigger("Hurt");
        }
        if (_stats.Health <= 0)
            Die();
    }

    private void Die()
    {
        _animator.SetTrigger("Death");
        _controller.height = .5f;
        _stats.Health = 0;
        _attack.enabled = false;
        _movement.enabled = false;
        _rotation.enabled = false;
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
