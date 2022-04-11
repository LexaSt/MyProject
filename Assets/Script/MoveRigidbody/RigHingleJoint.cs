using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigHingleJoint : MonoBehaviour
{
    //
    public HingeJoint HingeJoint;
    
    

    // ��������� ������
    private void MovingWithButton()
    {
        if (Input.GetKey(KeyCode.A) & (Input.GetKey(KeyCode.Space))) //��������� ����� ������ ��� �������� �������� ��� ������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition += 10f;
            if (jointSpring.targetPosition >= 45f)
            {
                jointSpring.targetPosition = 45f;
            }
            else
            {
                HingeJoint.spring = jointSpring;
            }

        }
        else if (Input.GetKey(KeyCode.D) & (Input.GetKey(KeyCode.Space))) //��������� ����� ����� ��� �������� ������� ��� ������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition -= 10f;
            if (jointSpring.targetPosition <= -45f)
            {
                jointSpring.targetPosition = -45f;
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
    } 


    void FixedUpdate()
    {
        MovingWithButton(); // ���������� �������� ����� ������, �������� ���� � MOVING ������� ����� HandBrake()
        //MovingWithSlider(); // ���������� �������� ����� �������, �������� ���� � MOVING ������� ����� HandBrakeSlider()
    }      
}
