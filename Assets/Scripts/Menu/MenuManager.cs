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
    private UnityEngine.Events.UnityEvent onPauseLeft;
    #endregion

    #region Private Variable
    private GameObject selectedControl => EventSystem.current.currentSelectedGameObject;
    #endregion

    void Awake()
    {
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
        SceneManager.LoadScene("MapScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    #region Game Menu Scene
    public void Resume()
    {

    }

    public void Option()
    {

    }

    public void LoadGame()
    {

    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuScene");
    }
    #endregion

    #region GameOver Scene

    public void NewGame()
    {

    }

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
