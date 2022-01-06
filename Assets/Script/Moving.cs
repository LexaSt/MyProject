using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float startSpeed;
    public float maxSpeed;
    public float accelerate;
    public Rigidbody Player;
    public float speedRotate;

    private Vector3 moveForce;

    public float Traction;

    private void Update()
    {
        
        moveForce += transform.forward * Time.deltaTime*Input.GetAxis("Vertical")*accelerate;
        Player.transform.position += moveForce * startSpeed * Time.deltaTime;
        //Vector3 rotate = new Vector3(0, Input.GetAxis("Horizontal") * speedRotate * Time.deltaTime, 0);
        //Quaternion quaternion = Quaternion.Euler(0, Input.GetAxis("Horizontal") * speedRotate * Time.deltaTime, 0);
        Player.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * moveForce.magnitude * speedRotate);
        
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        print(moveForce);

        if (Input.GetKey(KeyCode.Space))
        {
            moveForce = Vector3.zero;
        }

        Debug.DrawRay(transform.position, moveForce.normalized * 5);
        Debug.DrawRay(transform.position, transform.forward  * 5, Color.black);
        moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, Traction*Time.deltaTime)* moveForce.magnitude;
    }
}
