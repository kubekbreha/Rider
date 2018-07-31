using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderController : MonoBehaviour {

    public Rigidbody2D rbRider;
    public float speed = 20.0f;

    private bool move = false;
	
	// Update is called once per frame
    private void Update () {
        if(Input.GetMouseButtonDown(0))
            move = true;

        if (Input.GetMouseButtonUp(0))
            move = false;
	}

    private void FixedUpdate()
    {
        if(move){
            rbRider.AddForce(transform.right * speed * Time.fixedDeltaTime * 100.0f, ForceMode2D.Force);
        }
    }
}
