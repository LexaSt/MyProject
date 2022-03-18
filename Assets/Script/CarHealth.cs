using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public int carHealth=5;
    public TextMesh TextMesh;
    public GameMenu GameMenu;


    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Bullet")
       {
           carHealth -= 1;
       }
   }

   
    private void Update()
    {
        print(carHealth);
        TextMesh.text = (carHealth).ToString();
        if (carHealth < 1)
        {
            GameMenu.OnPlayerRaechFinish();
        }
    }
}
