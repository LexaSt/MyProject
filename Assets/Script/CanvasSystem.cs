using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSystem : MonoBehaviour
{
    public GameObject CanvasStart;
    public GameObject CanvasInGame;
    public GameObject controlCanvas;
   // public GameObject CanvasGameOver;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
   // public GameObject score;
    //public GameObject time;
    //public GameObject backToMenu;
    //public GameObject rest;

    //public MoveAndTurn MoveAndTurn;
    //public ControlOption ControlOption;
    //public UIbutton choiceButtonControl;
    //public UIbutton choiceSliderControl;

    public void ActiveCanvasStart()
    {
            StartCoroutine(TimeToStart());
    }

    IEnumerator TimeToStart()
    {
        text3.SetActive(!text3.activeSelf);
        yield return new WaitForSeconds(1f);
        text2.SetActive(!text2.activeSelf);
        yield return new WaitForSeconds(1f);
        text1.SetActive(!text1.activeSelf);
        yield return new WaitForSeconds(1f);
        text4.SetActive(!text4.activeSelf);
        yield return new WaitForSeconds(0.5f);
        Destroy(text1);
        Destroy(text2);
        Destroy(text3);
        Destroy(text4);
        CanvasStart.SetActive(!CanvasStart.activeSelf);
        CanvasInGame.SetActive(!CanvasInGame.activeSelf);
        controlCanvas.SetActive(!controlCanvas.activeSelf);
        //score.SetActive(!score.activeSelf);
        //time.SetActive(!time.activeSelf);
        //rest.SetActive(!rest.activeSelf);
        //backToMenu.SetActive(!backToMenu.activeSelf);


    }
}



   
