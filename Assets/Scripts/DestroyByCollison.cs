using UnityEngine;
using System.Collections;

public class DestroyByCollison : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //destroy all object in collision
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
