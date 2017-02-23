using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScenesController : MonoBehaviour {

    //public string directScene;
    public GameObject pauseCanvas;

    public void LoadScene(string directScene)
    {
        Time.timeScale = 1;
        //Application.LoadLevel(directScene); /*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*
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

    public void ExitApp()
    {
        Application.Quit();
    }
}
