 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject player;

    public AudioSource jSoundSource;

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
    public bool canUseSemi = true;

    public GravityBody gb;

    public Vector2 v;
    public GravitySwitch g;

    public Controls cl;

    float fallMultiplier = 1.5f;

    public float f;

    public List<ContactPoint2D> contacts = new List<ContactPoint2D>();
    public ContactPoint2D planet;

    Vector2 floorpoint;

    public GameObject trail;
    public GameObject jParticle;

    [Header("Test")]
    public bool j;
    public float pfm;
    public float rTime;
    Vector3 v3;
    public bool useDynamicFloorRaycast = true;

    void Start()
    {
        canUseSemi = true;
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

//i greatly regret my disorganization

    void Update()
    {
        RaycastHit2D hit;

        if (!gb.useGravity)
        {

            hit = Physics2D.Raycast(transform.position, v * -1, 0.35f, 1 << 6);
            rb.GetContacts(contacts);
            foreach (ContactPoint2D cp2d in contacts)
            {
                if (cp2d.collider.tag == "Planet")
                {
                    planet = cp2d;
                }
            }



            if (Vector2.Distance(gb.currentAttractor.FindNearestPointOnSurface(rb), GetV2(rb)) > 0.5f)
            {
                jumpForce = Mathf.Abs((rb.mass * gb.pf / Mathf.Pow(gb.currentAttractor.attMass * 1.75f, 2)) / Mathf.Pow(Vector2.Distance(gb.currentAttractor.FindNearestPointOnSurface(rb), GetV2(rb)), 2));
                cl.speed = Mathf.Abs((Mathf.Pow(2 * Mathf.PI * gb.currentAttractor.colRad, 3) / 3.5f) / Mathf.Pow(Vector2.Distance(gb.currentAttractor.FindNearestPointOnSurface(rb), GetV2(rb)), 2));
            }
            else
            {
                jumpForce = Mathf.Abs((rb.mass * gb.pf / Mathf.Pow(gb.currentAttractor.attMass, 2)) / 0.175f);
                cl.speed = Mathf.Abs((Mathf.Pow(2 * Mathf.PI * gb.currentAttractor.colRad, 3) / 3.5f) / 0.04f);
            }
            v = gb.pv.normalized * 9.81f;


            f = gb.currentAttractor.attGravity * ((gb.currentAttractor.attMass) / 0.0625f);
            }
        else
        {
            if(useDynamicFloorRaycast)
            {
                hit = Physics2D.Raycast(transform.position, floorpoint - GetV2(rb), 0.57f, 1 << 6);
                Debug.DrawRay(transform.position, (floorpoint - GetV2(rb)).normalized * 0.57f, Color.red);
                }
                else
                {
                    if(Physics2D.gravity != new Vector2(0, -9.81f)){
                        hit = Physics2D.Raycast(transform.position, Physics2D.gravity, 0.57f, 1 << 6);
                    }
                    else{
                        hit = Physics2D.Raycast(transform.position, Vector2.down, 0.57f, 1 << 6);
                    }
                    
                    Debug.DrawRay(transform.position, (Vector2.down).normalized * 0.57f, Color.red);
                    }
            RecalculateJump(g);
            jumpForce = 0.62f;
            f = 0;
            cl.speed = 12;
        }

        
        if (hit)
        {
            //Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Floor" || hit.collider.tag == "Planet" || hit.collider.tag == "Semi")
            {
                isGrounded = true;
                t = false;
                swj = false;
                doubleJump = false;
                downPressed = false;
                if (hit.collider.tag == "Semi" && canUseSemi)
                {
                    sObject = hit.collider.gameObject;
                    s = true;
                }
            }
        }
        else
        {
            isGrounded = false;
            s = false;
        }

        
    }

    public Vector2 GetV2(Rigidbody2D rb)
    {
        return new Vector2(rb.transform.position.x, rb.transform.position.y);
    }

    void FixedUpdate(){
        rb.GetContacts(contacts);
        foreach (ContactPoint2D cp2d in contacts)
        {
            if (cp2d.collider.tag == "Floor" || cp2d.collider.tag == "Semi")
            {
                //Debug.Log(cp2d.collider.name);
                //print(rb.GetContacts(contacts));
                floorpoint = cp2d.point;
                v3 = floorpoint;
            }
        }

        if (isGrounded)
        {
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

        //NEW FRICTION CODE
        if(gb.useGravity && isGrounded && !Input.anyKey){
            rb.velocity *= 0.96f;
            print("Friction");
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
        print("RESETSEMI");
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                jSoundSource.Play();
                rb.AddForce(v * jumpForce, ForceMode2D.Impulse);
                t = false;
            }
            if (doubleJump)
            {
                jSoundSource.Play();
                rb.AddForce(v * jumpForce, ForceMode2D.Impulse);
                doubleJump = false;

                GameObject temp = Instantiate(jParticle, player.transform);
                temp.transform.SetParent(null, true);
                //transform.DetachChildren();
            }
            if (swj)
            {
                jSoundSource.Play();
                rb.AddForce(v * jumpForce * 1.75f, ForceMode2D.Impulse);
                swj = false;
            }
        }
        if (Input.GetKeyDown("s") && !downPressed)
        {
            if (!isGrounded)
            {
                rb.AddForce(v * downSpeed * -1, ForceMode2D.Impulse);
                downPressed = true;
            }
            else if (s && canUseSemi)
            {
                sObject.GetComponent<PlatformEffector2D>().surfaceArc = 0;
                s = false;
                canUseSemi = false;
                Invoke("ResetSemi", rTime);
                Invoke("CanSemi", rTime + 0.1f);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f,1f,.2f);
        Gizmos.DrawSphere(v3, 0.2f);

        if(!gb.useGravity){
            Vector3 v_129724 = new Vector3(0,0,0);
            v_129724 = planet.point;
            Gizmos.color = new Color(0f,1f,0f);
            Gizmos.DrawSphere(v_129724, 0.2f);
        }
    }

    void CanSemi(){
        canUseSemi = true;
    }
}
