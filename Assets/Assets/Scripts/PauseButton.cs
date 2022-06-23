using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public string currentScene;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Debug.Log("f");
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }
}
