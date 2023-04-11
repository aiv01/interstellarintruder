using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private GameObject firstSelectedControl;
    [SerializeField]
    private GameObject optionObject;
    [SerializeField]
    private UnityEngine.Events.UnityEvent onPauseLeft;
    #endregion

    #region Private Variable
    private GameObject selectedControl => EventSystem.current.currentSelectedGameObject;
    private GameManager gameManager;
    #endregion

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _playerInput = new PlayerInput();
    }

    #region Enable Disable
    void OnEnable()
    {
        SelectFirstControl();
        _playerInput.Menu.Enable();
        _playerInput.Menu.Cancel.performed += HandleCancelPressed;
        _playerInput.Menu.Navigate.performed += HandleNavigationPerformed;
        Time.timeScale = 0.0f;
    }
    void OnDisable()
    {
        Time.timeScale = 1.0f;
        _playerInput.Menu.Disable();
    }
    #endregion

    #region Public Methods

    #region Start Menu Scene
    public void StartGame()
    {
        gameManager.level = 1;
        SceneManager.LoadScene("MapScene");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    #region Game Menu Scene
    public void Resume()
    {
        onPauseLeft.Invoke();
        gameObject.SetActive(false);
        GameObject.FindAnyObjectByType<PlayerRotation>().enabled = true;
        Cursor.visible = false;
    }

    public void Option()
    {
        gameObject.SetActive(false);
        optionObject.SetActive(true);
    }

    public void LoadGame()
    {
        gameManager.LoadLevel();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuScene");
        Cursor.visible = true;
    }
    #endregion

    #region GameOver Scene
    public void QuitGameOver()
    {
        SceneManager.LoadScene("MenuScene");
    }
    #endregion

    #endregion

    #region Private Methods
    private void SelectFirstControl() => EventSystem.current.SetSelectedGameObject(firstSelectedControl);
    private void HandleCancelPressed(InputAction.CallbackContext context)
    {
        onPauseLeft.Invoke();
        gameObject.SetActive(false);
        GameObject.FindAnyObjectByType<PlayerRotation>().enabled = true;
        Cursor.visible = false;
    }
    private void HandleNavigationPerformed(InputAction.CallbackContext context)
    {
        if (
            context.control.device is Gamepad &&
            context.action.ReadValue<Vector2>().sqrMagnitude > 0.01f &&
            selectedControl == null
        )
            SelectFirstControl();
    }
    #endregion
}
