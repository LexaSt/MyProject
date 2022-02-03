using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public float score = 0;
    public Text text;
    public Moving moving;


    public State CurrentState { get; private set; }
    public enum State
    {
        Playing,
        Won,
    }

    public float GameSeconds;
    public float GameMinutes;
    string stringSeconds;
    string stringMinutes;
    public Text time;

    public void GetScore()
    {
        score++;
    }

    public void OnPlayerRaechFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        moving.maxSpeed = 0;
        print("WINNER");
        print(stringMinutes + " : " + stringSeconds);
        
    }

    public void Timer()
    {
        if (CurrentState == State.Won)
            return;

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


        private void Update()
    {
        Timer();
        text.text = "Score: " + score.ToString();

        
    }
}


