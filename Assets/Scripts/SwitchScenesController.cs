using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScenesController : MonoBehaviour {

    //public string directScene;
    public GameObject pauseCanvas;

    //method for loading new scenes
    public void LoadScene(string directScene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(directScene);
    }
    
    public void PauseScene()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeScene()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    //method which exits application
    public void ExitApp()
    {
        Application.Quit();
    }
}
