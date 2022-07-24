using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    private GameObject cameraLookAtObject;
    
    [Range(0,20)]public float smothTime = 5;
   

    private void Start() {
        cameraLookAtObject = GameObject.Find("lookAt").gameObject;

    }

    private void FixedUpdate() 
    {
        cameraBehavior();
    }


    private void cameraBehavior(){
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, cameraLookAtObject.transform.position,ref velocity,smothTime * Time.deltaTime);
        transform.LookAt(cameraLookAtObject.transform);
    }

}
