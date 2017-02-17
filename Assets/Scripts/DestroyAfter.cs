using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

    public float destroyTime = 1;
	
	// Update is called once per frame
	void Update () {
		if(destroyTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            destroyTime -= Time.deltaTime;
        }
	}
}
