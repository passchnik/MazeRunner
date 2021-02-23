using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour {

    public GameObject cellPrefab;
    public BoxCollider2D EndTrigger;



	void Start ()
    {
        //RecursiveBacktracking mazeGenerator = new RecursiveBacktracking();

        //CellRB[,] maze = mazeGenerator.GenerateMaze();

        //Sidewinder mazeGenerator = new Sidewinder();

        //CellSidewinder[,] maze = mazeGenerator.GenerateMaze();

        //EllersAlgorithm ellersAlgorithm = new EllersAlgorithm();

        //CellEllers[,] maze = ellersAlgorithm.GenerateMaze();


        //BinaryTree mazeGenerator = new BinaryTree();

        //CellBT[,] maze = mazeGenerator.GenerateMaze();

        //for (int i = 0; i < maze.GetLength(0); i++)
        //{
        //    for (int j = 0; j < maze.GetLength(1); j++)
        //    {

        //        //int j = 0;
        //        CellProperties cp = Instantiate(cellPrefab, new Vector2(i, j), Quaternion.identity).GetComponent<CellProperties>();
                
        //        cp.LeftWall.SetActive(maze[i, j].LeftWall);
        //        cp.RightWall.SetActive(maze[i, j].RightWall);
        //        cp.BottomWall.SetActive(maze[i, j].BottomWall);
        //        cp.TopWall.SetActive(maze[i, j].TopWall);

        //        if (maze[i, j].End == true)
        //        {
        //            Instantiate(EndTrigger, new Vector2(i+0.5f, j+0.5f), Quaternion.identity).GetComponent<CellProperties>();
        //        }

        //    }
        //}

        


    }
	
}
