using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 camOffSet = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;
   

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        this.transform.position = target.TransformPoint(camOffSet);
        this.transform.LookAt(target);
     
        
    }

}
