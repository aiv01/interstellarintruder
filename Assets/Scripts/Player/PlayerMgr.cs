using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapom;

public class PlayerMgr : MonoBehaviour
{
    #region SerializeField 
    [SerializeField]
    private GameObject _gun;
    [SerializeField]
    private GameObject _staff;
    [SerializeField]
    private CinemachineVirtualCamera _3rdCamera;
    [SerializeField]
    private CinemachineVirtualCamera _topDownCamera;
    #endregion

    #region Private Variable
    private PlayerInput _playerInput;
    private Gun _gunComponent;
    #endregion

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _gunComponent = _gun.GetComponent<Gun>();
    }

    void Update()
    {
        if (_playerInput.Input.ChangeWeapon.triggered)
        {
            _gun.SetActive(!_gun.activeSelf);
        }

        if (_playerInput.Input.Attack.triggered && _gun.activeSelf)
        {
            _gunComponent.Shoot();
        }
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
