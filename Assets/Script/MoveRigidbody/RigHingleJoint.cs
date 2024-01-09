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
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.Space))) //��������� ����� ������ ��� �������� �������� ��� ������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition += 1f;
            if (jointSpring.targetPosition >= 80f)
            {
                jointSpring.targetPosition = 80f;
            }
            else
            {
                HingeJoint.spring = jointSpring;
            }

        }
        else if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.Space))) //��������� ����� ����� ��� �������� ������� ��� ������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition -= 1f;
            if (jointSpring.targetPosition <= -80f)
            {
                jointSpring.targetPosition = -80f;
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
                jointSpring.targetPosition -= 20f;
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
                jointSpring.targetPosition += 20f;
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
       
    }      
}
