using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBlock : MonoBehaviour
{
    public float score = 0;
    public Text text;


    private void OnTriggerEnter(Collider other)
    {
        
            score ++;
        
    }

    private void Update()
    {
        text.text = score.ToString();
    }
}
