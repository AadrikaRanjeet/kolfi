using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protectorenemy : MonoBehaviour
{
    public Animator anim;
    public float range=10f;
   
 
    void Start()
    {
        anim=GetComponent<Animator>();
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
             anim.SetTrigger("damage");
        }
       
    }
    void Update()
    {
       // enemy=GameObject.FindGameObjectsWithTag("enemy");
        Protect();
    }
     void Protect()
     {
         
         //find all the enemies within the spedcified range 
         Collider2D []hitEnemies=Physics2D.OverlapCircleAll(transform.position,range);
         
         foreach(Collider2D enemyCollider in hitEnemies)
         {
            if(enemyCollider.CompareTag("enemy"))
            {
               //acceessing the enemy gameobject attached to the collider
               GameObject enemyObj=enemyCollider.gameObject;
              
               //accessing the script 
               EnemyHealth health=enemyObj.GetComponent<EnemyHealth>();

               if(health!=null)
               {
                 health.TakeDamage(0);
               }
            }
         }
     }

     void OnDrawGizmosSelected()
     {
        
        Gizmos.DrawWireSphere(transform.position,range);
     }
}
