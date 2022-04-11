using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigMoveTurn : MonoBehaviour
{
    private Rigidbody rigidbodyPlayer;
    private Transform transformPlayer;
    [SerializeField] private float rotation;
    [SerializeField] private float accelerate;
    [SerializeField] private float velocityLimit;
    

    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        transformPlayer = GetComponent<Transform>();
    }
    private void Drift()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            rigidbodyPlayer.angularDrag = 1;
        }
        else 
        {
            rigidbodyPlayer.angularDrag = 5;
        }
    }
    private void Moving()
    {
       if (Input.GetKey(KeyCode.W))
        {
            rigidbodyPlayer.AddForce(transform.forward * accelerate * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbodyPlayer.AddForce(-transform.forward * accelerate * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        /*else 
        {
            rigidbodyPlayer.AddForce(transform.forward * accelerate * Time.fixedDeltaTime, ForceMode.Acceleration);
        }*/
    }

    private void Turning()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbodyPlayer.AddTorque(Vector3.down * rotation * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbodyPlayer.AddTorque(Vector3.up * rotation * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    
    void FixedUpdate()
    {
        Moving();
        Turning();
        Drift();

        rigidbodyPlayer.velocity = new Vector3
       (Mathf.Clamp(rigidbodyPlayer.velocity.x, -velocityLimit, velocityLimit),
        Mathf.Clamp(rigidbodyPlayer.velocity.y, -velocityLimit, velocityLimit),
        Mathf.Clamp(rigidbodyPlayer.velocity.z, -velocityLimit, velocityLimit));

     

    }

    private void Update()
    {

        //НЕ выходит ограничть угол поворота надо разобраться
       /*
        var rot = transformPlayer.rotation;
        if (transformPlayer.rotation.y >= 0.5f)
        {
            rot.y=50f * Time.deltaTime;
            transformPlayer.rotation = rot;
        }
        if (transformPlayer.rotation.y <= -0.5f)
        {
            transformPlayer.eulerAngles = new Vector3(0f, -60f, 0f) * Time.deltaTime;
        }
       */
       // print(transformPlayer.rotation.y);
    }
}
