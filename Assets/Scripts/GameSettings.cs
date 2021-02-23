using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameSettings : MonoBehaviour {

    public bool InfinityMode;
    public string PlayerName;
    public TMP_InputField TMP_InputField;
    public Toggle toggle;

    public void Start()
    {
        PlayerSettings settings = GameSettingsData.GetSettings();
        InfinityMode = settings.InfinityMode;
        toggle.isOn = InfinityMode;
        PlayerName = settings.PlayerName;
        TMP_InputField.text = PlayerName;
       

    }

    public void NameChange(string name)
    {
        PlayerName = name;
    }


    public void InfinityModeChange(bool value)
    {
        InfinityMode = value;
    }


    public void SaveSettings()
    {
        PlayerSettings playerSettings = new PlayerSettings(InfinityMode, PlayerName);
        GameSettingsData.SaveSetting(playerSettings);

    }

}
