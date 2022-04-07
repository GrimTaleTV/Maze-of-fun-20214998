using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeCreator : MonoBehaviour
{
    LightSensor lightSensor = LightSensor.current;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(LightSensor.current.lightLevel.scaleFactor);
        new MazeInfo(1, 5);
        MazeInfo mazeInfo = MazeInfo.mazeInfo;
        // Print the maze info
        for(int x = 0; x < mazeInfo.squaresInfo.GetLength(0); x++)
        {
            for(int y = 0; y < mazeInfo.squaresInfo.GetLength(1); y++)
            {
                Debug.Log("X: " + x + ", Y: " + y 
                    + ", Walls" + mazeInfo.squaresInfo[x, y].GetUnchoosenDirections().Length);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(lightSensor.lightLevel.scaleFactor);
    }
}
