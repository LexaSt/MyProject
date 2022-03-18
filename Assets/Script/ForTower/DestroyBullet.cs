using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "RedCube")
        {
            Destroy(gameObject);
        }

    }

    
}
