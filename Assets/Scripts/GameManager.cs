using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public int level = 1;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        DontDestroyOnLoad(gameObject);
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
        //if(_playerInput.Input.Pause.triggered)
        //{
        //    SceneManager.LoadScene("Menu Change Scene");
        //}
    }

    public void ChangeLevel()
    {
        level += 1;
        SceneManager.LoadScene("MapTest");
    }
}
