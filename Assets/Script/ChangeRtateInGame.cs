using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRtateInGame : MonoBehaviour
{
    public MoveAndTurn MoveAndTurn;

    public void Up()
    {
        MoveAndTurn.speedRotate +=5;
    }

    public void Down()
    {
        MoveAndTurn.speedRotate -= 5;
    }
}
