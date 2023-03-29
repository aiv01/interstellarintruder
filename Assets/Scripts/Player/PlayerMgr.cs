using Attack;
using Cinemachine;
using UnityEngine;
using Weapon;

public class PlayerMgr : MonoBehaviour
{
    #region SerializeField 
    [SerializeField]
    private Gun _gunComponent;
    [SerializeField]
    private Staff _staff;
    [SerializeField]
    private CinemachineVirtualCamera _camera;
    #endregion

    #region Private Variable
    private PlayerInput _playerInput;
    private PlayerAttack _characterAttack;

    private bool canShoot = true;
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
        _characterAttack = GetComponentInChildren<PlayerAttack>();
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
            _staff.gameObject.SetActive(isMeleeAttack);
        }
        #endregion

        #region Attack
        if (_playerInput.Input.Attack.triggered)
        {
            if (isMeleeAttack)
                _characterAttack.MeleeAnimation();
            else
            {
                canShoot = _gunComponent.CountAmmo();
                if (canShoot)
                    _characterAttack.RangedAnimation();
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
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    #endregion
}
