using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftButton : MonoBehaviour
{
    public MoveAndTurn MoveAndTurn;
    public TrailRenderer TrailRendererLeft;
    public TrailRenderer TrailRendererRight;
    public HingeJoint HingeJoint;
    //public UIbutton buttonLeft;
   // public UIbutton buttonRight;
    public UIbutton1 buttonHandBrak�Low;
    public UIbutton1 buttonHandBrake;
    

    public void HandBrake()//������ ���������� #1 �������� ����� ������
    {
        //drift
        if (Input.GetKey(KeyCode.Space) || buttonHandBrake.isDown)
        {

            if (MoveAndTurn.moveForce.magnitude > 0.6f)
            {
                MoveAndTurn.moveForce = Vector3.Lerp(transform.forward, MoveAndTurn.moveForce.normalized, 200*Time.deltaTime) * MoveAndTurn.moveForce.magnitude;
               
                TrailRendererLeft.emitting = true;
                TrailRendererRight.emitting = true;
            }
            else
            {
                MoveAndTurn.moveForce = new Vector3(0, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) || buttonHandBrak�Low.isDown)
        {
            if (MoveAndTurn.moveForce.magnitude > 0.6f)
            {
                
                MoveAndTurn.moveForce = Vector3.Lerp(transform.forward, MoveAndTurn.moveForce.normalized, 49 * Time.deltaTime) * MoveAndTurn.moveForce.magnitude;
                TrailRendererLeft.emitting = true;
                TrailRendererRight.emitting = true;
            }
            else
            {
                MoveAndTurn.moveForce = new Vector3(0, 0, 0);
            }
        }
        else
        {
            MoveAndTurn.moveForce = Vector3.Lerp(transform.forward, MoveAndTurn.moveForce.normalized, MoveAndTurn.Traction * Time.deltaTime) * MoveAndTurn.moveForce.magnitude;
            TrailRendererLeft.emitting = false;
            TrailRendererRight.emitting = false;
        }
    }

    private void MovingWithButton()
    {
        if ((Input.GetKey(KeyCode.A) || MoveAndTurn.buttonLeft.isDown) & (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift) || buttonHandBrake.isDown || buttonHandBrak�Low.isDown)) //��������� ����� ������ ��� �������� �������� ��� ������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition += 10f;
            if (jointSpring.targetPosition >= 45f)
            {
                jointSpring.targetPosition = 45f;
                HingeJoint.spring = jointSpring;
            }
            else
            {
                HingeJoint.spring = jointSpring;
            }

        }
        else if ((Input.GetKey(KeyCode.D) || MoveAndTurn.buttonRight.isDown) & (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift) || buttonHandBrake.isDown || buttonHandBrak�Low.isDown)) //��������� ����� ����� ��� �������� ������� ��� ������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition -= 10f;
            if (jointSpring.targetPosition <= -45f)
            {
                jointSpring.targetPosition = -45f;
                HingeJoint.spring = jointSpring;
            }
            else
            {
                HingeJoint.spring = jointSpring;
            }
        }
        else if (Input.GetAxis("Horizontal") == 0)  //���� ��� ������������� ��������
        {
            JointSpring jointSpring = HingeJoint.spring;
            if (jointSpring.targetPosition > 0)
            {
                jointSpring.targetPosition -= 0.5f;
                if (jointSpring.targetPosition == 0)
                {
                    jointSpring.targetPosition = 0;
                }
                else
                {
                    HingeJoint.spring = jointSpring;
                }
            }
            if (jointSpring.targetPosition < 0)
            {
                jointSpring.targetPosition += 0.5f;
                if (jointSpring.targetPosition == 0)
                {
                    jointSpring.targetPosition = 0;
                }
                else
                {
                    HingeJoint.spring = jointSpring;
                }
            }
        }
    } //������ �������� �����

    private void FixedUpdate()
    {
        HandBrake(); 
        MovingWithButton();
    }
}

