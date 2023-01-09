using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPlayer : GravidadePlayer
{
    private float horizontal;
    private float speed = 8f;
    public int PlayerID;
    private bool isFacingRight = true;
    //Dash
    //
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
        }
        if (Input.GetButtonUp("Jump") && rig.velocity.y > 0f)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);
        }
        if (horizontal>0 && IsGrounded())
        {
            //audio.audioPassos.Play();
        }
        else
        {
            //audio.audioPassos.Pause();
        }
        Flip();
        rig.velocity = new Vector2(horizontal * speed, rig.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void AnimacaoPlayerBaixo()
    {

    }
}
