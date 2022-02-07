using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSystem : MonoBehaviour
{
    public GameObject CanvasStart;
    public GameObject CanvasInGame;
    //public GameObject CanvasGameOver;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    //public Moving moving;



    public void ActiveCanvasStart()
    {
        StartCoroutine(TimeToStart());
    }

   


    IEnumerator TimeToStart()
    {
       
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


    }
}



   
