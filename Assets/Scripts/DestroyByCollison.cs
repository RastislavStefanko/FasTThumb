using UnityEngine;
using System.Collections;

public class DestroyByCollison : MonoBehaviour {

    //destroy all object in collision
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
