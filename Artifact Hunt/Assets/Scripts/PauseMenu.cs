using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenu;
    public GameObject healthBar;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        healthBar.SetActive(true);
        IsPaused = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        healthBar.SetActive(false);
        IsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame ()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");
    }
}
