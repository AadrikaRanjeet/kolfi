using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldenemy : MonoBehaviour
{
    public Animator anim;
    public float speed = 1f;
    public SpriteRenderer sprite;
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;
    // public SpriteRenderer Sprite;
     void Start()
    {
       anim=GetComponent<Animator>(); 
      
       sprite=GetComponent<SpriteRenderer>();

    }
    void Update()
    {
      transform.Translate(-Vector2.right*speed*Time.deltaTime);

      RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
      if(groundInfo.collider==false)
      {
            if(movingRight==true)
            {
                  //rotate the player to 180* along y axis
                  transform.eulerAngles = new Vector3(0,-180,0);
                  movingRight=false;
            }
            else
            {
                  transform.eulerAngles=new Vector3(0,0,0);
                  movingRight=true;
            }
      }
    }
    
//     void LeftMove()
//     {
//           sprite.flipX=true;
            
//     }
//     void RightMove()
//     {
//           sprite.flipX=false;
            
//     }
}

