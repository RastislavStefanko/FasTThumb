using UnityEngine;

public class PlayerBoundaryControll : MonoBehaviour
{

    public GameObject[] destroyAnimation;

    void Update()
    {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeSelf)
            {

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /*foreach (Transform child in transform)
        {
            if (other.transform.tag == "EnemyCircle")
            {
                GameObject tmp = Instantiate(destroyAnimation[0], other.transform.position, Quaternion.identity);
                tmp.GetComponent<ParticleSystemRenderer>().material.color = other.GetComponent<MeshRenderer>().material.color;
                Destroy(other.gameObject);
            }

            if (other.transform.tag == "EnemyCube")
            {
                GameObject tmp = Instantiate(destroyAnimation[1], other.transform.position, Quaternion.identity);
                tmp.GetComponent<ParticleSystemRenderer>().material.color = other.GetComponent<MeshRenderer>().material.color;
                Destroy(other.gameObject);
            }
        }*/
        Debug.Log("hit");
    }
}
