using Unity.VisualScripting;
using UnityEngine;

public class Character_movement : MonoBehaviour
{
    //default move and jump values
    public float moveSpeed = 5f;
    public float jumpForce = 3f;

    //variable declaration
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    private float conveyorPush = 0f;
    private bool canJump = true;

    //Grounded jump variables
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private bool isGrounded;
    private bool isRunning;

    //animation sprites
    public Sprite idleSprite;
    public Sprite jumpSprite;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //ground check
        isGrounded = IsGrounded();

        //update animator properties for jump
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVel", rb.linearVelocity.y);


        float moveX = 0f;

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump");
        }

        //left right movement
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
            sr.flipX = false; 
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            sr.flipX = true;
            
        }

        rb.linearVelocity = new Vector2(moveX * moveSpeed + conveyorPush, rb.linearVelocity.y);


        if (!isGrounded && IsTouchingWall() && rb.linearVelocity.y > -0.5f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -0.5f);
        }

        animator.SetFloat("yVel", rb.linearVelocity.y);
        animator.SetBool("isRunning", Mathf.Abs(moveX) > 0.01f);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void SetConveyorPush(float push)
    {
        conveyorPush = push;
    }
    public void SetJumpEnabled(bool enabled)
    {
        canJump = enabled;
    }
    private bool IsGrounded()
    {
        Collider2D col = GetComponent<Collider2D>();
        Bounds b = col.bounds;

        // A skinny box near the feet
        Vector2 boxSize = new Vector2(b.size.x * 0.6f, 0.1f);   // narrower than body, very short height
        Vector2 boxCenter = new Vector2(b.center.x, b.min.y + 0.05f); // right at the bottom

        RaycastHit2D hit = Physics2D.BoxCast(
            boxCenter,
            boxSize,
            0f,
            Vector2.down,
            0.02f,
            groundLayer
        );

        return hit.collider != null;
    }

    private bool IsTouchingWall()
    {
        var col = GetComponent<Collider2D>();
        var b = col.bounds;

        Vector2 size = new Vector2(0.05f, b.size.y * 0.7f);
        Vector2 left = new Vector2(b.min.x - 0.02f, b.center.y);
        Vector2 right = new Vector2(b.max.x + 0.02f, b.center.y);

        return Physics2D.OverlapBox(left, size, 0f, wallLayer) ||
               Physics2D.OverlapBox(right, size, 0f, wallLayer);
    }
}