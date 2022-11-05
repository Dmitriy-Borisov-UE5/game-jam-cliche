using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshmallowMovement : MonoBehaviour {

    public float speed = 5;
    public float jumpPower;

    private Rigidbody2D rb;

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(x, y);
        Run(direction);

        if (Input.GetButtonDown("Jump"))
            Jump(Vector2.up);
    }

    private void Run(Vector2 dir) {
        rb.AddForce(new Vector2(dir.x * speed, 0));
    }

    private void Jump(Vector2 dir) {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
    }
}
