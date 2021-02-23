using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerSettings  {


    public bool InfinityMode;
    public string PlayerName;

    public PlayerSettings(bool infinity, string name)
    {
        InfinityMode = infinity;
        PlayerName = name;
    }

}
