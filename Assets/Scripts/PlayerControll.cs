using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

    private Rigidbody rb;

    public float speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 5.0f);

        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, -18.5f, 18.5f),
            Mathf.Clamp(rb.position.y, -7.8f, 7.8f),
            5.0f
        );
    }
}
