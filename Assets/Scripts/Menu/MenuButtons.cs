using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject PauseMenu = null;
    public bool isPaused = false;

    private void Start()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            else if (isPaused)
            {
                isPaused = false;
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void LoadGoodEnding()
    {
        SceneManager.LoadScene("GoodEnding");
    }

    public void LoadBadEnding()
    {
        SceneManager.LoadScene("BadEnding");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadMainMenu()
    {
        StaticData.ResetLevel();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void LoadFirstCutscene()
    {
        SceneManager.LoadScene("FirstCutscene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
