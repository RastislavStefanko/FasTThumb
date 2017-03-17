using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWallDestroy : MonoBehaviour {

    public GameObject[] destroyAnimation;
    public GameObject crackedMonitor;

    public int end = 0;

    void OnTriggerEnter(Collider other)
    {

        // destroy enemy and change destroyed particles color to color of main enemy
        if (other.transform.tag == "EnemyCircle")
        {
            GameObject tmp = Instantiate(destroyAnimation[0], other.transform.position, Quaternion.identity);
            tmp.GetComponent<ParticleSystemRenderer>().material.color = other.GetComponent<MeshRenderer>().material.color;
        }

        if(other.transform.tag == "EnemyCube")
        {
            GameObject tmp = Instantiate(destroyAnimation[1], other.transform.position, Quaternion.identity);
            tmp.GetComponent<ParticleSystemRenderer>().material.color = other.GetComponent<MeshRenderer>().material.color;
        }

        end++;
        Instantiate(crackedMonitor, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }
}
