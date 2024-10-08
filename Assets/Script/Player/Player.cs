using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region public
    public float moveSpeed = 5f;
    public float jumpSpeed = 9f;
    public int maxJumpCount = 2; // Số lần nhảy tối đa (2 lần)
    #endregion
    
    #region  private
    private int jumpCount = 0; // Đếm số lần nhảy đã thực hiện
    private bool isGrounded = false;
    private bool playerFacingRight = true;
    private Rigidbody2D rb;
    private float horizontalInput;
    private Animator animator;
    private int attack = 0;
    private float m_timeSinceAttack = 0.0f;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            Jump();
        }

        if ((playerFacingRight && horizontalInput < 0) || (!playerFacingRight && horizontalInput > 0))
        {
            Flip();
        }

        m_timeSinceAttack += Time.deltaTime; // quản lý thời gian combo
        if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.25f)
        {
           Attack();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); // giữ tốc độ và nhảy
        jumpCount++;    // đếm số bước nhảy
        animator.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;  // Xác định khi chạm đất
            jumpCount = 0;   // Reset số lần nhảy
        }
        if (collision.transform.tag == "deadzone")
        {
            animator.SetTrigger("Died");
        }
    }

    private void Attack()
    {
        attack++;

        // Reset combo khi quá số lượng
        if (attack > 3)
            attack = 1;

        // Reset combo khi quá thời gian
        if (m_timeSinceAttack > 1.0f)
            attack = 1;

        // kích hoạt tấn công
        animator.SetTrigger("Attack" + attack);

        // Reset timer
        m_timeSinceAttack = 0.0f;
    }
    private void Flip()
    {
        playerFacingRight = !playerFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}