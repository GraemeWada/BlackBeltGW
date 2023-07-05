using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    public float speedcap = 25f;
    public float stuck;
    public bool isKeyPressed;

    public Vector2 LeftV;
    public Vector2 RightV;
    public float v;

    public GravitySwitch g;
    public int temp;
    public Vector2 t;

    public GravityBody gB;

    // Start is called before the first frame update
    void Start()
    {
        gB = this.GetComponentInParent<GravityBody>();
        temp = 9032493;
        Physics2D.gravity = new Vector2(0, -9.81f);
        t = Physics2D.gravity;
        RecalculateControls(g);
    }

    void LateUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 && Mathf.Abs(v) < Mathf.Abs(speedcap) && gB.useGravity)
        {
            rb.AddForce(LeftV * speed * 1.3f * Time.deltaTime, ForceMode2D.Impulse);
            //Left
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && Mathf.Abs(v) < Mathf.Abs(speedcap) && !gB.useGravity){
            rb.AddForce(LeftV * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0 && v < speedcap)
        {
            rb.AddForce(RightV * speed * Time.deltaTime, ForceMode2D.Impulse);
            //Right
        }
    if(gB.useGravity){
        RecalculateControls(g);
    }

        /*if (g != null)
        {
            if (g.GCCounter != temp)
            {
                int dir = g.dir[g.GCCounter];
                RightV.x = Mathf.Cos(Mathf.Deg2Rad * dir);
                RightV.y = Mathf.Sin(Mathf.Deg2Rad * dir);
                LeftV.x = Mathf.Cos(Mathf.Deg2Rad * (dir + 180));
                LeftV.y = Mathf.Sin(Mathf.Deg2Rad * (dir + 180));
                temp = g.GCCounter;
            }
        }*/
        //Debug.Log(v);
    }

    void FixedUpdate()
    {
        v = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(rb.velocity.x), 2) + Mathf.Pow(Mathf.Abs(rb.velocity.y), 2));
        if (!gB.useGravity)
        {
            LeftV.x = gB.pv.normalized.y * -1;
            LeftV.y = gB.pv.normalized.x;
            RightV.x = gB.pv.normalized.y;
            RightV.y = gB.pv.normalized.x * -1;
        }
        if (gB.useGravity)
        {
            RecalculateControls(g);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "PushZone")
        {

            if (g != null)
            {
                rb.AddForce(g.v[g.GCCounter] * -1 * stuck, ForceMode2D.Impulse);
            }
        }
    }

    void RecalculateControls(GravitySwitch g)
    {
        if (g != null)
        {
            print("rec");
            if (g.GCCounter != temp)
            {
                int dir = g.dir[g.GCCounter];
                print(dir);
                RotateToAngle(dir, this.GetComponentInParent<Transform>());
                RightV.x = Mathf.Cos(Mathf.Deg2Rad * dir);
                RightV.y = Mathf.Sin(Mathf.Deg2Rad * dir);
                LeftV.x = Mathf.Cos(Mathf.Deg2Rad * (dir + 180));
                LeftV.y = Mathf.Sin(Mathf.Deg2Rad * (dir + 180));
                temp = g.GCCounter;
            }
        }
        else
        {
            RotateToAngle(0, this.GetComponentInParent<Transform>());
            RightV.x = Mathf.Cos(0);
            RightV.y = Mathf.Sin(0);
            LeftV.x = Mathf.Cos(Mathf.PI);
            LeftV.y = Mathf.Sin(Mathf.PI);
        }
    }

    void RotateToAngle(int angle, Transform t){
        t.rotation = new Quaternion(0f,0f,0f,0f);
        t.rotation = Quaternion.Euler(0f, 0f, (float)angle);
    }
}
