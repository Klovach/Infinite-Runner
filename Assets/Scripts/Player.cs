using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The objective of this player controller is to enable the player to jump over obstacles.
// Since the player is not changing directions or moving forward across the screen, all that is required is the ability to jump for the time being.
// Whoever is assigned to the Player this week may alter this script however they see fit.

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10f; 

    // Start is called before the first frame update to get the rigid body component. 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player presses the jump key (spacebar in this instance).
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Here, apply a vertical force to the player's Rigidbody2D to make it jump. 
        rb.velocity = Vector2.up * jumpForce;
    }
}
