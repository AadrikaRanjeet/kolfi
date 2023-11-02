using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
public class Attack : MonoBehaviour
{
    public static Attack Instance;
    public event Action<GameObject>OnenemyDetected;
    public int MeleeAttackDamage;
    public float RangeattackDamage;
    public float Stamina;
    public float hurtbox;
    public Animator anim;
    public Rigidbody2D rb;
    public BoxCollider2D collide;
    public LayerMask enemyLayers;
    public Transform melleeAttack;
    public float attackRange;
    public int Count=0;
    public  GameObject enemyObj;

    void Start()
    {
     anim=GetComponent<Animator>();
     rb=GetComponent<Rigidbody2D>();
     collide=GetComponent<BoxCollider2D>();
    Instance=this;
    
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    void attack()
    {
        if(Input.GetMouseButtonDown(1))
        {
            //Play an Attack Animation
            anim.SetTrigger("attack");

            //Detect Enemies in range of attack
            Collider2D [] hitEnemies=Physics2D.OverlapCircleAll(melleeAttack.position,attackRange,enemyLayers);

            //DamageThem Now
            foreach(Collider2D enemy in hitEnemies)
            {
               Debug.Log("hitting enemies by mellee attack");
               
               //acceessing the enemy gameobject attached to the collider
               enemyObj=enemy.gameObject;
             
               //accessing the script 
               EnemyHealth health=enemyObj.GetComponent<EnemyHealth>();

               if(health!=null)
               {
                 health.TakeDamage(MeleeAttackDamage);
               }

            }

        }
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Rangedattack");
        }
      
    }
      void OnDrawGizmosSelected()
     {
        if(melleeAttack==null)
        return;

        Gizmos.DrawWireSphere(melleeAttack.position,attackRange);
     }
        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Count=1;
            enemyObj=other.gameObject;
            Debug.Log(enemyObj.name);
          anim.SetTrigger("damage");
           OnenemyDetected?.Invoke(enemyObj);
         
        }
    }
 
       
    
    
}
