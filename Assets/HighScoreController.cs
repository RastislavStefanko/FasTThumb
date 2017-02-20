using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public Text highScoreText;
	
	void Start()
    {
        highScoreText.text = "" + PlayerPrefs.GetInt("highScore");
    }
}
