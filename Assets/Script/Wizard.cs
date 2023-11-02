using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
public class Wizard : MonoBehaviour
{
   public static Wizard Instance; 
 [SerializeField] private float walkSpeed;
 [SerializeField] private float jumpHeight;
 [SerializeField] private Rigidbody2D rb;
 [SerializeField] private SpriteRenderer sprite;
 [SerializeField] private CapsuleCollider2D collide;
 [SerializeField] private LayerMask JumpableGround;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sprite=GetComponent<SpriteRenderer>();
        collide=GetComponent<CapsuleCollider2D>();
        Instance=this;
     GameObject.Find("2D camera").GetComponent<CinemachineVirtualCamera>().Follow = this.transform;
    
    }

    // Update is called once per frame
    void Update()
    {
     Move();   
    }
    void Move()
    {
          float xdir=Input.GetAxis("Horizontal");
        float ydir=Input.GetAxis("Vertical");
        Vector3 movement =new Vector3(xdir,ydir,0);
        if(Input.GetAxis("Horizontal")>0)
        {
             sprite.flipX = false;
             
            transform.Translate(movement*walkSpeed*Time.deltaTime);
            
        }
         if(Input.GetAxis("Horizontal")<0)
        {
            sprite.flipX = true;
            transform.Translate(movement*walkSpeed*Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
       {
        
        rb.AddForce(Vector2.up * jumpHeight,ForceMode2D.Impulse);
       
       }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collide.bounds.center,collide.bounds.size,0f,Vector2.down ,.1f,JumpableGround);
    }
}
