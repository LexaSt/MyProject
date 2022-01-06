using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private float CameraSpeed = 100f;
    public Vector3 offSet;

    private void Update()
    {
        Vector3 ToMove = target.transform.position + offSet;
        transform.position = Vector3.MoveTowards(transform.position, ToMove, CameraSpeed*10*Time.deltaTime);
    }
}
