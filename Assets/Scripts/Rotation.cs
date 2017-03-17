using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float speed = 1;
	
	// Update is called once per frame
	void Update () {
        //rotate objcet with speed
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
}
