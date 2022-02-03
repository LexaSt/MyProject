using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    private float moveSpeed = 120f;
    public float maxSpeed;
    public float accelerate = 0.5f;
    public float brakePower;
 


    public Rigidbody Player;
    public float speedRotate;

    private Vector3 moveForce;

   // public float TractionHandBrake;
    public float Traction;

    public TrailRenderer TrailRendererLeft;
    public TrailRenderer TrailRendererRight;
    public TextMesh Text;

    public UIbutton buttonHandBrakуLow;
    public UIbutton buttonBrake;
    public UIbutton buttonLeft;
    public UIbutton buttonRight;
    public UIbutton buttonHandBrake;

    public void Move()
    { 
        if (Input.GetKey(KeyCode.S) || buttonBrake.isDown)
        {
            moveForce += -transform.forward * Time.deltaTime * brakePower;
            Player.transform.position += moveForce * moveSpeed * Time.deltaTime;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }

        else 
        {
            moveForce += transform.forward * Time.deltaTime * accelerate;
            Player.transform.position += moveForce * moveSpeed * Time.deltaTime;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }
    }

    public void Turn() 
    {
        if (Input.GetKey(KeyCode.A) || buttonLeft.isDown)
        {
            if (moveForce.magnitude < 1) //больший угол поворота на небольшой скорости
            {
                Player.transform.Rotate(-Vector3.up * Time.deltaTime * moveForce.magnitude * 60);
            }
            else //меньший угол поворота на большой скорости
            {
                Player.transform.Rotate(-Vector3.up * Time.deltaTime * moveForce.magnitude * speedRotate);
            }
        }


        else if (Input.GetKey(KeyCode.D) || buttonRight.isDown)
        {
            if (moveForce.magnitude < 1) //больший угол поворота на небольшой скорости
            {
                Player.transform.Rotate(Vector3.up * Time.deltaTime * moveForce.magnitude * 60);
            }
            else //меньший угол поворота на большой скорости
            {
                Player.transform.Rotate(Vector3.up *  Time.deltaTime * moveForce.magnitude * speedRotate);
            }
        }

        if (Player.transform.position.y >= 1.3)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 1.2f, Player.transform.position.z);
        }

    }

    public void HandBrake()
    {
        //drift
        if (Input.GetKey(KeyCode.Space) || buttonHandBrake.isDown)
        {
            if (moveForce.magnitude > 0.6f)
            {
                moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, 200 * Time.deltaTime) * moveForce.magnitude;
                TrailRendererLeft.emitting = true;
                TrailRendererRight.emitting = true;
            }
            else
            {
                moveForce = new Vector3(0, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) || buttonHandBrakуLow.isDown)
            {
            if (moveForce.magnitude > 0.6f)
            {
                moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, 48 * Time.deltaTime) * moveForce.magnitude;
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
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        HandBrake();
        
    }

    private void Update()
    {

        Text.text = (moveForce.magnitude * 60).ToString("f0");
        Debug.DrawRay(transform.position, moveForce.normalized * 50, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.black);

    }

   


}
