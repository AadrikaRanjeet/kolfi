using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
   
 
  public GameObject Room;
  public float count=1;
public Vector2 offset;
   void OnTriggerEnter2D(Collider2D other)
   {
   Vector2 newPos = new Vector2(transform.position.x, transform.position.y) + offset;
     if(other.CompareTag("Player"))
     {
            gameObject.SetActive(false);
            Instantiate(Room,newPos,Quaternion.identity);
         
     }
   }
   
   }
