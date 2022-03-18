using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{
    public ScoreAndTime ScoreAndTime;
    public Rigidbody block;
    public Rigidbody redCube;
    public RedCube forSound;
    
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RedCube")
        {
            
            forSound.AudioBreak();
            ScoreAndTime.GetScore();
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
        block.AddForce(Vector3.up*200, ForceMode.Impulse);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
