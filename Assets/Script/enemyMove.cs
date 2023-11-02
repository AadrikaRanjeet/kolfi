using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D collide;
    public SpriteRenderer sprite;
    public Animator anim;
    public float walkSpeed ,jumpHeight;
    public LayerMask JumpableGround;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        collide=GetComponent<BoxCollider2D>();
        sprite=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    void Move()
    {
        float X=Input.GetAxis("Horizontal");
        float Y=Input.GetAxis("Vertical");
        Vector2 direction=new Vector2(X,Y);

        if(Input.GetAxis("Horizontal")>0)
        {
            sprite.flipX=true;
           anim.SetBool("walk",true);
          transform.Translate(direction*walkSpeed*Time.deltaTime);
        }
        if(Input.GetAxis("Horizontal")==0)
        {
           anim.SetBool("walk",false);
        }
        if(Input.GetAxis("Horizontal")<0)
        {
            sprite.flipX=true;
           anim.SetBool("walk",true);
          transform.Translate(direction*walkSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space)&&IsGrounded())
        {
           
             rb.AddForce(Vector2.up * jumpHeight,ForceMode2D.Impulse);
              anim.SetTrigger("jump");
        }
    }
    bool IsGrounded()
    {
        return Physics2D.BoxCast(collide.bounds.center,collide.bounds.size,0f,Vector2.down ,.1f,JumpableGround);
    }
   
}

