using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //  [SerializeField] private healthbar healthbarscript;
    private int heal=50;



    void Start()
    {
        player=GameObject.FindWithTag("Player");
       
    }
    void Heal()
    {
       if(player!=null)
       {
         PlayerHealth script=  player.GetComponent<PlayerHealth>();
        if(script.health<50)
        {
             script.heal=60;
        }
       }
    }
}
