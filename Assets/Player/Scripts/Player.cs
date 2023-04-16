using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D playerRB;
    private float movePlayer;

    public float jumpforce;
    public bool pulo, isgrounded;

    void Start()
    {

    }


    void Update()
    {
        movePlayer = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(movePlayer * speed, playerRB.velocity.y);
        pulo = Input.GetButtonDown("Jump");
        if (pulo == true && isgrounded == true) {
            playerRB.AddForce(new Vector2(0, jumpforce));
            isgrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) {
            isgrounded = true;
        
        }
    }
}

