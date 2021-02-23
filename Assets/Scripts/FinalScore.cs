using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScore : MonoBehaviour {

    public void SetFainalScore(int finalScore)
    {
        GetComponent<TextMeshProUGUI>().text = finalScore.ToString();
    }
}
