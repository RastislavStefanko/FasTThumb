using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    public Slider musicSlider;
    public Slider soundSlider;

    public GameObject switchScene;

	// Use this for initialization
	void Start () {
        //get sliders values
        musicSlider.value = GameObject.Find("Game Music").GetComponent<AudioSource>().volume;
        soundSlider.value = GameObject.Find("Game Sounds").GetComponent<GameSoundController>().GetSoundVolume();
    }
	
	// Update is called once per frame
	void Update () {
        //set new sound and music volumes based on sliders values
        GameObject.Find("Game Sounds").GetComponent<GameSoundController>().SetSoundVolume(soundSlider.value);
        GameObject.Find("Game Music").GetComponent<AudioSource>().volume = musicSlider.value;
    }
}
