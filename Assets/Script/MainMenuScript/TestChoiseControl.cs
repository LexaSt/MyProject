using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChoiseControl : MonoBehaviour
{
    /// ������������ ��� ����, ����� � ������ ���������� ������� ���� �� ���� ������� � ��� ����������� �� ��� ���� 
    public int A;   
    public void ButtonControl()
    {
        PlayerPrefs.SetInt("A", 1);
        PlayerPrefs.Save();
    }

    public void SliderControl()
    {
        PlayerPrefs.SetInt("A", 0);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        A = PlayerPrefs.GetInt("A");
       // print(A);      
    }
}
