using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControlBoundary : MonoBehaviour {

    public GameObject[] boundaries;

	// Use this for initialization
	void Start () {

        //set new color to bouandaries
		for(int i = 0; i < boundaries.Length; i++)
        {
            boundaries[i].GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
        }
	}
}
