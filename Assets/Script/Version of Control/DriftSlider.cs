using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftSlider : MonoBehaviour
{
    public MoveAndTurn MoveAndTurn;
    public Slider Slider;
    public HingeJoint HingeJoint;
    public TrailRenderer TrailRendererLeft;
    public TrailRenderer TrailRendererRight;
    public void HandBrakeSlider()//������� ���������� #2 �������� ����� �������
    {
        MoveAndTurn.moveForce = Vector3.Lerp(transform.forward, MoveAndTurn.moveForce.normalized, Slider.value * Time.deltaTime) * MoveAndTurn.moveForce.magnitude;
        if (MoveAndTurn.buttonBrake.isDown)
        {
            Slider.value = Slider.minValue;
        }
        if (Slider.value > 48)
        {
            TrailRendererLeft.emitting = true;
            TrailRendererRight.emitting = true;
        }
        if (Slider.value <= 48)
        {
            TrailRendererLeft.emitting = false;
            TrailRendererRight.emitting = false;
        }

    }
    private void MovingWithSlider()
    {
        if (((Input.GetKey(KeyCode.A) || MoveAndTurn.buttonLeft.isDown) && Slider.value > 48)) //��������� ����� ������ ��� �������� �������� ��� ��������
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
        else if (((Input.GetKey(KeyCode.D) || MoveAndTurn.buttonRight.isDown) && Slider.value > 48)) //��������� ����� ����� ��� �������� ������� ��� ��������
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
    }//������ �������� �����

    private void FixedUpdate()
    {
        HandBrakeSlider(); 
        MovingWithSlider();
    }
}
