using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public GameObject[] highScoreTexts;
	
	void Start()
    {
        //show high scores
        for (int i = 0; i < 5; i++)
        {
            highScoreTexts[i].GetComponent<Text>().text = "" + PlayerPrefs.GetInt("highScore" + i);
            highScoreTexts[i].transform.parent.GetComponent<Text>().text += PlayerPrefs.GetString("highScoreName" + i);
        }
    }
}
