using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public PlayerInput input;
    GameManager gameManager;
    public void Awake()
    {
        input = new PlayerInput();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void OnTriggerStay(Collider other)
    {
        if (input.Input.Interaction.ReadValue<float>() > 0)
        {
            gameManager.level++;
            SceneManager.LoadScene("MapScene");
        }
    }
}
