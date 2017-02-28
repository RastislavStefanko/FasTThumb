using UnityEngine;
using System.Collections;

public class ShapeController : MonoBehaviour
{
    public GameObject shadow;

    public GameObject[] destroyAnimation;

    public GameObject nextShape;

    public string type = "";

    public AudioSource destroySound;

    private int point = 0;

    void Update()
    {
        shadow.SetActive(true);
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.forward * 1000);

        //cast ray on incoming wall and translate object shadow
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag == "wallObject" || hit.collider.tag == "EnemyCircle" || hit.collider.tag == "EnemyCube")
            {
                //set shadow position with z axes offset
                shadow.transform.position = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z-0.4f);
                if (hit.distance > 30)
                {
                    shadow.transform.localScale = new Vector3(hit.distance / 60, hit.distance / 60, shadow.transform.localScale.z);
                }
            }
        }
    }

    //check collision player with wall or enemy, if enemy : destroy wall
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "EnemyCircle" && type == "Circle")
        {
            destroySound.Play();
            //on destroy instantiate object with destroy animation and give him target colour
            GameObject tmp;
            if (other.transform.parent.position.x < 0)
            {
                tmp = Instantiate(destroyAnimation[0], other.transform.parent.transform.position, destroyAnimation[0].transform.rotation);
            }
            else
            {
                tmp = Instantiate(destroyAnimation[1], other.transform.parent.transform.position, destroyAnimation[1].transform.rotation);
            }
            foreach (Transform child in tmp.transform)
            {
                child.GetComponent<SpriteRenderer>().color = other.transform.parent.GetComponent<SpriteRenderer>().color;
            }
            //add points
            point += 20;
            Destroy(other.transform.parent.gameObject);
        }

        if (other.transform.tag == "EnemyCube" && type == "Cube")
        {
            destroySound.Play();
            //on destroy instantiate object with destroy animation and give him target colour
            GameObject tmp;
            if (other.transform.parent.position.x < 0)
            {
                tmp = Instantiate(destroyAnimation[0], other.transform.parent.transform.position, destroyAnimation[0].transform.rotation);
            }
            else
            {
                tmp = Instantiate(destroyAnimation[1], other.transform.parent.transform.position, destroyAnimation[1].transform.rotation);
            }
            foreach (Transform child in tmp.transform)
            {
                child.GetComponent<SpriteRenderer>().color = other.transform.parent.GetComponent<SpriteRenderer>().color;
            }
            //add points
            point += 20;
            Destroy(other.transform.parent.gameObject);
        }

            if (other.transform.tag == "wallObject")
        {
            //stop time on defeat
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    public int getPoints()
    {
        return point;
    }

    public void setPointsToZero()
    {
        point = 0;
    }

    //method for setting new object on destroy
    public void setNextShape()
    {
        nextShape.SetActive(true);
        nextShape.gameObject.GetComponent<Animator>().SetBool("changeShape", false);
        shadow.SetActive(false);
        gameObject.SetActive(false);
    }
}