using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public GameObject shadow;

    public GameObject[] destroyAnimation;

    public GameObject nextShape;

    public string type = "";

    public AudioSource destroySound;

    public GameObject boundary;

    private int point = 0;

    void Update()
    {
        foreach (Transform child in boundary.transform)
        {
            if (!child.gameObject.activeSelf)
            {
                GetComponent<Animator>().SetBool("broken", true);
            }
        }
        /* shadow.SetActive(true);
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
         }*/
    }
    
    //check collision player with wall or enemy, if enemy : destroy wall
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "EnemyCircle" && type == "Circle")
        {
            destroySound.Play();

            //add points
            point += 20;
            GameObject tmp = Instantiate(destroyAnimation[0], other.transform.position, Quaternion.identity);
            tmp.GetComponent<ParticleSystemRenderer>().material.color = other.GetComponent<MeshRenderer>().material.color;
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "EnemyCube" && type == "Cube")
        {
            destroySound.Play();

            //add points
            point += 20;
            GameObject tmp = Instantiate(destroyAnimation[1], other.transform.position, Quaternion.identity);
            tmp.GetComponent<ParticleSystemRenderer>().material.color = other.GetComponent<MeshRenderer>().material.color;
            Destroy(other.gameObject);
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
       // shadow.SetActive(false);
        gameObject.SetActive(false);
    }
}