using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region movimentação
    public float speed;
    public Rigidbody2D playerRB;
    private float movePlayer;
    #endregion
    #region jump
    public float jumpforce;
    public bool pulo, isgrounded;
    #endregion
    
    void Start()
    {

    }


    void Update()
    {
        #region movimentação
        movePlayer = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(movePlayer * speed, playerRB.velocity.y);
        pulo = Input.GetButtonDown("Jump");
        if (pulo == true && isgrounded == true) {
            playerRB.AddForce(new Vector2(0, jumpforce));
            isgrounded = false;
        }
        #endregion
        if (movePlayer > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (movePlayer < 0) {
            transform.eulerAngles = new Vector2 (0 ,0);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) {
            isgrounded = true;
        }
    }
}

