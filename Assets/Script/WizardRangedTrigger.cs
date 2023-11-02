using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardRangedTrigger : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    public Transform fireballSpawnPoint;
    public GameObject Fireball;
    [SerializeField] private GameObject player;
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
               anim.SetTrigger("rangedattack");
                 Instantiate(Fireball,fireballSpawnPoint.position,Quaternion.identity);
        }
    }
}
