﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class shieldMovement : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        Vector2 moveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        Vector2 moveVelocity2 = moveVector.normalized * speed;

        // rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveVelocity2 * Time.fixedDeltaTime);
        Vector3 lookVector = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal2"), CrossPlatformInputManager.GetAxis("Vertical2"), 5000);
        if (lookVector.x != 0 && lookVector.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVector, Vector3.back);

        // transform.LookAt(transform.position.toVector2() + lookVector);

    }
}
