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
    private float turnSpeed;
    [SerializeField] float changeTurnSpeed;
    private float forceDrift = 0.97f;
    [SerializeField] float brakeForce;

    [SerializeField] float speedLimit;

    private Rigidbody player;

    private Vector3 currentAngle;
    private Vector3 needAngle;
    private Vector3 delta;
    private Quaternion rotation;
    private bool check = true;
    private bool check2 = true;

    private int timerButton = 0;
    


    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }


    void Angle()
    {
        if (check)
        {
            currentAngle = transform.position;
            //Debug.Log("currentAngle" + currentAngle);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            check = false;
            delta = transform.position - currentAngle;
            //Debug.Log("currentAngle " + currentAngle);
            //Debug.Log("transform.position: " + transform.position);
            if (check2)
            {
                needAngle = transform.position;
                rotation = transform.rotation;
            }
            if (delta.magnitude > 22)
            {
                // Debug.Log("needAngle " + needAngle);
                Debug.Log("Раница " + Mathf.CeilToInt(delta.magnitude));
                //Debug.Log("!!!!!!!!!!!!!!!!!!");
                //.Log("needAngle from if " + needAngle);
                transform.rotation = rotation;
                check2 = false;
            }
        }
        else
        {
            check = true;
            check2 = true;
        }
    }
    void TurnGraphicsUpdate()
    {
        dataFront[0].Rotate(-frontWheelCollider[0].rpm * Time.deltaTime,0,0);
        dataFront[1].Rotate(-frontWheelCollider[1].rpm * Time.deltaTime,0,0);
        dataRear[0].Rotate(-rearWheelCollider[0].rpm * Time.deltaTime,0,0);
        dataRear[1].Rotate(-rearWheelCollider[1].rpm * Time.deltaTime,0,0);
      
        dataFront[0].localEulerAngles = new Vector3(dataFront[0].localEulerAngles.x, Input.GetAxis("Horizontal")*30, 0);
        dataFront[1].localEulerAngles = new Vector3(dataFront[1].localEulerAngles.x, Input.GetAxis("Horizontal") *30, 0);
    }
    private void MoveTurn()
    {
        frontWheelCollider[0].steerAngle = turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        frontWheelCollider[1].steerAngle = turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
        {
            frontWheelCollider[0].motorTorque = 0f;
            frontWheelCollider[1].motorTorque = 0f;
            rearWheelCollider[0].motorTorque = 0f;
            rearWheelCollider[1].motorTorque = 0f;
            frontWheelCollider[0].brakeTorque = brakeForce * Time.deltaTime * 10000;
            frontWheelCollider[1].brakeTorque = brakeForce * Time.deltaTime * 10000;
            rearWheelCollider[0].brakeTorque = brakeForce * Time.deltaTime * 3000;
            rearWheelCollider[1].brakeTorque = brakeForce * Time.deltaTime * 3000;
            if (player.velocity.magnitude <=1f )
            {
                frontWheelCollider[0].brakeTorque = 0;
                frontWheelCollider[1].brakeTorque = 0;
                rearWheelCollider[0].brakeTorque = 0;
                rearWheelCollider[1].brakeTorque = 0;
                frontWheelCollider[0].motorTorque = -speed * Time.deltaTime * 10000;
                frontWheelCollider[1].motorTorque = -speed * Time.deltaTime * 10000;
                rearWheelCollider[0].motorTorque = -speed * Time.deltaTime * 10000;
                rearWheelCollider[1].motorTorque = -speed * Time.deltaTime * 10000;
            }
        }
        else
        {
            frontWheelCollider[0].brakeTorque = 0;
            frontWheelCollider[1].brakeTorque = 0;
            rearWheelCollider[0].brakeTorque = 0;
            rearWheelCollider[1].brakeTorque = 0;
            frontWheelCollider[0].motorTorque = speed * Time.deltaTime * 10000;
            frontWheelCollider[1].motorTorque = speed * Time.deltaTime * 10000;
        }

        if (Input.GetKey(KeyCode.Space))
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


           /* WheelFrictionCurve frontWheel = frontWheelCollider[0].forwardFriction;
            frontWheel.stiffness = 3f;
            frontWheelCollider[0].forwardFriction = frontWheel;
            frontWheelCollider[1].forwardFriction = frontWheel;*/

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

           /* WheelFrictionCurve frontWheel = frontWheelCollider[0].forwardFriction;
            frontWheel.stiffness = forceDrift;
            frontWheelCollider[0].forwardFriction = frontWheel;
            frontWheelCollider[1].forwardFriction = frontWheel;*/

        }

        if (player.velocity.magnitude <= 8 && player.velocity.magnitude >= -8) // скоростьо поворота на маленькой скорости
        {
            turnSpeed = 300f;
        }
        else if (Input.GetKey(KeyCode.Space))// скроость поворота в дрифте
        {
            turnSpeed = 350f;
        }
        else// скорость поворота на максимальной скорости
        {
            turnSpeed = changeTurnSpeed;
        }
    }
    private void FixedUpdate()
    {
        MoveTurn();    
    }
    private void Update()
    {
        player.velocity = new Vector3(
        Mathf.Clamp(player.velocity.x, -speedLimit, speedLimit),
        Mathf.Clamp(player.velocity.y, -speedLimit, speedLimit),
        Mathf.Clamp(player.velocity.z, -speedLimit, speedLimit));
        TurnGraphicsUpdate();
        //Angle();
        //Debug.Log("Заднее колесо" + rearWheelCollider[0].sidewaysFriction);

    }
}
