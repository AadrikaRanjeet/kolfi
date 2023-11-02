using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    
    public SpriteRenderer sprite;
    public static fireball Instance;
    public int direction;
    [SerializeField] private GameObject player;
   void Start()
   {
    sprite=GetComponent<SpriteRenderer>();
    player=GameObject.FindWithTag("Player");
   }

void Update()
{
    Wizard();
}
void Wizard()
{
      if(player.transform.position.x >transform.position.x)
       {
        sprite.flipX=false;
        direction=1;
       }
       else
       {
        sprite.flipX=true;
        direction=-1;
       }
}
   
      
    }


