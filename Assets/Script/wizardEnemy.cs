using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardEnemy : MonoBehaviour
{

      public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public float walkSpeed;
    [SerializeField] private GameObject player;
    public float minimumDistance; 
   
    float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sprite=GetComponentInParent<SpriteRenderer>();
        anim=GetComponentInParent<Animator>();
       player=GameObject.FindWithTag("Player");
    }
     void OnTriggerEnter2D(Collider2D other)
     {
        if(other.CompareTag("Player"))
        {
          
      anim.SetBool("attack",true);
        //  if(Vector2.Distance(transform.position,player.transform.position)>minimumDistance)
        //  {
        //       distance=transform.position.x -player.transform.position.x;
        //     if(player.transform.position.x<transform.position.x)
        //     {
        //        Debug.Log(transform.position.x);
             
             
        //       if(distance>1)
        //       {
        //           rb.AddForce( transform.position* walkSpeed * Time.deltaTime);
        //       }
               
        //     }
        //     else
        //     {
               
             
        //          if(distance>1)
        //       {
        //           rb.AddForce( transform.position* walkSpeed * Time.deltaTime);
        //       }
        //     }
           
         }
         
          
        }
        
     void OnTriggerExit2D(Collider2D other)
     {
      
      anim.SetBool("attack",false);
     }
        
     
     
}
   


