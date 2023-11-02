using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashSpawnpoint : MonoBehaviour
{
    public GameObject flash;
     public SpriteRenderer sprite;
    public Animator anim;
    void Start()
    {
      //sprite.enabled=false;
        anim=GetComponent<Animator>();
          sprite=GetComponent<SpriteRenderer>(); 
      
    }
    void Update()
    {
         if(Archer.Instance.direction==1)
       {
           transform.rotation=Quaternion.Euler(0,0,0);
       }
       else
       {
         transform.rotation=Quaternion.Euler(0,180,0);
         
       }
       if(Input.GetMouseButtonDown(1))
        {
            Shoot();
          
        }
        else
        {
            anim.SetBool("melee",false);
        }
    }
     void Shoot()
     {
        
           anim.SetBool("melee",true); 
        
     }

}
