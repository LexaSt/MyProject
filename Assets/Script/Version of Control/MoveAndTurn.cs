using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAndTurn : MonoBehaviour
{
    private float moveSpeed = 120f;
    public float maxSpeed;
    private float accelerate = 0.5f;
    private float brakePower = 0.5f;

    public CanvasSystem CanvasSystem;

    public Rigidbody Player;
    public float speedRotate;

    public Vector3 moveForce;

    public float Traction;
    public UIbutton buttonBrake;
    public UIbutton buttonLeft;
    public UIbutton buttonRight;
    //public UIbutton choiceButtonControl;
   // public UIbutton choiceSliderControl;
    public Text SpeedRotateInfo;
    public Text MaxSpeedInfo;
    public Vector3 startPosition;

    private Rigidbody Rigidbody;

    

    public void Move()
    {
        if (Input.GetKey(KeyCode.S) || buttonBrake.isDown) //торможение кнопокой
        {
            moveForce += -transform.forward * Time.fixedDeltaTime * brakePower;
           // Player.transform.position += moveForce * moveSpeed * Time.fixedDeltaTime;
            Rigidbody.MovePosition(Player.transform.position + moveForce * moveSpeed * Time.fixedDeltaTime);
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
            
        }
        else if (Input.GetKey(KeyCode.LeftAlt))
        {
            moveForce = new Vector3(0, 0, 0);
        }

        else// автоматическое ускорение
        {
            moveForce += transform.forward * Time.fixedDeltaTime * accelerate;
           // Player.transform.position += moveForce * moveSpeed * Time.fixedDeltaTime;
            Rigidbody.MovePosition(Player.transform.position + moveForce * moveSpeed * Time.fixedDeltaTime);
            //Rigidbody.AddForce(Input.GetAxis("Vertical")* moveForce * moveSpeed * Time.fixedDeltaTime);
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }
    }

    public void Turn()
    {
        if (Input.GetKey(KeyCode.A) || buttonLeft.isDown)
        {
            if (moveForce.magnitude < 1f) //больший угол поворота на небольшой скорости
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
            if (moveForce.magnitude < 1f) //больший угол поворота на небольшой скорости
            {
                Player.transform.Rotate(Vector3.up * Time.deltaTime * moveForce.magnitude * 60);
            }
            else //меньший угол поворота на большой скорости
            {
                Player.transform.Rotate(Vector3.up * Time.deltaTime * moveForce.magnitude * speedRotate);
            }
        }


        if (Player.transform.position.y >= 1.3)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 1.2f, Player.transform.position.z);
        }

    }
    IEnumerator TimeToStart()
    {
            
            yield return new WaitForSeconds(3f);
            maxSpeed = 1f;
            accelerate = 0.5f;
       
    } // задержка, чтобы машина не ехала перед отчетом времени

    private void Start()
    {
        maxSpeed = 0;
        accelerate = 0;
            CanvasSystem.ActiveCanvasStart();
            StartCoroutine(TimeToStart());
        startPosition = transform.position;

        Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    { 
        Move();
        Turn();   
    }

    private void Update()
    {
        SpeedRotateInfo.text = "SpeedRotateInfo: " + speedRotate.ToString();
        MaxSpeedInfo.text = "MaxSpeedInfo: " + maxSpeed.ToString();
        Debug.DrawRay(transform.position, moveForce.normalized * 50, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.black);
        maxSpeed = PlayerPrefs.GetFloat("maxSpeed");
        speedRotate = PlayerPrefs.GetFloat("turn");
    }
}
