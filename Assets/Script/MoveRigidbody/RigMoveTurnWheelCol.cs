using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigMoveTurnWheelCol : MonoBehaviour
{
    [SerializeField] WheelCollider[] frontWheelCollider = new WheelCollider[2];
    [SerializeField] WheelCollider[] rearWheelCollider = new WheelCollider[2];

    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float forceDrift;
    [SerializeField] float brakeForce;

    [SerializeField] float speedLimit; 

    private Rigidbody player;

    private Vector3 currentAngle;
    private Vector3 needAngle;
    private Vector3 delta;
    private Quaternion rotation;
    private bool check=true;
    private bool check2 = true;


    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }


    void Angle()
    {
        if (check)
        {
            currentAngle = transform.position;
            check = false;
            //Debug.Log("currentAngle" + currentAngle);
        }

        if (Input.GetKey(KeyCode.Space))
        {

            // Debug.Log("currentAngle " + currentAngle);
            //Debug.Log("transform.position: " + transform.position);
            if (check2)
            {
                delta = transform.position - currentAngle;
                needAngle = transform.position;
                rotation = transform.rotation;
                check2 = false;
                Debug.Log("needAngle " + needAngle);
                // Debug.Log("Раница " + delta.magnitude)            
            }
           
            if (delta.magnitude >= 3)
            {
                Debug.Log("!!!!!!!!!!!!!!!!!!");
                Debug.Log("needAngle from if " + needAngle);
                transform.rotation = rotation;
                check2 = false;
            }
            else
            {
                check2 = true;
                rotation = transform.rotation;
            }

        }
        else
        {
            check = true;
            transform.rotation = transform.rotation;
          
        }



    }
    private void FixedUpdate()
    {
        
        frontWheelCollider[0].steerAngle = turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        frontWheelCollider[1].steerAngle = turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
        {
            frontWheelCollider[0].brakeTorque = brakeForce * Time.deltaTime * 10000;
            frontWheelCollider[1].brakeTorque = brakeForce * Time.deltaTime * 10000;
            rearWheelCollider[0].brakeTorque = brakeForce * Time.deltaTime * 3000;
            rearWheelCollider[1].brakeTorque = brakeForce * Time.deltaTime * 3000;
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
            WheelFrictionCurve wfc0 = rearWheelCollider[0].sidewaysFriction;
            wfc0.stiffness = forceDrift;
            rearWheelCollider[0].sidewaysFriction = wfc0;
            rearWheelCollider[1].sidewaysFriction = wfc0;

            WheelFrictionCurve frontWheel = frontWheelCollider[0].forwardFriction;
            frontWheel.stiffness = 3f;
            frontWheelCollider[0].forwardFriction = frontWheel;
            frontWheelCollider[1].forwardFriction = frontWheel; 

        }
        else 
        {
            WheelFrictionCurve wfc0 = rearWheelCollider[0].sidewaysFriction;
            wfc0.stiffness = 3f;
            rearWheelCollider[0].sidewaysFriction = wfc0;
            rearWheelCollider[1].sidewaysFriction = wfc0;

            WheelFrictionCurve frontWheel = frontWheelCollider[0].forwardFriction;
            frontWheel.stiffness = 1f;
            frontWheelCollider[0].forwardFriction = frontWheel;
            frontWheelCollider[1].forwardFriction = frontWheel;
        }
      }
    private void Update()
    {
        player.velocity = new Vector3(
        Mathf.Clamp(player.velocity.x, -speedLimit, speedLimit),
        Mathf.Clamp(player.velocity.y, -speedLimit, speedLimit),
        Mathf.Clamp(player.velocity.z, -speedLimit, speedLimit));
        Angle();
    }



}
