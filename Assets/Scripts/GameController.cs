using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject wall;
    public Vector3 spawnValues;
    public float spawnTime;
    public float startTime;

    private int side;
    private Color color;

    public GameObject[] leftPlayers;
    public GameObject[] rightPlayers;

    private int score = 0;
    public Text scoreText; 

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update () {

        //adding score and show in scoreText
        for (int i = 0; i < leftPlayers.Length; i++)
        {
            if (leftPlayers[i] != null)
            {
                score += leftPlayers[i].GetComponent<ShapeController>().getPoints();
                leftPlayers[i].GetComponent<ShapeController>().setPointsToZero();
            }
            if (rightPlayers[i] != null)
            {
                score += rightPlayers[i].GetComponent<ShapeController>().getPoints();
                rightPlayers[i].GetComponent<ShapeController>().setPointsToZero();
            }
        }

        scoreText.text = "" + score;
    }


    //each spawnTime time is spawn one wall
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            //randomize side and colour
            side = Random.Range(0, 2);
            color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            //give player opposite colour to wall 
            switch (side)
            {
                case 0:
                    spawnValues.x = -16;
                    for(int i = 0; i < leftPlayers.Length; i++)
                    {
                        leftPlayers[i].GetComponent<MeshRenderer>().material.color = new Color(1 - color.r, 1 - color.g, 1 - color.b);
                    }
                    break;
                case 1:
                    spawnValues.x = 16;
                    for (int i = 0; i < rightPlayers.Length; i++)
                    {
                        rightPlayers[i].GetComponent<MeshRenderer>().material.color = new Color(1 - color.r, 1 - color.g, 1 - color.b);
                    }
                    break;
                default:
                    break;
            }

            Vector3 spawnPosition = new Vector3(spawnValues.x, 0, spawnValues.z);
            GameObject instantiateWall = Instantiate(wall, spawnPosition, wall.transform.rotation);
            instantiateWall.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(spawnTime);

        }
    }

    public int getSide()
    {
        return side;
    }

    public Color getColor()
    {
        return color;
    }
}
