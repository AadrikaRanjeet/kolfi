using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private healthbar script;
    public int health,heal;
    public int damage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemy"))
        {
             Damage(damage);

             Debug.Log("Hurt");
        }
    }
    void Damage(int damage)
    {
        
          health -=damage;
          script.SetHealth(health);
        if(health==0)
        { 
             Destroy(gameObject);
             Debug.Log("Destroyed");
        }
    }
    public void Heal(int heal)
    {
       health=heal;
       script.SetHealth(health);
    }
}
