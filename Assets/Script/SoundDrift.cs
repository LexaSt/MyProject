using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundDrift : MonoBehaviour
{
    private AudioSource soundDrift;

    private void Start()
    {
        soundDrift = GetComponent<AudioSource>();

    }

    public void DriftSound()
    {

        soundDrift.Play();
    
    }
}


