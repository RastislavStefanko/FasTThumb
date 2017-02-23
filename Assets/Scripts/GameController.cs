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
    public Text finalScoreText;

    public Text playerName;

    public Text[] highScoresTexts;

    public GameObject canvas;

   // private string name; /*//**/*/*//*****/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*
    private int tmpNumber;
    private TouchScreenKeyboard keyBoard;

    private int end = 0;

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
            else
            {
                end++;
            }

            if (rightPlayers[i] != null)
            {
                score += rightPlayers[i].GetComponent<ShapeController>().getPoints();
                rightPlayers[i].GetComponent<ShapeController>().setPointsToZero();
            }else
            {
                end++;
            }
        }

        scoreText.text = "" + score;

        if (end == 1)
        {
            //on defeat check high score, if new rewrite actual
            canvas.SetActive(true);
            highScoresTexts[1].text = "" + score;
            for(int i =0; i < 5; i++)
            {
                if (score >= PlayerPrefs.GetInt("highScore" + i))
                {
                    if (i + 1 != 5)
                    {
                        PlayerPrefs.SetInt("highScore" + (i + 1), PlayerPrefs.GetInt("highScore" + i));
                        PlayerPrefs.SetString("highScoreName" + (i + 1), PlayerPrefs.GetString("highScoreName" + i));
                    }
                    //open keyboard
                    keyBoard = TouchScreenKeyboard.Open(name, TouchScreenKeyboardType.Default);

                    //set right text for high score
                    highScoresTexts[0].text = "New Highscore : ";
                    highScoresTexts[2].gameObject.SetActive(true);
                    PlayerPrefs.SetInt("highScore" + i, score);
                    tmpNumber = i;
                    break;
                }
                else
                {
                    highScoresTexts[0].text = "Your score : ";
                }
            }
            
        }

        //set player name on new high score
        if (keyBoard != null && keyBoard.done)
        {
            highScoresTexts[3].text = keyBoard.text;
            PlayerPrefs.SetString("highScoreName" + tmpNumber, keyBoard.text);
        }
        
    }

        //each spawnTime time is spawn one wall
        IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            //randomize side and color
            side = Random.Range(0, 2);
            //color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            int tmpRandomInt = Random.Range(0, 3);
            if (tmpRandomInt == 1)
            {
                color = new Color(1, 0, 1);
            } else if(tmpRandomInt == 2)
            {
                color = new Color(1, 165f/255f, 0);
            }
            else
            {
                color = new Color(124f/255f, 252f/255f, 0);
            }
            

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

    public int getScore()
    {
        return score;
    }
}
