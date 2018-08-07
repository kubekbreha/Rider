using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Created by Kubo Brehuv 31.7.2018
 */
public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;

	private void LateUpdate () {

        Vector3 newPos = target.position + offset;
        newPos.z = transform.position.z;

        transform.position = newPos;
	}

}
