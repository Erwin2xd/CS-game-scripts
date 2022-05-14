using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private int jumpCount;
    public int jumpCountMax = 1;
    private float jumpHeight = 20f;
    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rb;
    private EdgeCollider2D edgeCollider2D;
    public Joystick joystick;
    public Animator animator;
    void Start()
    {
        edgeCollider2D = transform.GetComponent<EdgeCollider2D>();
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(edgeCollider2D.bounds.center, edgeCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    void Update()
    {
        if (IsGrounded())
        {
            jumpCount = 0;
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isFalling", false);
        }
        if (joystick.Vertical > .5f){
            if (IsGrounded())
            {
                rb.velocity = Vector2.up * jumpHeight;
                animator.SetBool("isJumping", true);
            }
            else {
                if (rb.velocity.y <= 0f && joystick.Vertical > .5f)
                {
                    if (jumpCount < jumpCountMax)
                    {
                        rb.velocity = Vector2.up * jumpHeight;
                        jumpCount++;
                        animator.SetBool("isJumping", false);
                        animator.SetBool("isDoubleJumping", true);
                        animator.Play("Base Layer.Knight_double_jump", 0, 0f);
                    }
                }
            }
        }
    }
}