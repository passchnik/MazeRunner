using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public int LevelNumber;
    public GameObject cellPrefab;
    public BoxCollider2D EndTrigger;
    public Score Score;
    public FinalScore FinalScore;
    public GameObject GameCanvas;
    public GameObject MenuCanvas;
    public GameObject TimeLine;
    public GameObject WatchPicture;
    public GameObject ScoreText;
    public TMP_Text TextLevelNumber;
    public int TimeForAlgorithm = 20;

    [SerializeField]
    private int scoreInt;
    
    private string mazeName;
    private string playerName;
    private bool newAlgorithm = true;
    private bool infinityMode;
    private int Width = 38;
    private int Height = 18;


    void Start ()
    {
        UploadPlayerSettings();
        ChangePlayerPosition();
        LevelNumber = 1;
        NextLevelGenerate();
        scoreInt = 0;
        Score.ChangeScore(scoreInt);
    }


    private void UploadPlayerSettings()
    {
        PlayerSettings gameSettings = GameSettingsData.GetSettings();
        playerName = gameSettings.PlayerName;
        infinityMode = gameSettings.InfinityMode;
        TimeLine.SetActive(!infinityMode);
        WatchPicture.SetActive(!infinityMode);
        ScoreText.SetActive(!infinityMode);
    }


    public void NextLevelGenerate()
    {
        if (!infinityMode)
        {
            CalculateScore();
        }

        TextLevelNumber.text = "Level " + LevelNumber.ToString();

        if (LevelNumber > 5)
        {
            mazeName = "Backtracking";
            newAlgorithm = true;
        }
        else if (LevelNumber > 2)
        {
            mazeName = "Sidewinder";
            newAlgorithm = true;
        }
        else
        {
            mazeName = "BinaryTree";
            newAlgorithm = true;
        }

        

        GenerateMaze();

        if (infinityMode == false)
        {
            ChangeTime(ChooseTime());
            FindObjectOfType<Timer>().Start();
        }


        Debug.Log(mazeName + ". Alghorithm time = " + TimeForAlgorithm);
        
        LevelNumber++;
        ChangePlayerPosition();
    }


    private void ChangeTime(int NextTime)
    {
        FindObjectOfType<Slider>().maxValue = NextTime;
        FindObjectOfType<Slider>().value = NextTime;
    }

    private int ChooseTime()
    {
        int thisTime = Convert.ToInt32(FindObjectOfType<Slider>().value);
        int thisMaxTime = Convert.ToInt32(FindObjectOfType<Slider>().maxValue);
        int difference = thisMaxTime - thisTime;
        int nextTime;
        int temp;
        int mazeMaxTime = 0;
        int mazeMinAvrTime = 0;



        switch (mazeName)
        {
            case "Backtracking":
                {
                    mazeMaxTime = 80;
                    mazeMinAvrTime = 7;
                }
                break;
            case "Sidewinder":
                {
                    mazeMaxTime = 40;
                    mazeMinAvrTime = 5;
                };
                break;
            case "BinaryTree":
                {
                    mazeMaxTime = 30;
                    mazeMinAvrTime = 4;
                }
                break;
            default:
                Debug.Log("Unknown algorithm");
                break;
        }

        if (newAlgorithm)
        {
            nextTime = mazeMaxTime;
            newAlgorithm = false;
        }

        else
        {
            temp = (mazeMinAvrTime < difference) ? thisMaxTime - difference + mazeMinAvrTime : thisMaxTime + difference + mazeMinAvrTime;
            nextTime = (temp > (mazeMaxTime * 1.2)) ? (int)(mazeMaxTime * 1.2) : temp;
            TimeForAlgorithm = nextTime;
        }


        return nextTime;
    }

    public void GameOver()
    {
        player.GetComponentInChildren<PlayerMove>().enabled = false;
        Score.SaveScore(playerName);
        GameCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        FinalScore.SetFainalScore(scoreInt);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void CalculateScore()
    {
        int loacalScore = 0;

        switch (mazeName)
        {
            case "Backtracking":
                {
                    //     алгоритм   номер рівня             час проходження
                    loacalScore = 5 + LevelNumber * 10  + Convert.ToInt32(FindObjectOfType<Timer>().localTime);
                }
                break;
            case "Sidewinder":
                {
                    loacalScore = 3 + LevelNumber * 10 + Convert.ToInt32(FindObjectOfType<Timer>().localTime);
                };
                break;
            case "BinaryTree":
                {
                    loacalScore = 1 + LevelNumber * 10 + Convert.ToInt32(FindObjectOfType<Timer>().localTime);
                }
                break;
            default:
                Debug.Log("Unknown algorithm");
                break;
        }

        if (LevelNumber > 0)
        {
            scoreInt += loacalScore;
        }

        Score.ChangeScore(scoreInt); 
        

    }

    private void ChangePlayerPosition()
    {
        player.GetComponent<Transform>().position = new Vector2(0.5f, 0.5f);
    }



    private void GenerateMaze()
    {

        switch (mazeName)
        {
            case "Backtracking":
                {
                    RecursiveBacktracking mazeGenerator = new RecursiveBacktracking(Width, Height);
                    CellRB[,] maze = mazeGenerator.GenerateMaze();
                    SpawnMaze(maze);
                }
                break;
            case "Sidewinder":
                {
                    Sidewinder mazeGenerator = new Sidewinder(Width, Height);
                    CellSidewinder[,] maze = mazeGenerator.GenerateMaze();
                    SpawnMaze(maze);
                };
                break;
            case "BinaryTree":
                {
                    BinaryTree mazeGenerator = new BinaryTree(Width, Height);
                    CellBT[,] maze = mazeGenerator.GenerateMaze();
                    SpawnMaze(maze);
                }
                break;
            default:
                Debug.Log("Unknown algorithm");
                break;
        }


    }



    


    private void SpawnMaze(Cell[,] maze)
    {


        if (LevelNumber > 0)
        {
            GameObject[] gos = FindObjectsOfType<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.tag == "Cell" || go.tag == "Trigger")
                {
                    Destroy(go);
                }
            }

        }


        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {

                CellProperties cp = Instantiate(cellPrefab, new Vector2(i, j), Quaternion.identity).GetComponent<CellProperties>();

                cp.LeftWall.SetActive(maze[i, j].LeftWall);
                cp.RightWall.SetActive(maze[i, j].RightWall);
                cp.BottomWall.SetActive(maze[i, j].BottomWall);
                cp.TopWall.SetActive(maze[i, j].TopWall);

                if (maze[i, j].End == true)
                {
                    Instantiate(EndTrigger, new Vector2(i + 0.5f, j + 0.5f), Quaternion.identity).GetComponent<CellProperties>();
                }

            }
        }

    }


    
}
