using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       anim= GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("attack");
            Debug.Log("attack ho rha ");
        }
    }
}
