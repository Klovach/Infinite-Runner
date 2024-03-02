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
    private bool grounded = true;
    private float keyHeldDownStartTime;
    private int jumps;
    private int HP ;
    private int points;
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    #endregion

    #region Public Fields
    public float maxJumpForce = 10f;
    public float minJumpForce = 7f;
    public int maxJumps = 1;
    public int maxHP = 5;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        jumps = maxJumps;
        HP = maxHP;
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

        // Check if player is grounded and if the player has held down shift key to crouch. Then scale appropriately 
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && grounded == true) 
        {
            bc.size = new Vector2(0.56f, 0.3f);
            bc.offset = new Vector2(0.03f, -0.17f);
        }
        else 
        {
            bc.size = new Vector2(0.29f, 0.6f);
            bc.offset = new Vector2(-0.005f, -0.018f);
        }

        print("HP:" + HP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && jumps == 0) { jumps = maxJumps; }
        if (collision.gameObject.CompareTag("Ground")) { grounded = true; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object")) 
        { 
            HP--;
            StartCoroutine(HitEffect());
        }
    }

    void Jump(float heldLength)
    {
        if (heldLength >= 0.1) { rb.velocity = Vector2.up * maxJumpForce; }
        else { rb.velocity = Vector2.up * minJumpForce; }

        grounded = false;
        if (jumps >= 1) { jumps--; } // Safety net to prevent jumps from going below zero
    }

    private IEnumerator HitEffect()
    {
        Color currentColor = sr.color;

        // Transparency cycle
        for (int i = 0; i <= 3; i++) 
        { 
            // Make sprite transparent
            currentColor.a = 0.25f;
            sr.color = currentColor;
            yield return new WaitForSeconds(0.1f);

            // Remove transparency
            currentColor.a = 1f;
            sr.color = currentColor;
            yield return new WaitForSeconds(0.1f);
        }

        // Ensure sprite losses transparency
        currentColor.a = 1f;
        sr.color = currentColor;
    }
}
