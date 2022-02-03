using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{
    public GameMenu GameMenu;
    public Rigidbody block;
    public Rigidbody redCube;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out redCube))
        {
            GameMenu.GetScore();
            StartCoroutine(DestroyCorotune());  
        }

        if (collision.collider.TryGetComponent(out DestroyBlockCar DestroyBlockCar))
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
