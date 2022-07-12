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

    public int gravity = 1;

    float fallMultiplier = 1.5f;

    void Start()
    {
        downSpeed = 12;
    }

    void Update()
    {
        //var vertical = Input.GetAxis("Vertical") * downSpeed * Time.deltaTime;
        if(Input.GetKeyDown("s") && !isGrounded && !downPressed)
        {
            rb.AddForce(Vector3.down * downSpeed * gravity, ForceMode2D.Impulse);
            downPressed = true;
        }
        // if(Input.GetKeyDown("s"))
        // {
        //     rigidbody.AddForce(Vector3.down * downSpeed * vertical, ForceMode2D.Impulse);
        // }
        if(Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(Vector3.up * jumpForce * gravity, ForceMode2D.Impulse);
        }
        if(Input.GetButtonDown("Jump") && doubleJump && !isGrounded){
            rb.AddForce(Vector3.up * jumpForce * gravity, ForceMode2D.Impulse);
            doubleJump = false;
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Physics2D.gravity * fallMultiplier * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGrounded = true;
            doubleJump = false;
            downPressed = false;
        }
        if(other.gameObject.tag == "WJB")
        {
            doubleJump = true;
        }
    }

    private void OnCollisionExit2D()
    {
        if(isGrounded)
        {
            isGrounded = false;
            doubleJump = true;
        }
    }
}
