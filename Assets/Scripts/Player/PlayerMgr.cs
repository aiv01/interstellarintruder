using Attack;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapon;

public class PlayerMgr : MonoBehaviour
{
    #region SerializeField 
    [SerializeField]
    private CinemachineVirtualCamera _camera;
    [SerializeField]
    private UnityEngine.Events.UnityEvent onPauseRequested;
    #endregion

    #region Private Variable
    public PlayerInput _playerInput;
    private Gun _gunComponent;
    private Staff _staffComponent;

    private bool canShoot = true;
    #endregion

    #region Player Component
    private PlayerAttack _playerAttack;
    private PlayerRotation _playerRotation;
    #endregion

    #region Property
    private bool isMeleeAttack = true;
    public bool IsMelee
    {
        get => isMeleeAttack;
    }

    private bool _is3rdPerson = true;
    public bool Is3rdPerson
    {
        get => _is3rdPerson;
    }
    #endregion

    private void Start()
    {
        _playerAttack = GetComponentInChildren<PlayerAttack>();
        _playerRotation = GetComponentInChildren<PlayerRotation>();
        _gunComponent = GetComponentInChildren<Gun>();
        _gunComponent.GunHoldPosition();
        _staffComponent = GetComponentInChildren<Staff>();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    void Update()
    {
        #region Change Weapon
        if (_playerInput.Input.ChangeWeapon.triggered)
        {
            isMeleeAttack = !isMeleeAttack;
            if (isMeleeAttack)
                _gunComponent.GunHoldPosition();
            else
                _gunComponent.GunShootPosition();
            _staffComponent.gameObject.SetActive(isMeleeAttack);
        }
        #endregion

        #region Attack
        if (_playerInput.Input.Attack.triggered)
        {
            if (isMeleeAttack)
                _playerAttack.MeleeAnimation();
            else
            {
                canShoot = _gunComponent.CountAmmo();
                if (canShoot)
                    _playerAttack.RangedAnimation();
            }
        }
        #endregion

        #region Change Camera
        if(_playerInput.Input.ChangeCamera.triggered)
        {
            _is3rdPerson = !_is3rdPerson;
            _camera.Priority *= -1;
        }
        #endregion
    }

    #region Enable Disable
    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Input.Pause.performed += HandlePauseButtonPressed;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Input.Pause.performed -= HandlePauseButtonPressed;
    }
    #endregion

    private void HandlePauseButtonPressed(InputAction.CallbackContext obj)
    {
        onPauseRequested.Invoke();
        _playerRotation.enabled = false;
        Cursor.visible = true;
    }
}
