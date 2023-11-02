using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllies : MonoBehaviour
{
    public GameObject allyPrefab;
   public float collisionRadius = 1f;
    private List<GameObject> allies = new List<GameObject>();

    void Start()
    {
        // Spawn 5 allies at the player's position.
        for (int i = 0; i < 1; i++)
        {
            GameObject ally = Instantiate(allyPrefab, transform.position, Quaternion.identity);
            allies.Add(ally);
        }
    }
    void Update()
    {
        // Check for collisions between all allies.
        foreach (GameObject ally in GameObject.FindGameObjectsWithTag("Ally"))
        {
            if (ally != gameObject && Vector3.Distance(transform.position, ally.transform.position) < collisionRadius)
            {
                // Move the allies apart.
                transform.position += (transform.position - ally.transform.position).normalized * collisionRadius * Time.deltaTime;
            }
        }
    }
    }


