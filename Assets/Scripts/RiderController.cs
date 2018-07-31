using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderController : MonoBehaviour {

    public Rigidbody2D rbRider;
    public float speed = 20.0f;
    public float rotationSpeed = 2.5f;

    private bool isMoving = false;
    private bool isGrounded = false;

	
	// Update is called once per frame
    private void Update () {
        if(Input.GetMouseButtonDown(0))
            isMoving = true;

        if (Input.GetMouseButtonUp(0))
            isMoving = false;
	}

    private void FixedUpdate()
    {
        if(isMoving){
            if (isGrounded)
            {
                rbRider.AddForce(transform.right * speed * Time.fixedDeltaTime * 100.0f, ForceMode2D.Force);
            }else{
                rbRider.AddTorque( rotationSpeed * Time.fixedDeltaTime * 20.0f, ForceMode2D.Force);
            }
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
