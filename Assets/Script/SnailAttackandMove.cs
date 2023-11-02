using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAttackandMove : MonoBehaviour
{
// [SerializeField] private GameObject enemy;
private Transform enemy;
   public float speed;
   public Rigidbody2D rb; 

    void Start()
    {
       // enemy=GameObject.FindWithTag("enemy");
        // rb=GetComponent<Rigidbody2D>();
        // Vector2 moveDir=(enemy.transform.position-transform.position).normalized*speed;
        // rb.velocity=new Vector2(moveDir.x,moveDir.y);
       
    }
    public void SetTarget(Transform newtarget)
    {
        enemy=newtarget;
    }
    void Update()
    {
        if(enemy!=null)
        {
            //move towards the enemy
           transform.position=Vector2.MoveTowards(transform.position,enemy.transform.position,speed*Time.deltaTime);
            Destroy(this.gameObject,1f);
        }
        else
        {
            //destroy the fireball
            Destroy(this.gameObject,1f);
        }
        
    }
}
