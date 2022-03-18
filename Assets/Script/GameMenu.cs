using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    
    public Text scoreOnFinish;
    public Text timeOnFinish;
    public MoveAndTurn MoveAndTurn;
    public GameObject CanvasGameOver;
    public CanvasSystem CanvasSystem;
    public ScoreAndTime ScoreAndTime;
    public TestChoiseControl TestChoiseControl;
    public ControlOption ControlOption;
    

    public State CurrentState { get; private set; }
    public enum State
    {
        Playing,
        Won,
    }


    private void Start()
    {

        if (TestChoiseControl.A==1)
        {
            //print("Test from option " + TestChoiseControl.A);
            ControlOption.ChoiceButtonControl();
        }
        else
        {
           // print("Test from option " + TestChoiseControl.A);
            ControlOption.ChoiceSliderControl();
        }
    }

    public void OnPlayerRaechFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        MoveAndTurn.maxSpeed = 0;
        PlayerPrefs.SetFloat("maxSpeed", MoveAndTurn.maxSpeed);
        PlayerPrefs.Save();
        string _stringSeconds = ScoreAndTime.GameSeconds.ToString("f0");
        string _stringMinutes = ScoreAndTime.GameMinutes.ToString("f0");
        timeOnFinish.text = "Your win Time: " + _stringMinutes + ":" + _stringSeconds;
        scoreOnFinish.text = "Your win Score: " + ScoreAndTime.score.ToString();
        CanvasGameOver.SetActive(!CanvasGameOver.activeSelf);
        CanvasSystem.CanvasInGame.SetActive(!CanvasSystem.CanvasInGame.activeSelf);
        CanvasSystem.controlCanvas.SetActive(!CanvasSystem.controlCanvas.activeSelf);
    }

    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


