using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void AudioBreak()
    {
        audioSource.Play();
    }

}
