using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        int tmp = Random.Range(0, 3);
        switch (tmp)
        {
            case 0:
                GetComponent<ParticleSystemRenderer>().material.color = new Color(1,1,0);
                break;
            case 1:
                GetComponent<ParticleSystemRenderer>().material.color = new Color(0,1,0);
                break;
            case 2:
                GetComponent<ParticleSystemRenderer>().material.color = new Color(1,0,1);
                break;
            case 3:
                GetComponent<ParticleSystemRenderer>().material.color = new Color(1,0.5f,0);
                break;
            default:
                break;
        }

    }
}
