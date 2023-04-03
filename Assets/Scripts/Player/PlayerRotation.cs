using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    private PlayerMgr _playerMgr;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerMgr = GetComponentInParent<PlayerMgr>();
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

    void Update()
    {
        if(!(_playerInput.Input.RotationGamePad.ReadValue<Vector2>() != Vector2.zero))
        {
            if (_playerMgr.Is3rdPerson)
                RotationKeyBoard_3rdPerson();
            else
                RotationKeyBoard_TopDown();
        }
        else
            RotationGamepad();
        
    }

    #region KeyBoard
    private void RotationKeyBoard_TopDown()
    {
        var mousePos = _playerInput.Input.MousePosition.ReadValue<Vector2>();
        var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle + 90, 0);
    }

    private void RotationKeyBoard_3rdPerson()
    {
        var rotation = _playerInput.Input.DeltaMouse.ReadValue<Vector2>();
        transform.Rotate(new Vector3(0, rotation.x));
    }
    #endregion

    #region Gamepad
    private void RotationGamepad()
    {
        var rotation = _playerInput.Input.RotationGamePad.ReadValue<Vector2>();
        transform.Rotate(new Vector3(0, rotation.x));
    }
    #endregion
}
