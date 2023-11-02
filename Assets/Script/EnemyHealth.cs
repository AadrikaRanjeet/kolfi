using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public static EnemyHealth Instance;
    public int Health=100;
   
   
   public void TakeDamage(int damage)
   {
      Health -=damage;
      if(Health<=0)
      {
        Destroy(gameObject);
      }
   }
}
