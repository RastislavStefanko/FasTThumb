using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroyInNewScene : MonoBehaviour {

    private static DontDestroyInNewScene instance = null;
    public static DontDestroyInNewScene Instance
    {
        get { return instance; }
    }

    //dont destroy this object on new load of scene, if there is already this object destroy new instance
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

}
