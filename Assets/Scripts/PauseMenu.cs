using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool IsPaused = false;

    public GameObject PausePanel;
    public GameObject GameUI;

 

    public void Resume()
    {
        IsPaused = false;
        PausePanel.SetActive(IsPaused);
        GameUI.SetActive(!IsPaused);
        Time.timeScale = 1f;
    }

    public void StopTheGame()
    {
        IsPaused = true;
        PausePanel.SetActive(IsPaused);
        GameUI.SetActive(!IsPaused);
        Time.timeScale = 0f;
    }

}
