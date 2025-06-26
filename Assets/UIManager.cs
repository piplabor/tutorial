using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI restartText;
    private bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Disables panel if active
        gameOverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger game over manually and check with bool so it isn't called multiple times
        if (Keyboard.current.gKey.wasPressedThisFrame && !isGameOver)
        {
            isGameOver = true;

            StartCoroutine(GameOverSequence());
        }

        //If game is over
        if (isGameOver)
        {
            //If R is hit, restart the current scene
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            //If Q is hit, quit the game
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                print("Application Quit");
                Application.Quit();
            }
        }
    }
    private IEnumerator GameOverSequence()
    {
        gameOverPanel.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        restartText.gameObject.SetActive(true);
    }
}


