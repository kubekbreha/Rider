using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by Kubo Brehuv 1.8.2018
 */
public class PlayBoardGenerator : MonoBehaviour {
    
    public GameObject[] linesArray;
    public GameObject rider;

    private Vector3[] setupLinesPositions;
    private Vector3 riderPosition;
    private int moveForwardDistance = 20;
    private int moveLineIndex = 0;

	void Start () {
        setupLinesPositions = new Vector3[linesArray.Length];

        for (int i = 0; i < linesArray.Length; i++){
            setupLinesPositions[i] = linesArray[i].transform.position;
        }
	}
	
	void Update () {
        riderPosition = rider.transform.position;

        if(riderPosition.x > moveForwardDistance){
            moveForwardDistance += moveForwardDistance;
            MoveTileForward();

        }
	}


    //TODO: fix that. For some reason not every tile refactoring.
    private void MoveTileForward(){
        Debug.Log("move tile forward");
        Debug.Log(moveLineIndex);
        linesArray[moveLineIndex].transform.position = new Vector3(linesArray[moveLineIndex].transform.position.x + 80,
                                                                   linesArray[moveLineIndex].transform.position.y,
                                                                   linesArray[moveLineIndex].transform.position.z);
        if (moveLineIndex == 3) moveLineIndex = 0;
        moveLineIndex++;
    }


    public void ResetLinesToStartPosition()
    {
        for (int i = 0; i < linesArray.Length; i++)
        {
            linesArray[i].transform.position = setupLinesPositions[i]; 
        }
    }

}
