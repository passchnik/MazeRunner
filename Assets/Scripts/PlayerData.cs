using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : IComparable<PlayerData>
{

    public int Score;
    public string PlayerName;

    public PlayerData(string playerName,  int score)
    {
        Score = score;
        PlayerName = playerName;
    }

    public int CompareTo(PlayerData obj)
    {
        return obj.Score.CompareTo(Score);
    }
}


public class PlayerDataList
{

    public List<PlayerData> players;
    public PlayerDataList(List<PlayerData> datas)
    {
        players = datas;
    }

}



