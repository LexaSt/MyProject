using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public float score = 0;
    public Text text;
    public Text scoreOnFinish;
    public Moving moving;
    public GameObject CanvasGameOver;
    public CanvasSystem CanvasSystem;
    



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
    public Text timeOnFinish;

    public void GetScore()
    {
        score++;
    }

    public void OnPlayerRaechFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        moving.maxSpeed = 0;
        stringSeconds = GameSeconds.ToString("f0");
        stringMinutes = GameMinutes.ToString("f0");
        timeOnFinish.text = "Yore win Time: " + stringMinutes + ":" + stringSeconds;
        scoreOnFinish.text = "Yore win Score: " + score.ToString();
        CanvasGameOver.SetActive(!CanvasGameOver.activeSelf);
        CanvasSystem.CanvasInGame.SetActive(!CanvasSystem.CanvasInGame.activeSelf);
       
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

    IEnumerator TimerToStart() // ??????????? ?????? ??????? ?? 3 ???, ???? ???? ?????? ??????? ? Canvas
    {

        yield return new WaitForSeconds(3f);
        Timer();
    }


        private void Update()
    {
        StartCoroutine(TimerToStart());
        text.text = "Score: " + score.ToString();
        
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


