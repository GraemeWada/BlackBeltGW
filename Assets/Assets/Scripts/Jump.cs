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

    public bool s;
    public GameObject sObject;

    public GravityBody gb;

    public Vector2 v;
    public GravitySwitch g;

    public Controls cl;

    float fallMultiplier = 1.5f;

    public float f;

    public List<ContactPoint2D> contacts = new List<ContactPoint2D>();
    public ContactPoint2D planet;

    Vector2 floorpoint;

    [Header("Test")]
    public bool j;
    public float pfm;
    public float rTime;

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
        gb = this.GetComponentInParent<GravityBody>();
    }

    void Update()
    {
        if (Input.GetKeyDown("s") && !downPressed)
        {
            if (!isGrounded)
            {
                rb.AddForce(v * downSpeed * -1, ForceMode2D.Impulse);
                downPressed = true;
            }
            else if (s)
            {
                sObject.GetComponent<PlatformEffector2D>().surfaceArc = 0;
                s = false;
                Invoke("ResetSemi", rTime);
            }
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
//Debug.Log("jf: " + jumpForce + " pf: " + gb.pf + " v: " + cl.v);

        if(cl.v == 0 && !isGrounded)
        {
            t = true;
            if (t && !isGrounded){
                rb.AddForce ( Physics2D.gravity * fallMultiplier * Time.deltaTime , ForceMode2D.Impulse);
            }
        }

        if (!gb.useGravity)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    public Vector2 GetV2(Rigidbody2D rb)
    {
        return new Vector2(rb.transform.position.x, rb.transform.position.y);
    }

    void FixedUpdate(){

        RaycastHit2D hit;

        rb.GetContacts(contacts);
        foreach (ContactPoint2D cp2d in contacts)
        {
            if (cp2d.collider.tag == "Floor")
            {
                floorpoint = cp2d.point;
            }
        }

        if (!gb.useGravity)
        {

            hit = Physics2D.Raycast(transform.position, v * -1, 0.35f, 1 << 6);
            rb.GetContacts(contacts);
            foreach (ContactPoint2D cp2d in contacts)
            {
                if(cp2d.collider.tag == "Planet")
                {
                    planet = cp2d;
                }
            }



            if (Vector2.Distance(gb.currentAttractor.FindNearestPointOnSurface(rb), GetV2(rb)) > 0.5f)
            {
                jumpForce = Mathf.Abs((rb.mass * gb.pf / Mathf.Pow(gb.currentAttractor.attMass * 1.75f, 2)) / Mathf.Pow(Vector2.Distance(gb.currentAttractor.FindNearestPointOnSurface(rb), GetV2(rb)), 2));
            }
            else
            {
                jumpForce = Mathf.Abs((rb.mass * gb.pf / Mathf.Pow(gb.currentAttractor.attMass, 2)) / 0.125f);
            }
            v = gb.pv.normalized * 9.81f;
             

            f = gb.currentAttractor.attGravity * ((gb.currentAttractor.attMass) / 0.0625f);
            cl.speed = Mathf.Abs((Mathf.Pow(2 * Mathf.PI * gb.currentAttractor.colRad, 3)/2) / Mathf.Pow(Vector2.Distance(gb.currentAttractor.FindNearestPointOnSurface(rb), GetV2(rb)), 2));
        }
        else
        {   
             hit = Physics2D.Raycast(transform.position, floorpoint - GetV2(rb), 0.265f, 1 << 6);
            RecalculateJump(g);
            jumpForce = 0.62f;
            f = 0;
            cl.speed = 12;
        }

        Debug.DrawRay(transform.position, (floorpoint - GetV2(rb)).normalized, Color.red);
        if(hit){
            //Debug.Log(hit.collider.name);
            if(hit.collider.tag == "Floor" || hit.collider.tag == "Planet" || hit.collider.tag == "Semi")
            {
                isGrounded = true;
                t = false;
                swj = false;
                doubleJump = false;
                downPressed = false;
                if(hit.collider.tag == "Semi")
                {
                    sObject = hit.collider.gameObject;
                    s = true;
                }
            }
        }
        else{
            isGrounded = false;
            s = false;
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

    void RecalculateJump(GravitySwitch g)
    {
        if (g != null)
        {
            if (!v.Equals(g.v))
            {
                v = g.v[g.GCCounter] * -1;
            }
        }

        if (Physics2D.gravity * -1 != v)
        {
            v = Physics2D.gravity * -1;
        }
    }

    void ResetSemi()
    {
        sObject.GetComponent<PlatformEffector2D>().surfaceArc = 90;
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
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
    }
}
