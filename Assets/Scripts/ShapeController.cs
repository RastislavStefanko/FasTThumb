using UnityEngine;
using System.Collections;

public class ShapeController : MonoBehaviour
{
    public GameObject shadow;
    public GameObject canvas;

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(transform.position, Vector3.forward * 1000);

        //cast ray on incoming wall and translate object shadow
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag == "wallObject" || hit.collider.tag == "Enemy")
            {
                shadow.transform.position = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z);
                if (hit.distance > 30)
                {
                    shadow.transform.localScale = new Vector3(hit.distance / 100, hit.distance / 100, shadow.transform.localScale.z);
                }
            }
        }
    }

    //check collision player with wall or enemy, if enemy : destroy wall
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            Destroy(other.transform.parent.gameObject);
        }

        if(other.transform.tag == "wallObject")
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            Destroy(gameObject);
        }
    }

}