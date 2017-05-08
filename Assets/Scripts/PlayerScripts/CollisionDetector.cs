
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

	void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "EnemyCircle")
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }

        if (other.transform.tag == "EnemyCube")
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
