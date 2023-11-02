using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrowSpawnpoint : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject arrow;
    
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //shooting logic
       
        Instantiate(arrow,transform.position,transform.rotation);
        Invoke("Die",5f);
    }
    void Die()
    {
        Destroy(arrow);
    }
}
