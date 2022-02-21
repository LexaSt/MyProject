using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    
    public Text scoreOnFinish;
    public Text timeOnFinish;
    //public Moving moving;//в дальнейшем заменить на MOveAndTurn
    public MoveAndTurn MoveAndTurn;
    public GameObject CanvasGameOver;
    public CanvasSystem CanvasSystem;
    public ScoreAndTime ScoreAndTime;
    

    public State CurrentState { get; private set; }
    public enum State
    {
        Playing,
        Won,
    }


    public void OnPlayerRaechFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        //moving.maxSpeed = 0;//в дальнейшем заменить на MOveAndTurn
       // MoveAndTurn.maxSpeed = 0;
        string _stringSeconds = ScoreAndTime.GameSeconds.ToString("f0");
        string _stringMinutes = ScoreAndTime.GameMinutes.ToString("f0");
        timeOnFinish.text = "Your win Time: " + _stringMinutes + ":" + _stringSeconds;
        scoreOnFinish.text = "Your win Score: " + ScoreAndTime.score.ToString();
        CanvasGameOver.SetActive(!CanvasGameOver.activeSelf);
        CanvasSystem.CanvasInGame.SetActive(!CanvasSystem.CanvasInGame.activeSelf);      
    }

    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


