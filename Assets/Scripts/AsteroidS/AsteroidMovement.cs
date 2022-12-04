using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(
            Random.Range(-maxSpeed, maxSpeed),
            Random.Range(-maxSpeed, maxSpeed)
        );
    }


    // Update is called once per frame
    void Update()
    {
    }
}