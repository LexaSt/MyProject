using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigMoveTurnWheelCol : MonoBehaviour
{
    [SerializeField] WheelCollider[] frontWheelCollider = new WheelCollider[2];
    [SerializeField] WheelCollider[] rearWheelCollider = new WheelCollider[2];
    [SerializeField] Transform[] dataFront = new Transform[2];
    [SerializeField] Transform[] dataRear = new Transform[2];

    [SerializeField] float speed;
    [SerializeField] float _rearSpeed;
    private float turnSpeed;
    [SerializeField] float _maxSpeedTurnAngle;
    [SerializeField] float _driftTurnAngle = 30f;
    [SerializeField] float _lowSpeedTurnAngle = 70f;
    [SerializeField] float _middleSpeedTurnAngle;
    private float forceDrift = 0.97f;
    [SerializeField] float brakeForce;
    [SerializeField] float valueStiffnessWhenBrake=8f;

    [SerializeField] float speedLimit;

    private Rigidbody player;
   

    //private Vector3 currentAngle;
    //private Vector3 needAngle;
    //private Vector3 delta;
    //private Quaternion rotation;
    //private bool check = true;
    //private bool check2 = true;
    //[SerializeField] int Delta;

    //private int timerButton = 0;



    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }


    //void Angle()
    //{
    //    if (check)
    //    {
    //        currentAngle = transform.position;
    //        //Debug.Log("currentAngle Check" + currentAngle);
    //    }

    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        check = false;
    //        delta = transform.position - currentAngle;
    //        //Debug.Log("currentAngle " + currentAngle);
    //        //Debug.Log("transform.position: " + transform.position);
    //        if (check2)
    //        {
    //            needAngle = transform.position;
    //            rotation = transform.rotation;
    //           // Debug.Log("Rotation " + rotation);
    //        }
    //        if (delta.magnitude > Delta)
    //        {
    //            Debug.Log("needAngle " + needAngle);
    //            Debug.Log("Разница " + Mathf.CeilToInt(delta.magnitude));
    //            //Debug.Log("!!!!!!!!!!!!!!!!!!");
    //            //.Log("needAngle from if " + needAngle);
    //            transform.rotation = rotation;
    //            check2 = false;
    //        }
    //    }
    //    else
    //    {
    //        check = true;
    //        check2 = true;
    //    }
    //}
    void TurnGraphicsUpdate()
    {
        dataFront[0].Rotate(-frontWheelCollider[0].rpm * Time.deltaTime, 0, 0);
        dataFront[1].Rotate(-frontWheelCollider[1].rpm * Time.deltaTime, 0, 0);
        dataRear[0].Rotate(-rearWheelCollider[0].rpm * Time.deltaTime, 0, 0);
        dataRear[1].Rotate(-rearWheelCollider[1].rpm * Time.deltaTime, 0, 0);

        dataFront[0].localEulerAngles = new Vector3(dataFront[0].localEulerAngles.x, Input.GetAxis("Horizontal") * 30, 0);
        dataFront[1].localEulerAngles = new Vector3(dataFront[1].localEulerAngles.x, Input.GetAxis("Horizontal") * 30, 0);
    }
    private void MoveTurn()
    {
        frontWheelCollider[0].steerAngle = turnSpeed * Input.GetAxis("Horizontal");
        frontWheelCollider[1].steerAngle = turnSpeed * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.S))
        {

            if (player.velocity.magnitude <= 1)
            { 
                rearWheelCollider[0].brakeTorque = 0;
                rearWheelCollider[1].brakeTorque = 0;
                frontWheelCollider[0].motorTorque = -_rearSpeed;
                frontWheelCollider[1].motorTorque = -_rearSpeed;
            }
            else
            {
                frontWheelCollider[0].motorTorque = 0;
                frontWheelCollider[1].motorTorque = 0;
                rearWheelCollider[0].brakeTorque = brakeForce;
                rearWheelCollider[1].brakeTorque = brakeForce;
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            //frontWheelCollider[0].motorTorque = 0;
            //frontWheelCollider[1].motorTorque = 0;
            rearWheelCollider[0].brakeTorque = brakeForce/4;
            rearWheelCollider[1].brakeTorque = brakeForce/4;
        }
        else
        {
            rearWheelCollider[0].brakeTorque = 0;
            rearWheelCollider[1].brakeTorque = 0;
            frontWheelCollider[0].motorTorque = speed;
            frontWheelCollider[1].motorTorque = speed;
        }


        if (Input.GetKey(KeyCode.Space) && (Input.GetAxis("Horizontal")>0|| Input.GetAxis("Horizontal") <0))
        {
            forceDrift = 0.97f;
            WheelFrictionCurve rearWheel = rearWheelCollider[0].sidewaysFriction;
            rearWheel.stiffness = forceDrift;
            rearWheelCollider[0].sidewaysFriction = rearWheel;
            rearWheelCollider[1].sidewaysFriction = rearWheel;

            WheelFrictionCurve rearWheelForwardFriction = rearWheelCollider[0].forwardFriction;
            rearWheelForwardFriction.stiffness = forceDrift;
            rearWheelCollider[0].forwardFriction = rearWheelForwardFriction;
            rearWheelCollider[1].forwardFriction = rearWheelForwardFriction;

            //WheelFrictionCurve frontWheelSideFriction = frontWheelCollider[0].sidewaysFriction;
            //frontWheelSideFriction.stiffness = 1.5f;
            //frontWheelCollider[0].sidewaysFriction = frontWheelSideFriction;
            //frontWheelCollider[1].sidewaysFriction = frontWheelSideFriction;

            //WheelFrictionCurve frontWheel = frontWheelCollider[0].forwardFriction;
            //frontWheel.stiffness = 6f;
            //frontWheelCollider[0].forwardFriction = frontWheel;
            //frontWheelCollider[1].forwardFriction = frontWheel;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            WheelFrictionCurve rearWheelForwardFriction = rearWheelCollider[0].forwardFriction;
            rearWheelForwardFriction.stiffness = valueStiffnessWhenBrake;
            rearWheelCollider[0].forwardFriction = rearWheelForwardFriction;
            rearWheelCollider[1].forwardFriction = rearWheelForwardFriction;

            WheelFrictionCurve frontWheelSideFriction = frontWheelCollider[0].sidewaysFriction;
            frontWheelSideFriction.stiffness = 1.5f;
            frontWheelCollider[0].sidewaysFriction = frontWheelSideFriction;
            frontWheelCollider[1].sidewaysFriction = frontWheelSideFriction;
        }
        else
        {
            WheelFrictionCurve rearWheel = rearWheelCollider[0].sidewaysFriction;
            //нкжно, чтобы плавно от Force drift(0.98) поднимаось до 2,5f (чем больше цифра тем больше держак)
            forceDrift = Mathf.Lerp(forceDrift, 2.5f, 1f * Time.deltaTime);
            rearWheel.stiffness = forceDrift;
            rearWheelCollider[0].sidewaysFriction = rearWheel;
            rearWheelCollider[1].sidewaysFriction = rearWheel;

            WheelFrictionCurve rearWheelForwardFriction = rearWheelCollider[0].forwardFriction;
            rearWheelForwardFriction.stiffness = forceDrift;
            rearWheelCollider[0].forwardFriction = rearWheelForwardFriction;
            rearWheelCollider[1].forwardFriction = rearWheelForwardFriction;

            WheelFrictionCurve frontWheel = frontWheelCollider[0].forwardFriction;
            frontWheel.stiffness = 4f;
            frontWheelCollider[0].forwardFriction = frontWheel;
            frontWheelCollider[1].forwardFriction = frontWheel;

            WheelFrictionCurve frontWheelSideFriction = frontWheelCollider[0].sidewaysFriction;
            frontWheelSideFriction.stiffness = 1;
            frontWheelCollider[0].sidewaysFriction = frontWheelSideFriction;
            frontWheelCollider[1].sidewaysFriction = frontWheelSideFriction;

        }

        if (player.velocity.magnitude <= speedLimit / 4) // скоростьо поворота на минимальной скорости
        {
            turnSpeed = _lowSpeedTurnAngle;
        }
        else if (Input.GetKey(KeyCode.Space))// скроость поворота в дрифте
        {
            turnSpeed = _driftTurnAngle;
        }
        else if (player.velocity.magnitude >= speedLimit / 4 && player.velocity.magnitude<= speedLimit / 1.5)
        {
            turnSpeed = _middleSpeedTurnAngle;
        }
        else// скорость поворота на макс скорости
        {
            turnSpeed = _maxSpeedTurnAngle;
        }
    }
    private void FixedUpdate()
    {
        MoveTurn();
        //Angle();
    }
    private void Update()
    {
        player.velocity = new Vector3(
        Mathf.Clamp(player.velocity.x, -speedLimit, speedLimit),
        Mathf.Clamp(player.velocity.y, -speedLimit, speedLimit),
        Mathf.Clamp(player.velocity.z, -speedLimit, speedLimit));

        TurnGraphicsUpdate();

        //Debug.Log(player.velocity.magnitude);
        //Debug.Log("turn" + turnSpeed);   
        ////Debug.Log("Заднее колесо" + rearWheelCollider[0].sidewaysFriction);

    }
}
