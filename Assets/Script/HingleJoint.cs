using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingleJoint : MonoBehaviour
{
    public HingeJoint HingeJoint;
    public UIbutton buttonLeft;
    public UIbutton buttonRight;
    public UIbutton1 buttonHandBrake;
    public UIbutton1 buttonHandBrak�Low;


    // ��������� ������
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A)|| buttonLeft.isDown) & (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift) || buttonHandBrake.isDown || buttonHandBrak�Low.isDown)) //��������� ����� ������ ��� �������� ��������
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
        else if ((Input.GetKey(KeyCode.D) || buttonRight.isDown) & (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift) || buttonHandBrake.isDown || buttonHandBrak�Low.isDown)) //��������� ����� ����� ��� �������� �������
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
