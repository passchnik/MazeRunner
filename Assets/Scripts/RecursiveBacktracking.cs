using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CellRB : Cell
{

    public bool _visited = false;

    public int DistanceFromStart;


}

public class RecursiveBacktracking
{
    private int Width;
    private int Height;

    public RecursiveBacktracking(int width, int height)
    {
        Width = width + 1;
        Height = height + 1;
    }

    public CellRB[,] GenerateMaze()
    {
        var CellArray = new CellRB[Width, Height];

        for (int x = 0; x < CellArray.GetLength(0); x++)
        {
            for (int y = 0; y < CellArray.GetLength(1); y++)
            {
                CellArray[x, y] = new CellRB { X = x, Y = y };
            }

        }

        for (int x = 0; x < CellArray.GetLength(0); x++)
        {
            for (int y = 0; y < CellArray.GetLength(1); y++)
            {
                CellArray[x, y].RightWall = false;
                CellArray[x, y].TopWall = false;

            }

        }


        for (int i = 0; i < CellArray.GetLength(0); i++)
        {
            CellArray[i, Height - 1].LeftWall = false;
        }

        for (int i = 0; i < CellArray.GetLength(1); i++)
        {
            CellArray[Width - 1, i].BottomWall = false;
        }

        RemoveWalls(CellArray);

        MazeExit(CellArray);


        return CellArray;
    }



    private void RemoveWalls(CellRB[,] maze)
    {

        CellRB current = maze[0, 0];
        current._visited = true;
        current.DistanceFromStart = 0;

        Stack<CellRB> stack = new Stack<CellRB>();

        do
        {
            List<CellRB> unvisitedNeighbours = new List<CellRB>();

            if (current.X > 0 && !maze[current.X - 1, current.Y]._visited)
            {
                unvisitedNeighbours.Add(maze[current.X - 1, current.Y]);
            }

            if (current.Y > 0 && !maze[current.X, current.Y - 1]._visited)
            {
                unvisitedNeighbours.Add(maze[current.X, current.Y - 1]);
            }

            if (current.X < Width - 2 && !maze[current.X + 1, current.Y]._visited)
            {
                unvisitedNeighbours.Add(maze[current.X + 1, current.Y]);
            }

            if (current.Y < Height - 2 && !maze[current.X, current.Y + 1]._visited)
            {
                unvisitedNeighbours.Add(maze[current.X, current.Y + 1]);
            }

            if (unvisitedNeighbours.Count > 0)
            {
                int rnd = UnityEngine.Random.Range(0, unvisitedNeighbours.Count);

                CellRB chosen = unvisitedNeighbours[rnd];
                RemoveWall(current, chosen);
                chosen._visited = true;
                stack.Push(chosen);
                current = chosen;
                chosen.DistanceFromStart = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);



    }

    private void RemoveWall(CellRB current, CellRB chosen)
    {
        if (current.X == chosen.X)
        {
            if (current.Y > chosen.Y)
            {
                current.BottomWall = false;
            }
            else
            {
                chosen.BottomWall = false;
            }

        }
        else
        {
            if (current.X > chosen.X)
            {
                current.LeftWall = false;
            }
            else
            {
                chosen.LeftWall = false;
            }
        }
    }

    private void MazeExit(CellRB[,] cellArray)
    {

        //for (int i = 0; i < cellArray.GetLength(0); i++)
        //{
        //    for (int j = 0; j < cellArray.GetLength(1); j++)
        //    {
        //        max = (cellArray[i, j].DistanceFromStart > max.DistanceFromStart) ? cellArray[i, j]: max;
        //    }
        //}

        CellRB max = cellArray[0, 0];

        for (int x = 0; x < cellArray.GetLength(0); x++)
        {
            if (cellArray[x, Height - 2].DistanceFromStart > max.DistanceFromStart) max = cellArray[x, Height - 2];
            if (cellArray[x, 0].DistanceFromStart > max.DistanceFromStart) max = cellArray[x, 0];
        }

        for (int y = 0; y < cellArray.GetLength(1); y++)
        {
            if (cellArray[Width - 2, y].DistanceFromStart > max.DistanceFromStart) max = cellArray[Width - 2, y];
            if (cellArray[0, y].DistanceFromStart > max.DistanceFromStart) max = cellArray[0, y];
        }

        cellArray[max.X, max.Y].End = true;

    }


}
