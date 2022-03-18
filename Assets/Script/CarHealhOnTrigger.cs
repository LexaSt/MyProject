using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealhOnTrigger : MonoBehaviour
{
    public int carHealth = 10;
    public TextMesh TextMesh;
    public GameMenu GameMenu;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
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
