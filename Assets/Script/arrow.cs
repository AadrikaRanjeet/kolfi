using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrow : MonoBehaviour
{
    //in this script we will make arrow fly in the direction player is facing 
    public float speed;
    public Rigidbody2D rb;
    public int damage;
    void Start()
    {
       
       if(Archer.Instance.direction==1)
       {
             rb.velocity=transform.right*speed;
       }
       else
       {
         rb.velocity=-transform.right*speed;
         GetComponent<SpriteRenderer>().flipX=true;
       }
       
      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if(other.CompareTag("enemy"))
        {
            //we are  not sure that we always gonna hit the enemy so next 2 lines are for that
        EnemyHealth health=other.GetComponent<EnemyHealth>();
        if(health!=null)
        {
        health.TakeDamage(damage);
        }
        Destroy(gameObject);
        }
        
      }
    }
    

