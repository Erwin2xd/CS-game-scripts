using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLR : MonoBehaviour
{
    private float speed = 8f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private static bool RNGPaused;
    private static bool IsPaused;
    public Animator animator;
    public Joystick joystick;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 144;
        //Screen.SetResolution(1600, 720, true);
    }
    void Update()
    {
        IsPaused = PauseMenu.GameIsPaused;
        RNGPaused = RNG.RNGPaused;
        if (IsPaused == false && RNGPaused == false)
        {
            if (joystick.Horizontal > .2f && !Dash.imDashing)
            {
                animator.SetBool("Run", true);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (joystick.Horizontal < -.2f && !Dash.imDashing)
            {
                animator.SetBool("Run", true);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else if (Dash.imDashing)
            {
                animator.SetBool("Run", true);
                //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
            else
            {
                animator.SetBool("Run", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            if(isFacingRight && rb.velocity.x < 0)
            {
                FlipLeft();
            }
            else if(!isFacingRight && rb.velocity.x > 0)
            {
                FlipRight();
            }
        }
    }
    void FlipRight()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0,0,0);
    }
    void FlipLeft()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
