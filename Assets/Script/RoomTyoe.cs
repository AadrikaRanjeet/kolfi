using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTyoe : MonoBehaviour
{
    public GameObject objectToSpawn;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void SpawnObject()
    {
        // Generate a random position within the bounds of the room.
        Vector2 randomPosition = new Vector2(Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x), Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y));

        // Instantiate the object at the random position.
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}


