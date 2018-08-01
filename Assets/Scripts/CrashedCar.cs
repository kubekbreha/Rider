using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashedCar : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<RiderController>().RoofOfCarCollisionEnter(this);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent.GetComponent<RiderController>().RoofOfCarCollisionExit(this);
    }

}
