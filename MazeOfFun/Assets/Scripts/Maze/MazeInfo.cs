using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInfo
{
    public static MazeInfo mazeInfo;

    public MazeSquare[,] squaresInfo;
    
    /// <summary>
    /// Create a maze info using singleton pattern. 
    /// </summary>
    /// <param name="level">The value should be greater than zero. </param>
    public MazeInfo(int level)
    {
        // Syncronization to avoid the creation of two mazes at the same time
        lock(this)
        {
            // Singleton pattern
            if(mazeInfo == null && level > 0)
            {
                _InitialiseMazeSquaresInfo(level);
                mazeInfo = this;
            }
        }
    }


    private void _InitialiseMazeSquaresInfo(int level)
    {
        squaresInfo = new MazeSquare[level, level];
    }

    
}
