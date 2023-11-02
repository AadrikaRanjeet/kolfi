using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour
{
  //  public Rigidbody2D rb;
    public float speed;
  [SerializeField] private GameObject Player;
  private Transform playerTransform;
    public Transform fireballSpawnPoint;
    void Start()
    {
       Player=GameObject.FindWithTag("Player");
       playerTransform=Player.transform;
      //  rb=GetComponent<Rigidbody2D>();
    //     if(Archer.Instance.direction==1)
    //    {
    //          rb.velocity=-transform.right*speed;
    //    }
    //    else
    //    {
    //      rb.velocity=transform.right*speed;
    //      GetComponent<SpriteRenderer>().flipX=true;
    //    }
    }

    
    void Update()
    {
       
            transform.position=Vector2.MoveTowards(fireballSpawnPoint.transform.position,playerTransform.position,speed*Time.deltaTime);
            Destroy(this.gameObject);
        
         
    }
   
}
