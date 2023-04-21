using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Vars
    #region movimentação
    public float speed;
    public Rigidbody2D playerRB;
    private float movePlayer;
    #endregion
    #region jump
    public float jumpforce;
    public bool pulo, isgrounded;
    public GameObject groundCheck;
    #endregion
    #region Flip var
    public Transform characterSprite; // Referência ao Sprite do Personagem 
    private bool isFacingRight = true; // Verifica se o personagem está virado para a direita
    #endregion
    #region Vida
    public int vida = 100;
    #endregion
    #endregion
    void Start()
    {
        int vida;
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
        #region Flip Float
        float moveHorizontal = Input.GetAxis("Horizontal"); // Obtém a entrada do eixo horizontal (esquerda/direita)
        if (moveHorizontal > 0 && !isFacingRight) // Se o personagem estiver se movendo para a direia, e não estiver virado para a direita
        {
            Flip(); // Chama a função de virar o personagem
        }
        else if (moveHorizontal < 0 && isFacingRight) //Se o personagem estiver se movendo para a esquerda e estiver virado para a direita
        {
            Flip(); // Chama a função de virar o personagem
        }
        #endregion
    }
    #region
    private void OnCollisionEnter2D(Collision2D col)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }
    }
    #endregion
    #region Void Flip
    void Flip() {
        isFacingRight = !isFacingRight; // Inverte o valor de isFacingRight
        Vector3 scale = characterSprite.localScale; //Obtém a escala atual do sprite
        scale.x *= -1; // inverte o eixo x para virar o personagem
        characterSprite.localScale = scale; // Aplica a nova escala ao Sprite
    }
    #endregion
}

