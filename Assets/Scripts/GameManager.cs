using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public int level = 1;
    public bool onLoad = false;

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
        
    }

    public void ChangeLevel()
    {
        level += 1;
        SceneManager.LoadScene("MapScene");
    }
    public void LoadLevel()
    {
        onLoad = true;
        SceneManager.LoadScene("MapScene");
    }
}
