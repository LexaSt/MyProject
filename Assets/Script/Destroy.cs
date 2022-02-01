using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    //public GameObject BLOCK;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out DestroyBlock DestroyBlock))
        {
            StartCoroutine(DestroyCorotune());  
        }

        if (collision.collider.TryGetComponent(out DestroyBlockCar destroyBlockCar))
        {
            StartCoroutine(DestroyCorotune());

        }
    }


    IEnumerator DestroyCorotune()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
