using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;

    public float speed;

    public Vector3 spawnValues;
    public GameObject[] enemies;

    private GameController gameControl;

    private int right; // 0 = left, 1 = right

    // Use this for initialization
    void Start()
    {
        gameControl = GameObject.Find("Game Controller").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        right = gameControl.getSide();

        //instantiate enemy on different position and with different colour
        int whichShape = Random.Range(0, enemies.Length);
        Vector3 spawnPosition;

        Color newColor;
        GameObject enemy;

        //check on which side is object
        switch (right)
        {
            case 0:
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, -2), Random.Range(-spawnValues.y, spawnValues.y), transform.position.z);
                enemy = Instantiate(enemies[whichShape], spawnPosition, enemies[whichShape].transform.rotation);
                newColor = gameControl.getColor();
                enemy.GetComponent<SpriteRenderer>().color = new Color(1 - newColor.r, 1 - newColor.g, 1 - newColor.b);
                enemy.transform.parent = transform;
                break;
            case 1:
                spawnPosition = new Vector3(Random.Range(2, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), transform.position.z);
                enemy = Instantiate(enemies[whichShape], spawnPosition, enemies[whichShape].transform.rotation);
                newColor = gameControl.getColor();
                enemy.GetComponent<SpriteRenderer>().color = new Color(1 - newColor.r, 1 - newColor.g, 1 - newColor.b);
                enemy.transform.parent = transform;
                break;
            default:
                break;
        }
    }
}
