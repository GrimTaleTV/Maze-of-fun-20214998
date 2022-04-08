using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeCreator : MonoBehaviour
{
    LightSensor lightSensor = LightSensor.current;
    public GameObject horWall;
    public GameObject verWall;
    public GameObject floor;
    public int level = 2;

    // Start is called before the first frame update
    void Start()
    {
        float floorSize = floor.transform.localScale.x;
        // Debug.Log(LightSensor.current.lightLevel.scaleFactor);
        new MazeInfo( level, (floorSize / (level + 2)) );
        MazeInfo mazeInfo = MazeInfo.mazeInfo;

        _CreateEnvoirement();

        // Print the maze info
        /*for (int x = 0; x < mazeInfo.squaresInfo.GetLength(0); x++)
        {
            for(int y = 0; y < mazeInfo.squaresInfo.GetLength(1); y++)
            {
                Wall[] walls = mazeInfo.squaresInfo[x, y].GetUnchoosenDirections();

                if(walls != null)
                {
                    Wall direction = walls[Random.Range(0, walls.Length)];
                    mazeInfo.squaresInfo[x, y].AssignOpenDirection(direction);
                    Debug.Log("X: " + x + ", Y: " + y + ", Dir: " + _GetDirectionWallName(direction));
                    RemoveWall(x, y, direction);
                }

                walls = mazeInfo.squaresInfo[x, y].GetUnchoosenDirections();
                //Debug.Log("X: " + x + ", Y: " + y 
                 //   + ", Wall: ");
                
                /*for(int i = 0; i < walls.Length; i++)
                {
                    Debug.Log( _GetDirectionWallName(walls[i]) );
                }
            }
        }*/

        
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


    

    private void _CreateMaze()
    {
        MazeInfo mazeInfo = MazeInfo.mazeInfo;

        //_CreateEnvoirement();

        ArrayList tracker = new ArrayList();

        // Choose start location
        Vector2 start = new Vector2(
            Random.Range(0, mazeInfo.mazeSize),
            Random.Range(0, mazeInfo.mazeSize)
            );

        // Choose end location
        Vector2 end = new Vector2(
            Random.Range(0, mazeInfo.mazeSize),
            Random.Range(0, mazeInfo.mazeSize)
            );

        while(start.x == end.x && start.y == end.y)
        {
            end = new Vector2(
            Random.Range(0, mazeInfo.mazeSize),
            Random.Range(0, mazeInfo.mazeSize)
            );
        }

        int openedDirections = 0;

        /*while(openedDirections < mazeInfo.mazeSize * mazeInfo.mazeSize)
        {

        }*/




        // Print the maze info
        for (int x = 0; x < mazeInfo.squaresInfo.GetLength(0); x++)
        {
            for (int y = 0; y < mazeInfo.squaresInfo.GetLength(1); y++)
            {
                Wall[] walls = mazeInfo.squaresInfo[x, y].GetUnchoosenDirections();

                if (walls != null)
                {
                    Wall direction = walls[Random.Range(0, walls.Length)];
                    mazeInfo.squaresInfo[x, y].AssignOpenDirection(direction);
                    Debug.Log("X: " + x + ", Y: " + y + ", Dir: " + _GetDirectionWallName(direction));
                    RemoveWall(x, y, direction);
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


    GameObject[,] horWalls;
    GameObject[,] verWalls;

    private void _CreateEnvoirement()
    {
        float squareSize = MazeInfo.mazeInfo.squareSize;
        float startAt = -floor.transform.localScale.x / 2;
        Debug.Log(startAt);
        // Create the walls
        horWalls = new GameObject[MazeInfo.mazeInfo.mazeSize - 1, MazeInfo.mazeInfo.mazeSize /*- 1*/];
        verWalls = new GameObject[MazeInfo.mazeInfo.mazeSize - 1, MazeInfo.mazeInfo.mazeSize];
        for (int x = 0; x < verWalls.GetLength(0); x++)
        {
            for (int y = 0; y < verWalls.GetLength(1); y++)
            {
                horWalls[x, y] = Instantiate(horWall);
                horWalls[x, y].transform.position = new Vector3(
                    startAt + squareSize * (y + 1) - squareSize / 2,
                    2,
                    startAt + squareSize * (x + 1));
                Vector3 scale = horWalls[x, y].transform.localScale;
                scale.x = squareSize;
                horWalls[x, y].transform.localScale = scale;

                verWalls[x, y] = Instantiate(verWall);
                verWalls[x, y].transform.position = new Vector3(
                    startAt + squareSize * (x + 1),
                    2,
                    startAt + squareSize * (y + 1) - squareSize / 2);
                scale = verWalls[x, y].transform.localScale;
                scale.x = squareSize;
                verWalls[x, y].transform.localScale = scale;

            }
        }

        horWall.SetActive(false);
        verWall.SetActive(false);
    }


    public void RemoveWall(int x, int y, Wall direction)
    {
        /* There is only right and bottom walls
         * The square at the top_left_cornor has only right
         * and bottom direction open, so to remove one of those
         * walls the x and y should be the same.
         * The square one-y below has top, right, bottom
         * open directions, in case the top direction was chosen
         * the x is the same but the y is one less (y - 1)
         * If the square beside the top_left_cornor is chosen it
         * has left, right, bottom as open directions, if the left
         * were chosen, than the y is the same however, the x is
         * one less (x - 1)
         * 
         * top => y - 1 : VerWalls
         * bottom => y : VerWalls
         * right => x : HorWalls
         * left => x - 1 : HorWalls
         */

        Debug.Log("Before: X: " + x + ", Y: " +  y);

        switch(direction)
        {
            case Wall.LEFT:
                x -= 1;
                Debug.Log("After: X: " + x + ", Y: " + y);
                horWalls[x, y].SetActive(false);
                break;
            case Wall.RIGHT:
                Debug.Log("After: X: " + x + ", Y: " + y);
                horWalls[x, y].SetActive(false);
                break;
            case Wall.TOP:
                y -= 1;
                Debug.Log("After: X: " + x + ", Y: " + y);
                verWalls[y, x].SetActive(false);
                break;
            case Wall.BOTTOM:
                Debug.Log("After: X: " + x + ", Y: " + y);
                verWalls[y, x].SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(lightSensor.lightLevel.scaleFactor);
    }
}
