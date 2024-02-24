using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

// The objective of this player controller is to enable the player to jump over obstacles.
// Since the player is not changing directions or moving forward across the screen, all that is required is the ability to jump for the time being.
// Whoever is assigned to the Player this week may alter this script however they see fit.

public class Player : MonoBehaviour
{
    #region Private Fields
    private bool keyPressed = false;
    private float keyHeldDownStartTime;
    private int jumps;
    private int HP ;
    private int points;
    private Rigidbody2D rb;
    public float maxJumpForce = 10f;
    public float minJumpForce = 7f;
    public int maxJumps = 1;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumps = maxJumps;
    }

    void Update()
    {
        // Calculates how long the player has held down the spacebar
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            keyPressed = true;
            keyHeldDownStartTime = Time.time;
        }

        // Force the player to jump at maximum force once the window for a short jump has passed (assuming the player has a jump available)
        // It also allows the player to continuously jump as long as the spacebar is held down
        if (keyPressed && (Time.time - keyHeldDownStartTime >= 0.1f) && jumps >= 1)
        {
            Jump((float)0.1);
        }
        
        // Allows the player to perform a short jump as long as the spacebar is released in time (assuming the player has a jump available)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float keyHeldDownFinalTime = Time.time - keyHeldDownStartTime;
            if (jumps >= 1) { Jump(keyHeldDownFinalTime); }
            keyPressed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && jumps == 0) { jumps = maxJumps; }
    }

    void Jump(float heldLength)
    {
        if (heldLength >= 0.1) 
        {
            //rb.velocity = Vector2.up * maxJumpForce; 
            rb.velocity = new Vector2(0, maxJumpForce);
        }
        else 
        {
            //rb.velocity = Vector2.up * minJumpForce; 
            rb.velocity = new Vector2(0, minJumpForce);
        }

        if (jumps >= 1) { jumps--; } // Safety net to prevent jumps from going below zero
    }
}
