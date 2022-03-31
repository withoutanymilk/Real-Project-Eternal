using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    void start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume ()
    {
        GameIsPause = false;
        Time.timeScale = 0;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
    }
    void Pause ()
    {
        GameIsPause = true;
        Time.timeScale = 1;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }
    public void LoadMenu()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading MainMenu...");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
