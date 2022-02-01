using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingleJoint : MonoBehaviour
{
    public HingeJoint HingeJoint;
   

    // ��������� ������
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal")==-1 & Input.GetKey(KeyCode.Space)) //��������� ����� ������ ��� �������� ��������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition += 1f;
            if (jointSpring.targetPosition >= 45f)
            {
                jointSpring.targetPosition = 45f;
            }
            else
            {
                HingeJoint.spring = jointSpring;
            }

        }
        if (Input.GetAxis("Horizontal") == 1 & Input.GetKey(KeyCode.Space)) //��������� ����� ����� ��� �������� �������
        {
            JointSpring jointSpring = HingeJoint.spring;
            jointSpring.targetPosition -= 1f;
            if (jointSpring.targetPosition <= -45f)
            {
                jointSpring.targetPosition = -45f;
            }
            else
            {
                HingeJoint.spring = jointSpring;
            }
        }
        if (Input.GetAxis("Horizontal") == 0)  //���� ��� ������������� ��������
        {
            JointSpring jointSpring = HingeJoint.spring;
            if (jointSpring.targetPosition > 0)
            {
                jointSpring.targetPosition -= 2f;
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
                jointSpring.targetPosition += 2f;
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
}
