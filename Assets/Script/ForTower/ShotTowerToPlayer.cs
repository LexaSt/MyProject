using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTowerToPlayer : MonoBehaviour
{
    public GameObject bulletPref;
    public float shootSpeed;
    private Vector3 distance;
    private Transform player;
    private Transform tower;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("TargerForTower").transform;
        tower = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        distance = player.position - tower.position;
        Shot();
    }
   

    public void Shot()
    {
        if (distance.magnitude < 400 && distance.magnitude > 100)
        {
            
            for (int i = 400; i > 100; i -= 100)
            {
               
                if (Mathf.RoundToInt(distance.magnitude) == i)
                {
                    GameObject newBullet = Instantiate(bulletPref, transform.position, transform.rotation);
                    newBullet.GetComponent<Rigidbody>().velocity = transform.forward * shootSpeed;
                }
            }
        }
    }
}

