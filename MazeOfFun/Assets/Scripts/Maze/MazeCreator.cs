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
        new MazeInfo(1000, 5);
        MazeInfo mazeInfo = MazeInfo.mazeInfo;
        // Print the maze info
        for(int x = 0; x < mazeInfo.squaresInfo.GetLength(0); x++)
        {
            for(int y = 0; y < mazeInfo.squaresInfo.GetLength(1); y++)
            {
                Wall[] walls = mazeInfo.squaresInfo[x, y].GetUnchoosenDirections();

                if(walls != null)
                {
                    Wall direction = walls[Random.Range(0, walls.Length)];
                    mazeInfo.squaresInfo[x, y].AssignOpenDirection(direction);
                    Debug.Log("X: " + x + ", Y: " + y + ", Dir: " + _GetDirectionWallName(direction));
                }

                walls = mazeInfo.squaresInfo[x, y].GetUnchoosenDirections();
                //Debug.Log("X: " + x + ", Y: " + y 
                 //   + ", Wall: ");
                
                /*for(int i = 0; i < walls.Length; i++)
                {
                    Debug.Log( _GetDirectionWallName(walls[i]) );
                }*/
            }
        }
    }

    private string _GetDirectionWallName(Wall direction)
    {
        string name = "";

        switch (direction)
        {
            case Wall.LEFT:
                name = "Wall.LEFT";
                break;
            case Wall.TOP:
                name = "Wall.TOP";
                break;
            case Wall.RIGHT:
                name = "Wall.RIGHT";
                break;
            case Wall.BOTTOM:
                name = "Wall.BOTTOM";
                break;
        }

        return name;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(lightSensor.lightLevel.scaleFactor);
    }
}
