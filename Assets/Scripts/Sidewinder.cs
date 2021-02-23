using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CellSidewinder : Cell
{
   

}


public class Sidewinder
{
    private int Width;
    private int Height;


    public Sidewinder(int width, int height)
    {
        Width = width;
        Height = height;
    }


    public CellSidewinder[,] GenerateMaze()
    {
        var CellArray = new CellSidewinder[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                CellArray[x, y] = new CellSidewinder { X = x, Y = y };
            }

        }

        for (int x = 0; x < CellArray.GetLength(0); x++)
        {
            for (int y = 0; y < CellArray.GetLength(1); y++)
            {
                CellArray[x, y].LeftWall = false;
                CellArray[x, y].BottomWall = false;

            }

        }



        for (int x = 0; x < Width; x++)
        {
            List<CellSidewinder> list = new List<CellSidewinder>();

            list.Add(CellArray[x, 0]);

            for (int y = 0; y < Height; y++)
            {
                if (y == Height - 1)
                {
                    if (list.Count == 0)
                    {
                        CellArray[x, y].RightWall = false;
                    }
                    else
                    {
                        list.Add(CellArray[x, y]);
                        int rnd = UnityEngine.Random.Range(0, list.Count);
                        list[rnd].RightWall = false;
                        list.Clear();
                    }

                    continue;
                }

                if (UnityEngine.Random.Range(0, 2) == 1)
                {
                    CellArray[x, y].TopWall = false;
                    list.Add(CellArray[x, y]);
                }
                else
                {
                    if (list.Count == 0)
                    {
                        CellArray[x, y].RightWall = false;
                    }
                    else
                    {
                        list.Add(CellArray[x, y]);
                        int rnd = UnityEngine.Random.Range(0, list.Count);
                        list[rnd].RightWall = false;
                        list.Clear();
                    }


                }


            }
            list.Clear();
        }



        for (int y = 0; y < Height; y++)
        {          
            CellArray[Width - 1, y].TopWall = false;
            CellArray[Width - 1, y].RightWall = true;
        }


        MazeExit(CellArray);

        ArrayReverse(ref CellArray);

        for (int y = 0; y < Height; y++)
        {
            CellArray[Width - 1, y].RightWall = true;
        }

        for (int x = 0; x < Width; x++)
        {
            CellArray[x, 0].BottomWall = true;
        }

        CellArray[0, Height - 1].LeftWall = true;
        CellArray[0, Height - 1].TopWall = true;
        CellArray[Width - 1, Height - 1].TopWall = true;

        




        return CellArray;
    }

    private void ArrayReverse(ref CellSidewinder[,] CellArray)
    {

        for (int i = 0; i < CellArray.GetLength(1); i++)
        {
            CellSidewinder[] temp = new CellSidewinder[CellArray.GetLength(0)];

            for (int j = 0; j < CellArray.GetLength(0); j++)
            {
                temp[j] = CellArray[j, i];
            }

            Array.Reverse(temp);

            for (int j = 0; j < CellArray.GetLength(0); j++)
            {
                CellArray[j, i] = temp[j];

                if (temp[j].RightWall == true) { CellArray[j, i].LeftWall = true ; CellArray[j, i].RightWall = false; }
            }
        }

    }

    private void MazeExit(CellSidewinder[,] cellArray)
    {
        int rnd = UnityEngine.Random.Range(0, cellArray.GetLength(1)-1);
        cellArray[0, rnd].End = true;
    }

}
