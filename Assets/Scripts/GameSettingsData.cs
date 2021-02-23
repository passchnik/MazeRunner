using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettingsData
{
    public static void SaveSetting(PlayerSettings playerSettings)
    {
      
            string json = JsonUtility.ToJson(playerSettings);
            PlayerPrefs.SetString("GameSettings", json);
            PlayerPrefs.Save();

            //string json = PlayerPrefs.GetString("GameSettings");
            //PlayerDataList dataFromFile = JsonUtility.FromJson<PlayerDataList>(json);

            //dataFromFile.players.Add(data);

            //if (dataFromFile.players.Count > 10)
            //{
            //    dataFromFile.players.RemoveAt(dataFromFile.players.Count - 1);
            //}

            //dataFromFile.players.Sort();

            //json = JsonUtility.ToJson(dataFromFile);
            //PlayerPrefs.SetString("GameSettings", json);
            //PlayerPrefs.Save();
     
    }

    public static PlayerSettings GetSettings()
    {
        PlayerSettings playerSettings;

        if (PlayerPrefs.HasKey("GameSettings"))
        {
            string json = PlayerPrefs.GetString("GameSettings");
            PlayerSettings dataFromFile = JsonUtility.FromJson<PlayerSettings>(json);
            playerSettings = dataFromFile;
            PlayerPrefs.Save();

        }
        else
        {
            playerSettings = new PlayerSettings(false, "Player");
        }


        return playerSettings;
    }

}
