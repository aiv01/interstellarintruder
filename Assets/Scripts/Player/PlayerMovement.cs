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
    public void WarpPlayer(Vector3 pos)
    {
        _controller.enabled = false;
        _controller.transform.position = pos;
        _controller.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy" || hit.gameObject.tag == "Bullet")
        {
            HurtDirection(hit.transform);
            _animator.SetTrigger("Hurt");
        }
        if (_stats.Health <= 0)
            Die();
    }

    private void HurtDirection(Transform other)
    {
        /*
        var offset = new Vector2(other.position.x - transform.position.x, other.position.y - transform.position.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        _animator.SetFloat("HurtFromX", angle);
        _animator.SetFloat("HurtFromY", angle);
        */
        _animator.SetFloat("HurtFromX", 1);
        /*
        if (other.position.x < transform.position.x)
            _animator.SetFloat("HurtFromX", -1);
        else if (other.position.x > transform.position.x)
            _animator.SetFloat("HurtFromX", 1);

        if (other.position.z < transform.position.z)
            _animator.SetFloat("HurtFromY", -1);
        else if (other.position.z > transform.position.z)
            _animator.SetFloat("HurtFromY", 1);
        */
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
