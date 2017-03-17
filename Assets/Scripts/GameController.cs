using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] wall;
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

    public AudioSource gameOverSound;

    public float speedWall = -20;

    private int tmpNumber;
    private TouchScreenKeyboard keyBoard;

    private int end = 0;
    public GameObject destroyWall;

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

        if (end < 3 && end >= 0)
        {
            end = destroyWall.GetComponent<OnWallDestroy>().end;
        }

        scoreText.text = "" + score;

        if (end > 2)
        {
            gameOverSound.Play();

            //on defeat check high score, if new rewrite actual
            canvas.SetActive(true);
            highScoresTexts[1].text = "" + score;
            for(int i =0; i < 5; i++)
            {
                if (score >= PlayerPrefs.GetInt("highScore" + i))
                {
                    //move old highscores one place down
                    for (int j = 4; j > i; j--)
                    {
                         PlayerPrefs.SetInt("highScore" + j, PlayerPrefs.GetInt("highScore" + (j - 1)));
                         PlayerPrefs.SetString("highScoreName" + j, PlayerPrefs.GetString("highScoreName" + (j - 1)));
                    }
                    //open keyboard
                    keyBoard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

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
            end = -1;
            
        }

        //set player name on new high score
        if (keyBoard != null && keyBoard.done)
        {
            highScoresTexts[3].text = keyBoard.text;
            PlayerPrefs.SetString("highScoreName" + tmpNumber, keyBoard.text);
        }
        
    }

        //each spawnTime time is spawn one enemy
        IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            //randomize side and color
            side = Random.Range(0, 2);
            color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
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
            

            //give player opposite colour to enemy
            switch (side)
            {
                case 0:
                    spawnValues.x = Random.Range(-spawnValues.x, -2);
                    for(int i = 0; i < leftPlayers.Length; i++)
                    {
                        foreach (Transform child in leftPlayers[i].transform)
                        {
                            child.GetComponent<MeshRenderer>().material.color = new Color(1 - color.r, 1 - color.g, 1 - color.b);
                        }
                        
                    }
                    break;
                case 1:
                    spawnValues.x = Random.Range(2, spawnValues.x);
                    for (int i = 0; i < rightPlayers.Length; i++)
                    {
                        foreach (Transform child in rightPlayers[i].transform)
                        {
                            child.GetComponent<MeshRenderer>().material.color = new Color(1 - color.r, 1 - color.g, 1 - color.b);
                        }
                    }
                    break;
                default:
                    break;
            }

            //spawn enemy at different position
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            GameObject instantiateWall = Instantiate(wall[Random.Range(0,wall.Length)], spawnPosition, Quaternion.identity);
            instantiateWall.GetComponent<MeshRenderer>().material.color = color;

            // change speed of coming enemy every wave until speed of 45
            if (speedWall > -45)
            {
                speedWall -= 0.5f;
            }
            instantiateWall.GetComponent<Mover>().speed = speedWall;

            //change spawn time of every wave
            if (spawnTime >= 2)
            {
                spawnTime -= 0.05f;
            }
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
