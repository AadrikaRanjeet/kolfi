using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullattack : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public float walkSpeed;
    [SerializeField] private GameObject player;
  //  [SerializeField] private Transform target;
    public float minimumDistance; 
    float count=0;
    float distance;
   //[SerializeField] private Transform target;
   
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sprite=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        player=GameObject.FindWithTag("Player");
       // target=Archer.Instance.PlayerPosition;
       
    }
        
    void Update()
    {
      if(count==1)
      {
       Invoke("Damage",0.3f);
      }
    }
     void OnTriggerEnter2D(Collider2D other)
     {
        if(other.CompareTag("Player"))
        {
           anim.SetTrigger("detect");
          count=1;
          
        }
        
     }
     void OnTriggerExit2D(Collider2D other)
     {
      count=0;
     }
     
    void Damage()
    { 
      anim.SetTrigger("attack");
      
         if(Vector2.Distance(transform.position,player.transform.position)>minimumDistance)
         {
              distance=transform.position.x -player.transform.position.x;
            if(player.transform.position.x<transform.position.x)
            {
               Debug.Log(player.transform.position.x);
               sprite.flipX=false;
              transform.position=Vector2.MoveTowards(transform.position,player.transform.position,walkSpeed*Time.deltaTime);
              if(distance>1)
              {
                  rb.AddForce( transform.position* walkSpeed * Time.deltaTime);
              }
               
            }
            else
            {
                sprite.flipX=true;
                transform.position=Vector2.MoveTowards(transform.position,player.transform.position,walkSpeed*Time.deltaTime);
                 if(distance>1)
              {
                  rb.AddForce( transform.position* walkSpeed * Time.deltaTime);
              }
            }
           
         }
      }
    }

