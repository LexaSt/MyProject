using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    private AudioSource audioSource;
    public Vector3 startPositionRedCube;

    private void Awake()
    {
        startPositionRedCube = transform.position;
        audioSource = GetComponent<AudioSource>();
    }
    public void AudioBreak()
    {
        audioSource.Play();
    }

}
