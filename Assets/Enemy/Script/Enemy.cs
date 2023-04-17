using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Vars
    public float speed = 3f;
    public GameObject leftLimit;
    public GameObject rightLimit;
    public GameObject killCheck;
    public GameObject GroundCheck;
    private bool isGrounded = true;
    public bool movingRight = true;
    private Rigidbody2D rb;
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
            isGrounded = false;
        }
    }
    #endregion

    #region OntriggerEnter
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    #endregion

    #region OnCollisionEnter
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Play hurt animation or sound
            Destroy(gameObject);
        }
    }
    #endregion
}
