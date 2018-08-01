using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Create by Kubo Brehuv 31.7.2018
 */
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
