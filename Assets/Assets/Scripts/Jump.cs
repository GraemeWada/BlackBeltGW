using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpForce;
    public float downSpeed = 12;

    public bool isGrounded;
    public bool doubleJump;
    public bool downPressed;
    public bool swj;
    public bool t;
    public bool d;

    public Vector2 v;
    public GravitySwitch g;

    public Controls cl;

    float fallMultiplier = 1.5f;

    [Header("Test")]
    public bool j;

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
        if(isGrounded){
            d = false;
            doubleJump = false;
            swj = false;
            downPressed = false;
        }
        if(!isGrounded && !d){d = true; doubleJump = true;}
        if(j){
            j=false;
                rb.AddForce(v * jumpForce, ForceMode2D.Impulse);
                t = false;
        }

        if(Input.GetButtonDown("Jump")){
            if (isGrounded)
            {
                rb.AddForce(v * jumpForce, ForceMode2D.Impulse);
                t = false;
            }
            if (doubleJump)
            {
                rb.AddForce(v * jumpForce, ForceMode2D.Impulse);
                doubleJump = false;
            }
            if (swj)
            {
                rb.AddForce(v * jumpForce * 1.75f, ForceMode2D.Impulse);
                swj = false;
            }
        }

        if(cl.v == 0 && !isGrounded)
        {
            t = true;
            if(t && !isGrounded){
                rb.velocity += Physics2D.gravity * fallMultiplier * Time.deltaTime;
            }
        }

        
    }

    void FixedUpdate(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, v * -1, 0.258f, 1 << 6);
        Debug.DrawRay(transform.position, v * -1, Color.red);
        //Debug.Log(hit.collider.name);
        if(hit != false){
            if(hit.collider.tag == "Floor")
            {
                isGrounded = true;
            }
        }
        else{
            isGrounded = false;
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
            t = false;
        }
        if(other.gameObject.tag == "WJB")
        {
            t=false;
            swj = true;
            doubleJump = false;
            isGrounded = false;
        }
    }

    private void OnCollisionExit2D()
    {
        if(isGrounded)
        {
            j=false;
            isGrounded = false;
            doubleJump = true;
        }
        if (swj)
        {
            swj = false;
        }
    }
}
