using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderButtons : MonoBehaviour
{
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
}
