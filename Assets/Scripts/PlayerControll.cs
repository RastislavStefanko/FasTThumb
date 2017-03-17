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

    public float offsetY = 0;
    public float offsetX = 0;

    public GameObject lol;

    void FixedUpdate()
    {
        //iteration through touches
        foreach (Touch touch in Input.touches)
        {
            //first touch
            if (touch.fingerId == 0)
            {
                touch1Duration += Time.deltaTime;

                Ray ray1 = new Ray(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, z)), Vector3.back * 1000);
                Debug.DrawRay(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, z)), Vector3.back * 1000, Color.yellow);

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
                            else if(whatSide == 1)
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
                            else if(whatSide2 == 1)
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
    }

    //moving function
    void MovePlayer(Touch touch, bool left)
    {
        //move all object in same direction
        if (left)
        {
            if (leftPlayers[0] != null && leftPlayers[1] != null)
            {
                leftPlayers[0].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x + offsetX, touch.position.y, z));
                leftPlayers[1].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x + offsetX, touch.position.y, z));
            }
        }
        else
        {

            if (rightPlayers[0] != null && rightPlayers[1] != null)
            {
                rightPlayers[0].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x - offsetX, touch.position.y, z));
                rightPlayers[1].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x - offsetX, touch.position.y, z));
            }
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
            //check if animator is ready, and play animation, on its end set new shape active
            if (leftPlayers[leftCounter].GetComponent<Animator>().isActiveAndEnabled)
            {
                leftPlayers[leftCounter].GetComponent<Animator>().SetBool("changeShape", true);
                if (leftCounter >= 1)
                {
                    leftCounter = 0;
                }
                else
                {
                    leftCounter++;
                }
            }
        }
        else if(side == 1)
        {
            //same as above
            if (rightPlayers[rightCounter].GetComponent<Animator>().isActiveAndEnabled)
            {
                rightPlayers[rightCounter].GetComponent<Animator>().SetBool("changeShape", true);
                if (rightCounter >= 1)
                {
                    rightCounter = 0;
                }
                else
                {
                    rightCounter++;
                }
            }
        }
        
    }
}