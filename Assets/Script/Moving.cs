using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float moveSpeed=120f;
    public float maxSpeed;
    public float accelerate=0.5f;

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
        Player.transform.position += moveForce * moveSpeed * Time.deltaTime;

        
        if (moveForce.magnitude < 1.3) //больший угол поворота на небольшой скорости
        {
            Player.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * moveForce.magnitude * 60);
        }
        else //меньший угол поворота на большой скорости
        {
            Player.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * moveForce.magnitude * speedRotate);
        }

       // if (Input.GetAxis("Vertical") == -1)
        //{
           // moveForce = (moveForce - new Vector3(0.1f,0,0))*Time.deltaTime;
        //}

        if (Player.transform.position.y >= 1.3)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 1.2f, Player.transform.position.z);
        }

        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
       // print("SPEED " + moveForce.magnitude*60);
    
    }

    private void Update()
    {
      
        //drift
        if (Input.GetKey(KeyCode.Space))
        {
            if (moveForce.magnitude > 0.6f)
            {
                moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, TractionHandBrake * Time.deltaTime) * moveForce.magnitude;
                TrailRendererLeft.emitting = true;
                TrailRendererRight.emitting = true;
            }
            else 
            {
                moveForce = new Vector3(0, 0, 0);
            }
        }
        else
        {
            moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, Traction * Time.deltaTime) * moveForce.magnitude;
            TrailRendererLeft.emitting = false;
            TrailRendererRight.emitting = false;
        }
        Debug.DrawRay(transform.position, moveForce.normalized * 50, Color.white);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.black);

    }

   
}
