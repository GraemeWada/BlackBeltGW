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

    //1 left, 0 stationary, -1 right

    // Start is called before the first frame update
    void Start()
    {
        gB = this.GetComponentInParent<GravityBody>();
        temp = 9032493;
        Physics2D.gravity = new Vector2(0, -9.81f);
        t = Physics2D.gravity;
        RecalculateControls(g);
    }

    // Update is called once per frame
    void Update()
    {

        v = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(rb.velocity.x), 2) + Mathf.Pow(Mathf.Abs(rb.velocity.y), 2));
        //float h = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") < 0 && (v * -1) > (speedcap * -1))
        {
            rb.AddForce(LeftV * speed * 1.3f * Time.deltaTime, ForceMode2D.Impulse);
            //rb.AddForce(Vector2.left * speed* Time.deltaTime, ForceMode2D.Impulse);
            //Debug.Log(v);
            //Left
        }
        if (Input.GetAxis("Horizontal") > 0 && v < speedcap)
        {
            rb.AddForce(RightV * speed * Time.deltaTime, ForceMode2D.Impulse);
            //rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            //Debug.Log(v);
            //Right
        }
        if (g != null)
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
        }
        //Debug.Log(v);
        //rb.AddForce(new Vector3(x, 0, 0), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        if (!gB.useGravity)
        {
            RightV.x = gB.pv.normalized.y * -1;
            RightV.y = gB.pv.normalized.x;
            LeftV.x = gB.pv.normalized.y;
            LeftV.y = gB.pv.normalized.x * -1;
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
            if (g.GCCounter != temp)
            {
                int dir = g.dir[g.GCCounter];
                RightV.x = Mathf.Cos(Mathf.Deg2Rad * dir);
                RightV.y = Mathf.Sin(Mathf.Deg2Rad * dir);
                LeftV.x = Mathf.Cos(Mathf.Deg2Rad * (dir + 180));
                LeftV.y = Mathf.Sin(Mathf.Deg2Rad * (dir + 180));
                temp = g.GCCounter;
            }
        }
        else
        {
            RightV.x = Mathf.Cos(0);
            RightV.y = Mathf.Sin(0);
            LeftV.x = Mathf.Cos(Mathf.PI);
            LeftV.y = Mathf.Sin(Mathf.PI);
        }
    }
}
