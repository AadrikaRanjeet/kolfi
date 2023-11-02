using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
   [SerializeField] private  GameObject player; // Reference to the player's transform.
    public float moveSpeed = 2.0f; // Speed at which the ally moves.
    public float xRange = 5.0f; // The range within which the ally will move along the x-axis.

    public float OffsetY;// The desired vertical distance above the player.
    private float originalY;
    private Vector3 offset;// the offset from the player
    private float startX; // Starting x position of the ally.

    void Start()
    {
        startX = transform.position.x; // Store the starting x position.
        player=GameObject.FindWithTag("Player");
        
       // offset=new Vector3(0,OffsetY,0);
    }

    void Update()
    {
        // Calculate the target x position for the ally using Mathf.PingPong to move back and forth.
        float targetX = startX + Mathf.PingPong(Time.time * moveSpeed, xRange);
         originalY = player.transform.position.y+OffsetY; //updating the y positon of bat with offset 
        // Calculate the target position for the ally while maintaining the height.
        Vector3 targetPosition = new Vector3(player.transform.position.x, originalY, transform.position.z);
        transform.position=targetPosition;//updating the bat's positon
        
    }
}
