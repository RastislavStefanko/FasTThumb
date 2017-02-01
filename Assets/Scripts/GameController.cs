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

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(36, 49), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(wall, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnTime);

        }
    }
}
