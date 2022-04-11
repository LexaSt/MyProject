using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMAss : MonoBehaviour
{

    public Vector3 centerOfMass;
 //  public Vector3 worldCenterMass;

    private void Update()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
       
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
       // Gizmos.DrawSphere(GetComponent<Rigidbody>().centerOfMass, 100f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
    }

   
}
