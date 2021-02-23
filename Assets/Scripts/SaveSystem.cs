using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public static class SaveSystem {

    public static void SavePlayer(PlayerData data)
    {

        if (PlayerPrefs.HasKey("BestScore"))
        {
            try
            {
                
                string json = PlayerPrefs.GetString("BestScore") ;
                PlayerDataList dataFromFile = JsonUtility.FromJson<PlayerDataList>(json);

                dataFromFile.players.Add(data);

                dataFromFile.players.Sort();

                if (dataFromFile.players.Count > 10)
                {
                    dataFromFile.players.RemoveAt(dataFromFile.players.Count - 1);
                }

             

                json = JsonUtility.ToJson(dataFromFile);
                PlayerPrefs.SetString("BestScore", json);
                PlayerPrefs.Save();

              


            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                Debug.Log("Miss file for saving");
            }
            
            

        }
        else
        {
            //FileStream stream = new FileStream(path, FileMode.Create);
            List<PlayerData> list = new List<PlayerData>();
            list.Add(data);

            PlayerDataList playerDataList = new PlayerDataList(list);
            string json = JsonUtility.ToJson(playerDataList);
            PlayerPrefs.SetString("BestScore", json);
            PlayerPrefs.Save();

            //PlayerDataList dataFromFile = new PlayerDataList(list); 
            //formatter.Serialize(stream, dataFromFile);
            
            //stream.Close();
        }

        
    }

}
