using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    private float moveSpeed = 120f;
    public float maxSpeed;
    public float accelerate;
    public float brakePower;

    public CanvasSystem CanvasSystem;

    public Rigidbody Player;
    public float speedRotate;

    private Vector3 moveForce;

    // public float TractionHandBrake;
    public float Traction;

    public TrailRenderer TrailRendererLeft;
    public TrailRenderer TrailRendererRight;
    public TextMesh Text;

    public UIbutton1 buttonHandBrak�Low;
    public UIbutton buttonBrake;
    public UIbutton buttonLeft;
    public UIbutton buttonRight;
    public UIbutton1 buttonHandBrake;

    public SoundDrift SoundDrift;

    public Slider Slider;
    public Slider SliderTurnLeft; // ���� ������� ������������ ��� ������ ���������� ������ � ������� �� ����� ��������  TurnAndHandBrakeOnSlider()
    public Slider SliderTurnRight;// ���� ������� ������������ ��� ������ ���������� ������ � ������� �� ����� ��������  TurnAndHandBrakeOnSlider()


    public void Move()
    {
        if (Input.GetKey(KeyCode.S) || buttonBrake.isDown) //���������� ��������
        {
            moveForce += -transform.forward * Time.deltaTime * brakePower;
            Player.transform.position += moveForce * moveSpeed * Time.deltaTime;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }

        else// �������������� ���������
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
            if (moveForce.magnitude < 1) //������� ���� �������� �� ��������� ��������
            {
                Player.transform.Rotate(-Vector3.up * Time.deltaTime * moveForce.magnitude * 60);
            }
            else //������� ���� �������� �� ������� ��������
            {
                Player.transform.Rotate(-Vector3.up * Time.deltaTime * moveForce.magnitude * speedRotate);
            }
        }


        else if (Input.GetKey(KeyCode.D) || buttonRight.isDown)
        {
            if (moveForce.magnitude < 1) //������� ���� �������� �� ��������� ��������
            {
                Player.transform.Rotate(Vector3.up * Time.deltaTime * moveForce.magnitude * 60);
            }
            else //������� ���� �������� �� ������� ��������
            {
                Player.transform.Rotate(Vector3.up * Time.deltaTime * moveForce.magnitude * speedRotate);
            }
        }
        

        if (Player.transform.position.y >= 1.3)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 1.2f, Player.transform.position.z);
        }

    }

    public void HandBrake()//������ ���������� #1 �������� ����� ������
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
        else if (Input.GetKey(KeyCode.LeftShift) || buttonHandBrak�Low.isDown)
        {
            if (moveForce.magnitude > 0.6f)
            {
                moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, 47 * Time.deltaTime) * moveForce.magnitude;
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
  
    public void HandBrakeSlider()//������� ���������� #2 �������� ����� �������
    {
            moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, Slider.value* Time.deltaTime) * moveForce.magnitude;
           
    }

    public void TurnAndHandBrakeOnSlider()//������ ���������� #3 �������� � ��������� ������������ ����� �������
    {

        if (SliderTurnRight.value> SliderTurnRight.minValue)
        {
            Player.transform.Rotate(Vector3.up * Time.deltaTime * moveForce.magnitude * speedRotate);
            moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, SliderTurnRight.value * Time.deltaTime) * moveForce.magnitude;
        }
        else if (SliderTurnLeft.value> SliderTurnLeft.minValue)
        {
            Player.transform.Rotate(-Vector3.up * Time.deltaTime * moveForce.magnitude * speedRotate);
            moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, SliderTurnLeft.value * Time.deltaTime) * moveForce.magnitude;
        }
        else
        { 
            moveForce = Vector3.Lerp(transform.forward, moveForce.normalized, 46 * Time.deltaTime) * moveForce.magnitude; 
        }
    }

    private void BackSliderToMin()
    {
        if (buttonLeft.isDown||buttonRight.isDown||buttonBrake.isDown)
        {
            SliderTurnRight.value = SliderTurnRight.minValue;
            SliderTurnLeft.value = SliderTurnLeft.minValue;
        }
        if (SliderTurnRight.value>SliderTurnRight.minValue && SliderTurnLeft.value > SliderTurnLeft.minValue)
        {
            SliderTurnLeft.value = SliderTurnLeft.minValue;
            SliderTurnRight.value = SliderTurnRight.minValue;
        }
       
    }// ��� ���������� ������ #3, ���������� �������� � ����������� ���������
   
    IEnumerator TimeToStart()
    {
        maxSpeed = 0;
        accelerate = 0;
        yield return new WaitForSeconds(3f);
        maxSpeed = 1.8f;
        accelerate = 0.5f;
    } // ��������, ����� ������ �� ����� ����� ������� �������

    public void PlaySoundDrift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.Space))
        {
            SoundDrift.DriftSound();
        }
    }

    private void Start()
    {
        CanvasSystem.ActiveCanvasStart();
        StartCoroutine(TimeToStart());
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        TurnAndHandBrakeOnSlider();
        BackSliderToMin();
        //HandBrake(); //���������� ��� ���������� �������� ����� ������, ����� ����� ����� ������������ � HingleJoint
        // HandBrakeSlider(); //���������� ��� ���������� �������� ����� �������, ����� ����� ����� ������������ � HingleJoint
    }

    private void Update()
    {
        PlaySoundDrift();
        //Text.text = (moveForce.magnitude * 60).ToString("f0");
        Debug.DrawRay(transform.position, moveForce.normalized * 50, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.black);
        //print(Slider.value);
    }

}



