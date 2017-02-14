using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;

    public float speed;

    public Vector3 spawnValues;
    public GameObject[] enemies;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        //instantiate enemy on different position
        int whichShape = Random.Range(0, enemies.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, 0), Random.Range(-spawnValues.y, spawnValues.y), transform.position.z);
        Instantiate(enemies[whichShape], spawnPosition, enemies[whichShape].transform.rotation).transform.parent = transform;
        whichShape = Random.Range(0, enemies.Length);
        spawnPosition = new Vector3(Random.Range(0, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), transform.position.z);
        Instantiate(enemies[whichShape], spawnPosition, enemies[whichShape].transform.rotation).transform.parent = transform;
    }
}
