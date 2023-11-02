using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Warrior : MonoBehaviour
{
    
 [SerializeField] private float walkSpeed;
 [SerializeField] private float jumpHeight;
 [SerializeField] private Rigidbody2D rb;
 [SerializeField] private SpriteRenderer sprite;
 [SerializeField] private CapsuleCollider2D collide;
 [SerializeField] private LayerMask JumpableGround;
 [SerializeField] private Animator anim;
  public int direction;
 public  static Warrior Instance;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sprite=GetComponent<SpriteRenderer>();
        collide=GetComponent<CapsuleCollider2D>();
        anim=GetComponent<Animator>();
        Instance=this;
        GameObject.Find("2D camera").GetComponent<CinemachineVirtualCamera>().Follow = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
     Move();  
      if(sprite.flipX )
     {
        direction=-1;
     }
     else
     {
        direction=1;
     }
    }

    
    void Move()
    {
          float xdir=Input.GetAxis("Horizontal");
        float ydir=Input.GetAxis("Vertical");
        Vector3 movement =new Vector3(xdir,ydir,0);
        if(Input.GetAxis("Horizontal")>0)
        {
             sprite.flipX = false;
             anim.SetBool("walk",true);
            transform.Translate(movement*walkSpeed*Time.deltaTime);
            
        }
         if(Input.GetAxis("Horizontal")<0)
        {
            sprite.flipX = true;
             anim.SetBool("walk",true);
            transform.Translate(movement*walkSpeed*Time.deltaTime);
        }
         if(Input.GetAxis("Horizontal")==0)
        {
             anim.SetBool("walk",false);
            transform.Translate(movement*walkSpeed*Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
       {
        
        rb.AddForce(Vector2.up * jumpHeight,ForceMode2D.Impulse);
        anim.SetTrigger("jump");
       }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collide.bounds.center,collide.bounds.size,0f,Vector2.down ,.1f,JumpableGround);
    }
}
