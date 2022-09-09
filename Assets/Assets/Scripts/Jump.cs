using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpForce;
    public float downSpeed = 12;
    public float m;

    public bool isGrounded;
    public bool doubleJump;
    public bool downPressed;
    public bool swj;

    public int gravity = 1;
    public Vector2 v;
    public GravitySwitch g;

    float fallMultiplier = 1.5f;

    public RaycastHit2D hit;

    void Start()
    {
        swj = false;
        if(g != null)
        {
            v = g.v[g.GCCounter] * -1;
        }
        else
        {
            v = new Vector2(0, 9.81f);
        }
    }

    void Update()
    {
        if (g != null)
        {
            if (!v.Equals(g.v))
            {
                v = g.v[g.GCCounter] * -1;
            }
        }
        
        if (Input.GetKeyDown("s") && !isGrounded && !downPressed)
        {
            rb.AddForce(v * downSpeed * -1, ForceMode2D.Impulse);
            downPressed = true;
        }

        if(Input.GetButtonDown("Jump")){
            if (isGrounded)
            {
                rb.AddForce(v * jumpForce, ForceMode2D.Impulse);
            }
            if (doubleJump)
            {
                rb.AddForce(v * jumpForce, ForceMode2D.Impulse);
                doubleJump = false;
            }
            if (swj)
            {
                rb.AddForce(v * jumpForce * m, ForceMode2D.Impulse);
                swj = false;
            }
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Physics2D.gravity * fallMultiplier * Time.deltaTime;
        }

        hit = Physics2D.Raycast(transform.position, v * -1 * 0.05f);
        Debug.DrawRay(transform.position, v * -1 * 0.05f, Color.red);

        if(hit.collider.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGrounded = true;
            doubleJump = false;
            downPressed = false;
            swj = false;
        }
        if(other.gameObject.tag == "WJB")
        {
            swj = true;
            doubleJump = false;
            isGrounded = false;
        }
    }

    private void OnCollisionExit2D()
    {
        if(isGrounded)
        {
            isGrounded = false;
            doubleJump = true;
        }
        if (swj)
        {
            swj = false;
        }
    }
}
