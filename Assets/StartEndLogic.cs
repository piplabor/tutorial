using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

public class StartEndLogic : MonoBehaviour
{
    [Header("UI Canvases")]
    public GameObject startScreen;
    public GameObject endScreen;

    [Header("Input Actions")]
    public InputActionReference confirmButton;

    [Header("Optional Buttons")]
    public GameObject startButton;
    public GameObject endButton;

    private bool onStartScreen = false;
    private bool onEndScreen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScreen.SetActive(true);
        endScreen.SetActive(false);
        onStartScreen = true;

    UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(startButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (confirmButton.action.WasPressedThisFrame())
        {
            if (onStartScreen)
            {
                StartGame();
            }
            else if (onEndScreen)
            {
                QuitGame();
            }
        }
    }
    public void StartGame()
    {
        startScreen.SetActive(false);
        onStartScreen = false;
    }

    public void ShowEndScreen()
    {
        endScreen.SetActive(true);
        onEndScreen = true;
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(endButton);
        
    }
    public void EndGame()
    {
        endScreen.SetActive(true);
        onEndScreen = true;
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(endButton);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");

        // If running in the editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
