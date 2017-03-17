using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundController : MonoBehaviour {

    private float soundVolume = 0.7f;

    private static GameSoundController instance = null;
    public static GameSoundController Instance
    {
        get { return instance; }
    }

    //dont destroy this object on new load of scene, if there is already this object destroy new instance
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // setting new sound volume
    void Start()
    {
        AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource aud in audios)
        {
            if (aud.gameObject.name != "Game Music")
            {
                aud.volume = soundVolume;
            }
        }
    }

    public void SetSoundVolume(float newSoundVolume)
    {
        soundVolume = newSoundVolume;
    }

    public float GetSoundVolume()
    {
        return soundVolume;
    }
}
