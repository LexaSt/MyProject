using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRtateInGame : MonoBehaviour
{
    public MoveAndTurn MoveAndTurn;

    public void UpTurn()
    {
        MoveAndTurn.speedRotate +=5;
        PlayerPrefs.SetFloat("turn", MoveAndTurn.speedRotate);
        PlayerPrefs.Save();
    }

    public void DownTurn()
    {
        MoveAndTurn.speedRotate -= 5;
        PlayerPrefs.SetFloat("turn", MoveAndTurn.speedRotate);
        PlayerPrefs.Save();
    }

    public void UpSpeed()
    {
        MoveAndTurn.maxSpeed += 0.1f;
        PlayerPrefs.SetFloat("maxSpeed", MoveAndTurn.maxSpeed);
        PlayerPrefs.Save();
    }
    public void DownSpeed()
    {
        MoveAndTurn.maxSpeed -= 0.1f;
        PlayerPrefs.SetFloat("maxSpeed", MoveAndTurn.maxSpeed);
        PlayerPrefs.Save();
    }

    private void Update()
    {
       // MoveAndTurn.maxSpeed= PlayerPrefs.GetFloat("maxSpeed");
        //MoveAndTurn.speedRotate = PlayerPrefs.GetFloat("turn");
    }
}
