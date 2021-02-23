using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour {


    public TMP_Text PlayersList;
    public TMP_Text ScoreList;



    void Start () {


        if (PlayerPrefs.HasKey("BestScore"))
        {
            try
            {
                string json = PlayerPrefs.GetString("BestScore");
                PlayerDataList dataFromFile = JsonUtility.FromJson<PlayerDataList>(json);

                int number = 1;
                string nameList = "";
                string scoreList = "";

                foreach (PlayerData item in dataFromFile.players)
                {
                    nameList += number.ToString() + ". " + item.PlayerName + "\n";
                    scoreList += item.Score + "\n";
                    number++;
                }
               
                PlayersList.text = nameList;
                ScoreList.text = scoreList;

            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
                Debug.Log("Miss file for upload");

            }

        }

        
    }
	
	
}
