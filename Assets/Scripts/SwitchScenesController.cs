using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScenesController : MonoBehaviour {

    public string directScene;

    public void LoadScene()
    {
        Time.timeScale = 1;
        Application.LoadLevel(directScene);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
