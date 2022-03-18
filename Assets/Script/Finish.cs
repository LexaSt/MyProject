using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public MoveAndTurn MoveAndTurn;
    public ChangeRtateInGame ChangeRtateInGame;
    private GameObject Player;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RedCube redCube))
        {
            MoveAndTurn.moveForce = new Vector3(0, 0, 0);
            Player.transform.position = MoveAndTurn.startPosition;
            redCube.transform.position = redCube.startPositionRedCube;
        }
    }
}
