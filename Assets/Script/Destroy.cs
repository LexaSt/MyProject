using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{

    public Rigidbody block;
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
        block.AddForce(222,222,222, ForceMode.Impulse);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
