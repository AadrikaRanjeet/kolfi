using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    public WaveSpawner script;
  [SerializeField] private GameObject[] enemy;

  private float Count;
    void Start()
    {
        enemy=GameObject.FindGameObjectsWithTag("enemy");
        
    }

    
    void Update()
    {
        Count=script.Wavecount;
        if(enemy.Length==0 &&Count==0)
        {
            Debug.Log("Door");
            this.enabled=false;
           
        }
    }

}
