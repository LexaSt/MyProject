using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlockCar : MonoBehaviour
{

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FailSound()
    {
        audioSource.Play();
    }
    public void DestroyCarBlock()
    {
        print("car destroy block");
    }
}
