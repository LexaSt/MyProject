using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving1 : MonoBehaviour
{
    public float startSpeed;
    public float maxSpeed;
    public float accelerate;

    public Rigidbody Player;
    public float speedRotate;

    private Vector3 moveForce;

    public float TractionHandBrake;
    public float Traction;

    public TrailRenderer TrailRendererLeft;
    public TrailRenderer TrailRendererRight;



    private void FixedUpdate()
    {
        moveForce += transform.forward * Time.deltaTime * Input.GetAxis("Vertical") * accelerate;
        Player.transform.position += moveForce * startSpeed * Time.deltaTime;
        //Vector3 rotate = new Vector3(0, Input.GetAxis("Horizontal") * speedRotate * Time.deltaTime, 0);
        //Quaternion quaternion = Quaternion.Euler(0, Input.GetAxis("Horizontal") * speedRotate * Time.deltaTime, 0);
        Player.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * moveForce.magnitude * speedRotate);

        if (Input.GetAxis("Vertical") == 0)
        {
            moveForce -= (moveForce - new Vector3(0.01f,0,0))*Time.deltaTime;
        }

        if (Player.transform.position.y >= 1.3)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 1.3f, Player.transform.position.z);
        }

        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        print("SPEED " + moveForce);
    
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveForce = Vector3.zero;
        }

        //drift
        if (Input.GetKey(KeyCode.Space))
        {
            if (moveForce != Vector3.zero)
            {
                moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, TractionHandBrake * Time.deltaTime) * moveForce.magnitude;
                TrailRendererLeft.emitting = true;
                TrailRendererRight.emitting = true;
            }
            
        }
        else
        {
            moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, Traction * Time.deltaTime) * moveForce.magnitude;
            TrailRendererLeft.emitting = false;
            TrailRendererRight.emitting = false;
        }


        Debug.DrawRay(transform.position, moveForce.normalized * 5);
        Debug.DrawRay(transform.position, transform.forward  * 5, Color.black);     
    }
}
