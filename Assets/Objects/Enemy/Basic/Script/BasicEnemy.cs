using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using UnityEditor;

public class BasicEnemy : MonoBehaviour
{
    #region Vars
    public Player player;
    public float speed = 3f;
    public GameObject leftLimit;
    public GameObject rightLimit;
    public GameObject killCheck;
    public GameObject GroundCheck;
    public bool movingRight = true;
    private Rigidbody2D rb;
    public bool kill = false;
    private bool die = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Will get the enemy rigidbody so the script can manipulate
    }

    void FixedUpdate()
    {
        #region Movement
        rb.velocity = new Vector2(speed, rb.velocity.y);
        #endregion
    }

    #region Flip
    void Flip() // This will turn the enemy sprite and sensors to the other side
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        speed = speed * -1;
    }
    #endregion

    #region OnTriggerExit
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Flip();
        }
    }
    #endregion

    #region OntriggerEnter
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //kill the player
        {
            kill = true;
            player.dead = true;
        }
    }
    #endregion

    #region OnCollisionEnter
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && !kill) //kill the enemy
        {
            Destroy(gameObject);
        }
    }
    #endregion

}
