using Cinemachine;
using System.Collections;
using System.Collections.Generic;
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
    private CinemachineVirtualCamera _3rdCamera;
    [SerializeField]
    private CinemachineVirtualCamera _topDownCamera;
    #endregion

    #region Private Variable
    private PlayerInput _playerInput;
    #endregion

    #region Property
    private bool canShoot = true;
    public bool CanShoot
    {
        get => canShoot;
    }
    #endregion

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    void Update()
    {
        if (_playerInput.Input.ChangeWeapon.triggered)
        {
            _gunComponent.IsRanged = !_gunComponent.IsRanged;
            _staff.gameObject.SetActive(!_staff.gameObject.activeSelf);
        }
        if (_playerInput.Input.Attack.triggered && _gunComponent.IsRanged)
            canShoot = _gunComponent.CountAmmo();

        if (_playerInput.Input.ChangeCamera.triggered)
            _topDownCamera.Priority *= -1;
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
