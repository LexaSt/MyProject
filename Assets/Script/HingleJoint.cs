using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingleJoint : MonoBehaviour
{
    public HingeJoint HingeJoint;
   

    // Доработка физики
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal")==-1 & Input.GetKey(KeyCode.Space)) //удержание груза справа при повороте наналево
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
        if (Input.GetAxis("Horizontal") == 1 & Input.GetKey(KeyCode.Space)) //удержание груза слева при повороте направо
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
        if (Input.GetAxis("Horizontal") == 0)  //груз при прямолинейном движении
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
