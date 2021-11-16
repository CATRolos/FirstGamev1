using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0,1);
        rb.AddRelativeForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
