using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour {

    private int score;

    public void ChangeScore(int scoreInt)
    {
        score = scoreInt;
        GetComponent<TextMeshProUGUI>().text = "SCORE: " + score.ToString();
    }

    public void SaveScore(string playerName)
    {
        PlayerData player = new PlayerData(playerName, score);
        
        SaveSystem.SavePlayer(player);

    }

}
