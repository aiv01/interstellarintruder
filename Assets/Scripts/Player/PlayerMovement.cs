using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Private Variable
    private PlayerInput _playerInput;
    private CharacterController _controller;
    private Animator _animator;

    private PlayerStats _stats;
    private PlayerMgr _playerMgr;

    private Vector3 inputVector;
    private bool isRun = false;
    private float walkSpeed = 2.0f;
    private float runSpeed = 6.0f;
    #endregion

    #region Property
    public bool IsDeath
    {
        get
        {
            if (_stats.Health <= 0)
            {
                _animator.SetTrigger("Death");
                return true;
            }
            return false;
        }
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _stats = GetComponent<PlayerStats>();
        _playerMgr = GetComponentInParent<PlayerMgr>();
    }
    #endregion

    void Update()
    {
        if (_playerInput.Input.Run.triggered)
            isRun = !isRun;
        if (!IsDeath)
            Move();

        _animator.SetBool("isRanged", !_playerMgr.IsMelee);
    }

    #region Public Methods
    public void WarpPlayer(Vector3 pos)
    {
        _controller.enabled = false;
        _controller.transform.position = pos;
        _controller.enabled = true;
    }

    public void HurtDirection(Transform bullet)
    {
        Vector3 pos = transform.InverseTransformPoint(bullet.position).normalized;

        if (pos.x < 0)
            _animator.SetFloat("HurtFromX", -1);
        else
            _animator.SetFloat("HurtFromX", 1);

        if (pos.z < 0)
            _animator.SetFloat("HurtFromY", -1);
        else
            _animator.SetFloat("HurtFromY", 1);
        _animator.SetTrigger("Hurt");
    }

    public void Death()
    {
        _controller.enabled = false;
        _stats.Health = 0;
    }
    #endregion

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

        if (isRun)
            RunMove();
        else
            WalkMove();

        _controller.Move(
                (
                    (_animator.GetFloat("ForwardSpeed") + _stats.SpeedMovement) * _controller.transform.forward +
                    (_animator.GetFloat("HorizontalSpeed") + _stats.SpeedMovement) * _controller.transform.right
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
