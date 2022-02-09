using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndTime : MonoBehaviour
{
    public float score = 0;
    public Text text;
    //public Text scoreOnFinish;
    public float GameSeconds;
    public float GameMinutes;
    string stringSeconds;
    string stringMinutes;
    public Text time;
    //public Text timeOnFinish;
    public GameMenu GameMenu;


    public void GetScore()
    {
        score++;
    }

    public void Timer()
    {
        GameSeconds = GameSeconds + Time.deltaTime;
        stringSeconds = GameSeconds.ToString("f0");
        stringMinutes = GameMinutes.ToString("f0");
        time.text = "Time: " + stringMinutes + ":" + stringSeconds;

        if (GameSeconds >= 60.0f)
        {
            GameMinutes = GameMinutes + 1.0f;
            GameSeconds = 0.0f;
        }

        if (GameMinutes >= 24.0f)
        {
            GameMinutes = 0.0f;
        }
    }

    IEnumerator TimerToStart() // откладывает начало таймера на 3 сек, пока идет отсчет времени в Canvas
    {
        yield return new WaitForSeconds(3f);
        Timer();
    }


    private void Update()
    {
        StartCoroutine(TimerToStart());
        text.text = "Score: " + score.ToString();
    }
}


