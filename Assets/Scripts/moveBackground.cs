using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = -0.3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        transform.position = (Vector2) transform.position;
    }
}   
