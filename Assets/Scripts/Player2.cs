using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody2D rbd2;
    float clicks;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        clicks = Input.GetAxis("Fire1");
        Vector2 velocity = rbd2.velocity;
        velocity.x = clicks * speed;
        rbd2.velocity = velocity;


    }
}
