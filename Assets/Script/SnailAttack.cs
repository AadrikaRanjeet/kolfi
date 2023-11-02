using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAttack : MonoBehaviour
{
    public Animator anim;
    private Vector3 initialPosition;
    [SerializeField] private GameObject player;
     public SpriteRenderer sprite;
    void Start()
{
    // Store the initial position of the child game object.
    initialPosition = transform.position;
    anim=GetComponentInParent<Animator>();
      sprite=GetComponentInParent<SpriteRenderer>();
      player=GameObject.FindWithTag("Player");
}

void Update()
{
    // Keep the child game object in its current position by setting its position to its initial position.
    transform.position = initialPosition;
}
    void OnTriggerEnter2D(Collider2D other)
    {
      

        if(other.CompareTag("Player"))
        {
            if(player.transform.position.x<transform.position.x)
            {
               sprite.flipX=false;
                anim.SetTrigger("idle");
            }
            else
            {
                sprite.flipX=true;
                 anim.SetTrigger("idle");
            }
          
        
        }
    }
    
}
