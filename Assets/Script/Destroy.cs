using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{
    public GameMenu GameMenu;
    public Rigidbody block;
    public Rigidbody redCube;
    public RedCube forSound;
    public Moving moving;
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out redCube))
        {
            forSound.AudioBreak();
            GameMenu.GetScore();
            StartCoroutine(DestroyCorotune());  
        }

        if (collision.collider.TryGetComponent(out DestroyBlockCar DestroyBlockCar))
        {
            DestroyBlockCar.FailSound();
            StartCoroutine(DestroyCorotune());
        }
    }


    IEnumerator DestroyCorotune()
    {
        
        block.AddForce(222,222,222, ForceMode.Impulse);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
