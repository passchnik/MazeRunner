using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBT : Cell
{
    public int DistanceFromStart;
}

public class BinaryTree
{
    private int Width;
    private int Height;

    public BinaryTree(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public CellBT[,] GenerateMaze()
    {
        var CellArray = new CellBT[Width, Height];

        for (int x = 0; x < CellArray.GetLength(0); x++)
        {
            for (int y = 0; y < CellArray.GetLength(1); y++)
            {
                CellArray[x, y] = new CellBT { X = x, Y = y };
            }

        }

        for (int x = 0; x < CellArray.GetLength(0); x++)
        {
            for (int y = 0; y < CellArray.GetLength(1); y++)
            {
                CellArray[x, y].RightWall = false;
                CellArray[x, y].BottomWall = false;

            }

        }


        foreach (var cell in CellArray)
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                cell.TopWall = false;

            }
            else
            {
                cell.LeftWall = false;
            }
        }

        for (int y = 0; y < Height; y++)
        {
            CellArray[0, y].TopWall = false;
            CellArray[0, y].LeftWall = true;
        }


        for (int x = 0; x < Width; x++)
        {
            CellArray[x, Height - 1].TopWall = true;
            CellArray[x, Height - 1].LeftWall = false;

        }



        for (int y = 0; y < Height; y++)
        {
            CellArray[Width - 1, y].RightWall = true;
        }

        MazeExit(CellArray);


        for (int x = 0; x < Width; x++)
        {
            CellArray[x, 0].BottomWall = true;
        }
        CellArray[0, CellArray.GetLength(1) - 1].LeftWall = true;


        return CellArray;


    }

    private void MazeExit(CellBT[,] cellArray)
    {

        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            cellArray[Width - UnityEngine.Random.Range(1, 4), 0].End = true;
        }
        else
        {
            cellArray[Width - 1, UnityEngine.Random.Range(1, 5)].End = true;
        }


    }



}
