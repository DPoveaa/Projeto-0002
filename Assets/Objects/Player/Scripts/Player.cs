using UnityEngine;

public class Player : MonoBehaviour
{
    #region Vars
    #region movimentação
    public float speed;
    private float movePlayer;
    private Rigidbody2D rb;
    #endregion
    #region jump
    public float jumpforce;
    public bool pulo, isgrounded;
    public GameObject groundCheck;
    public ParticleSystem landingEffectPrefab;
    public float LandingEffectYOffset;
    bool canLandEffect = true;
    #endregion
    #region Flip var
    public Transform characterSprite; // Referência ao Sprite do Personagem 
    private bool isFacingRight = true; // Verifica se o personagem está virado para a direita
    #endregion
    #region Vida
    public bool dead = false;
    public bool holeDeath = false;
    public int vida = 100;
    #endregion
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int vida;
    }
    void Update()
    {
        #region movimentação
        movePlayer = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movePlayer * speed, rb.velocity.y);
        pulo = Input.GetButtonDown("Jump");
        if (pulo == true && isgrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpforce));
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
        #region if dies
        if (dead)
        {
            PlayerDeath();
        }
        #endregion
    }

    public void PlayerDeath()
    {
        dead = true;
        Destroy(gameObject);
    }

    #region OnCollision

    #region OnCollisionEnter
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Hole"))
        {
            dead = true;
        }
    }
    #endregion

    #endregion

    #region OnTrigger

    #region OnTriggerExit

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canLandEffect = true;
        }
            
    }

    #endregion

    #region OnTriggerEnter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
            LandingEffect();
        }
    }
    #endregion

    #endregion

    #region Void Flip
    void Flip()
    {
        isFacingRight = !isFacingRight; // Inverte o valor de isFacingRight
        Vector3 scale = characterSprite.localScale; //Obtém a escala atual do sprite
        scale.x *= -1; // inverte o eixo x para virar o personagem
        characterSprite.localScale = scale; // Aplica a nova escala ao Sprite
    }
    #endregion

    #region landingEffect

    public void LandingEffect()
    {
        if (canLandEffect)
        {
            Instantiate(landingEffectPrefab, new Vector3(rb.position.x, rb.position.y - LandingEffectYOffset), Quaternion.identity);
            canLandEffect = false;
        }
    }

    #endregion
}