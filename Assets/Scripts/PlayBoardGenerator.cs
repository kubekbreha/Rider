using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBoardGenerator : MonoBehaviour {
    
    public GameObject[] linesArray;
    public GameObject rider;

    private Vector3 riderPosition;
    private int moveForwardDistance = 20;
    private int moveLineIndex = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        riderPosition = rider.transform.position;

        if(riderPosition.x > moveForwardDistance){
            moveForwardDistance += moveForwardDistance;
            MoveTileForward();

        }
	}


    private void MoveTileForward(){
        Debug.Log("move tile forward");
        Debug.Log(moveLineIndex);
        linesArray[moveLineIndex].transform.position = new Vector3(linesArray[moveLineIndex].transform.position.x + 80,
                                                                   linesArray[moveLineIndex].transform.position.y,
                                                                   linesArray[moveLineIndex].transform.position.z);
        if (moveLineIndex == 3) moveLineIndex = 0;
        moveLineIndex++;

    }

}
