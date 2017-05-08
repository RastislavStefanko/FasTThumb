using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideController : MonoBehaviour {

    public float speed = 0.2f;
    public float timeCd = 2;
    private float time = 2;

	// Use this for initialization
	void Start () {
        time = timeCd;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        if(time < 0)
        {
            time = timeCd;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 360);
        }
        else
        {
            time -= Time.deltaTime;
        }
	}
}
