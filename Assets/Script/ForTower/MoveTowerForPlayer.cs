using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowerForPlayer : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("TargerForTower").transform;
    }

    private void Update()
    {
        this.transform.LookAt(target);
  
    }
}
