using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameManager GameManager;

    public float localTime = 0f;

    private Slider Slider;

    public void Start()
    {
        Slider = GetComponent<Slider>();
        localTime = Slider.value = Slider.maxValue;
    }

    void FixedUpdate ()
    {
        localTime = GetComponent<Slider>().value -= 1 * Time.deltaTime;

        if (localTime  < 0.01f && localTime > -0.01)
        {
            GameManager.GameOver();
        }
    }

}
