using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject wall;
    public Vector3 spawnValues;
    public float spawnTime;
    public float startTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update () {
	
	}


    //each spawnTime time is spawn one wall
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {

                Vector3 spawnPosition = new Vector3(0, 0, spawnValues.z);
                Instantiate(wall, spawnPosition, wall.transform.rotation);
                yield return new WaitForSeconds(spawnTime);

        }
    }
}
