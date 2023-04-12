using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public PlayerInput input;
    GameManager gameManager;
    bool triggered = false;
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
        if (input.Input.Interaction.WasPerformedThisFrame() && !triggered)
        {
            gameManager.level++;
            if (gameManager.level > 4)
            {
                SceneManager.LoadScene("EndGame");
                return;
            }
            triggered = true;
            SceneManager.LoadScene("MapScene");
        }
    }
}
