using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSquare : MonoBehaviour
{
    // Initializing defualt info
    //-------------------------------------
    // Square walls
    private bool _isLeftOpen = false;
    private bool _isTopOpen = false;
    private bool _isRightOpen = false;
    private bool _isBottomOpen = false;

    // Open Direction
    private Wall _openDirection = Wall.NONE;

    // Square size
    private float _width = 1;
    private float _length = 1;
    //-------------------------------------


    // Constructors
    public MazeSquare(float width, float length)
    {
        _width = width;
        _length = length;
    }

    // Methods
    //-------------------------------------

    /// <summary>
    /// Checks whether a direction has been assigned to this square. 
    /// </summary>
    /// <returns>Whether a direction is assigned</returns>
    public bool hasOpenDirection()
    {
        return _openDirection != Wall.NONE;
    }

    
    /// <summary>
    /// Assign a direction to a square. Throws an ArgumentException in case a Wall.NONE is 
    /// being assigned as a direction.
    /// </summary>
    /// <param name="direction">The opening direction of this area.</param>
    public void AssignOpenDirection(Wall direction)
    {
        if (direction == Wall.NONE)
            throw new ArgumentException("Can NOT assign Wall.NONE as a direction!");
        _openDirection = direction;
    }


    /// <summary>
    /// Get the open direction of this square. 
    /// </summary>
    /// <returns>The open direction, Can be Wall.NONE if it is not assigned. </returns>
    public Wall GetOpenDirection()
    {
        return _openDirection;
    }


    /// <summary>
    /// Open of the square walls directions. Throws an ArgumentExceotion in case a Wall.NONE is 
    /// recived as an argument. 
    /// </summary>
    /// <param name="direction">The direction to indicate as open.</param>
    public void openAWall(Wall direction)
    {
        if (direction == Wall.NONE)
            throw new ArgumentException("Can NOT open Wall.NONE since it is not a direction!");

        switch(direction)
        {
            case Wall.LEFT: // 0
            // case Wall.WEST: // 0
                _isLeftOpen = true;
                break;
            case Wall.TOP: // 1
            // case Wall.FORWARD: // 1
            // case Wall.NORTH: // 1
                _isTopOpen = true;
                break;
            case Wall.RIGHT: // 2
                _isRightOpen = true;
                break;
            case Wall.BOTTOM: // 3
            // case Wall.BACKWARD: // 3
            // case Wall.SOUTH: // 3
                _isBottomOpen = true;
                break;
        }
    }

    public bool hasOpenWalls()
    {

    }

    //-------------------------------------
}
