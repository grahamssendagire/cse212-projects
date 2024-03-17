/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then display "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private Dictionary<(int, int), (bool, bool, bool, bool)> maze;
    private int _currX;
    private int _currY;

    public Maze(Dictionary<(int, int), (bool, bool, bool, bool)> maze, int startX, int startY)
    {
        this.maze = maze;
        _currX = startX;
        _currY = startY;
    }

    public void MoveLeft()
    {
        if (maze.ContainsKey((_currX - 1, _currY)) && maze[(_currX - 1, _currY)].Item2)
        {
            _currX--;
        }
    }

    public void MoveRight()
    {
        if (maze.ContainsKey((_currX + 1, _currY)) && maze[(_currX + 1, _currY)].Item1)
        {
            _currX++;
        }
    }

    public void MoveUp()
    {
        if (maze.ContainsKey((_currX, _currY - 1)) && maze[(_currX, _currY - 1)].Item4)
        {
            _currY--;
        }
    }

    public void MoveDown()
    {
        if (maze.ContainsKey((_currX, _currY + 1)) && maze[(_currX, _currY + 1)].Item3)
        {
            _currY++;
        }
    }
}