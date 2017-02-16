using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

    public float z = 10;

    public GameObject[] rightPlayers;
    public GameObject[] leftPlayers;

    private int whatSide = 2; //0 == left, 1 == right
    private int whatSide2 = 2;

    private int rightCounter = 0;
    private int leftCounter = 0;

    private float doubleTapTime;

    private float touch1Duration = 0;
    private float touch2Duration = 0;

    private int layer = 1 << 10;

    void FixedUpdate()
    {
        //iteration through touches
        foreach (Touch touch in Input.touches)
        {
            //first touch
            if (touch.fingerId == 0)
            {
                touch1Duration += Time.deltaTime;

                Ray ray1 = new Ray(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 17)), Vector3.back * 1000);
                Debug.DrawRay(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 17)), Vector3.back * 1000, Color.yellow);

                //touch phases
                if (touch.phase == TouchPhase.Began)
                {
                    //check on which side is the first touch
                    whatSide = CheckRaycastHit(ray1);
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    if (touch1Duration > 0.2f)
                    {
                        //player moving
                        if (CheckRaycastHit(ray1) == whatSide)
                        {
                            if (whatSide == 0)
                            {
                                MovePlayer(touch, true);
                            }
                            else
                            {
                                MovePlayer(touch, false);
                            }
                        }
                    }

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (touch1Duration < 0.3f)
                    {
                        singleOrDouble(whatSide, touch); // start coroutine to check on single tap
                    }
                    touch1Duration = 0;
                }
            }
            
            //second touch, like first but with self parameters
            if (touch.fingerId == 1)
            {

                touch2Duration += Time.deltaTime;

                Ray ray2 = new Ray(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 17)), Vector3.back * 1000);
                Debug.DrawRay(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 17)), Vector3.back * 1000, Color.blue);

                if (touch.phase == TouchPhase.Began)
                {
                    whatSide2 = CheckRaycastHit(ray2);
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    if (touch2Duration > 0.2f)
                    {
                        if (CheckRaycastHit(ray2) == whatSide2)
                        {
                            if (whatSide2 == 0)
                            {
                                MovePlayer(touch, true);
                            }
                            else
                            {
                                MovePlayer(touch, false);
                            }
                        }
                    }

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (touch2Duration < 0.3f)
                    {
                        singleOrDouble(whatSide2, touch);
                    }
                        touch2Duration = 0;
                }
            }
        }

        //clamp position to boundary
        /*transform.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, -18.5f, 18.5f),
            Mathf.Clamp(rb.position.y, -7.8f, 7.8f),
            z
        );*/
    }

    //moving function
    void MovePlayer(Touch touch, bool left)
    {
        //move all object in same direction
        if (left)
        {
            leftPlayers[0].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, z));
            leftPlayers[1].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, z));
        }
        else
        {
            rightPlayers[0].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, z));
            rightPlayers[1].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, z));
        }
    }

    //check if ray casting something hit, return number of side
    int CheckRaycastHit(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000,layer))
        {
            if (hit.collider.tag == "RightSide")
            {
                return 1;
            }

            if (hit.collider.tag == "LeftSide")
            { 
                return 0;
            }

            return 2;
        }
        return 2;
    }

    //coroutine on tap and double tap
    void singleOrDouble(int side, Touch touchCheck)
    {

        if (side == 0)
        {
                    leftPlayers[leftCounter].SetActive(false);
                    if (leftCounter >= 1)
                    {
                        leftCounter = 0;
                    }
                    else
                    {
                        leftCounter++;
                    }
                    leftPlayers[leftCounter].SetActive(true);
        }
        else
        {

                    rightPlayers[rightCounter].SetActive(false);
                    if (rightCounter >= 1)
                    {
                        rightCounter = 0;
                    }
                    else
                    {
                        rightCounter++;
                    }
                    rightPlayers[rightCounter].SetActive(true);
               
            
        }
        
    }
}