using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderController : MonoBehaviour {

    public Rigidbody2D rbRider;
    public float speed = 20.0f;
    public float rotationSpeed = 2.5f;

    private bool isMovingForward = false;
    private bool isMovingBackward= false;
    private bool isGrounded = false;

	
	// Update is called once per frame
    private void Update () {

        //moving backward
        if (Input.GetMouseButtonDown(0))
            isMovingBackward = true;
        if (Input.GetMouseButtonUp(0))
            isMovingBackward = false;

        //moving forward
        if(Input.GetMouseButtonDown(1))
            isMovingForward = true;
        if (Input.GetMouseButtonUp(1))
            isMovingForward = false;
        
	}

    private void FixedUpdate()
    {
        //moving backward
        if (isMovingBackward)
        {
            if (isGrounded)
                rbRider.AddForce(-1 * transform.right * speed * Time.fixedDeltaTime * 100.0f, ForceMode2D.Force);
            else
                rbRider.AddTorque(-1 * rotationSpeed * Time.fixedDeltaTime * 20.0f, ForceMode2D.Force);
        }

        //moving forward
        if(isMovingForward){
            if (isGrounded)
                rbRider.AddForce(transform.right * speed * Time.fixedDeltaTime * 100.0f, ForceMode2D.Force);
            else
                rbRider.AddTorque( rotationSpeed * Time.fixedDeltaTime * 20.0f, ForceMode2D.Force);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
