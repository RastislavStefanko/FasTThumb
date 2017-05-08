using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour {

    public GameObject target1;
    public GameObject target2;

	
	// Update is called once per frame
	void Update () {
        target1.transform.Rotate(Vector3.forward);
        target2.transform.Rotate(Vector3.back);
	}
}
