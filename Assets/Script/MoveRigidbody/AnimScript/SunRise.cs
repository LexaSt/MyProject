using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRise : MonoBehaviour
{
    private Animator animator;
    //private GameObject light;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Sun").GetComponent<Animator>();
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("sun");
    }
}
