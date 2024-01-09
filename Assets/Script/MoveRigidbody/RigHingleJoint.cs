using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigHingleJoint : MonoBehaviour
{
    //
    public HingeJoint HingeJoint;
    
    

    // Доработка физики
    private void MovingWithButton()
    {
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.Space))) //удержание груза справа при повороте наналево для кнопок
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
        else if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.Space))) //удержание груза слева при повороте направо для кнопок
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
        else if (Input.GetAxis("Horizontal") == 0)  //груз при прямолинейном движении
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
        MovingWithButton(); // управление ручником через кнопки, включаем если в MOVING активен метод HandBrake()
       
    }      
}
