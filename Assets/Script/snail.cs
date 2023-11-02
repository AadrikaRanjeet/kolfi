using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snail : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private GameObject player;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponentInParent<Animator>();
        sprite=GetComponentInParent<SpriteRenderer>();
        player=GameObject.FindWithTag("Player");
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(player.transform.position.x<transform.position.x)
            {
                 sprite.flipX=false;
                 anim.SetBool("attack",true);
            }
            else
            {
                 sprite.flipX=true; 
                  anim.SetBool("attack",true);
            }
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
        anim.SetBool("attack",false);
    }
}
