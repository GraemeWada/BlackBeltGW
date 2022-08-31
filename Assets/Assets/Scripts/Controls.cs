using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    public float speedcap = 25f;
    public float stuck;
    public Jump jump;
    public bool isKeyPressed;

    public Vector2 LeftV;
    public Vector2 RightV;

    public GravitySwitch g;
    public int temp;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);
        if (g != null) 
        {
            int dir = g.dir[g.GCCounter];
            RightV.x = Mathf.Cos(Mathf.Deg2Rad*dir);
                RightV.y = Mathf.Sin(Mathf.Deg2Rad*dir);
                LeftV.x = Mathf.Cos(Mathf.Deg2Rad*(dir+180));
                LeftV.y = Mathf.Sin(Mathf.Deg2Rad*(dir+180));
            temp = g.GCCounter;
        }
        else
        {
            RightV.x = Mathf.Cos(0);
            RightV.y = Mathf.Sin(0);
            LeftV.x = Mathf.Cos(Mathf.PI);
            LeftV.y = Mathf.Sin(Mathf.PI);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float v = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(rb.velocity.x), 2)+Mathf.Pow(Mathf.Abs(rb.velocity.y), 2));
        //float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if( Input.GetAxis("Horizontal") < 0 && rb.velocity.x > (speedcap * -1))
        {
            //Vector3 v = new Vector3(-1 * speed * -Input.GetAxis("Horizontal"), 0, 0);
            rb.AddForce(LeftV * speed * 1.5f, ForceMode2D.Impulse);
            //Debug.Log(rb.velocity);
            //Left
        }
        if (Input.GetAxis("Horizontal") > 0 && rb.velocity.x < speedcap)
        {
            //Vector3 v = Vector3.right * (float)(speed/1.5) * Input.GetAxis("Horizontal");
            rb.AddForce(RightV * speed, ForceMode2D.Impulse);
            //Debug.Log(rb.velocity);
            //Right
        }

        //rb.AddForce(new Vector3(x, 0, 0), ForceMode2D.Impulse);
    }

    void Update()
    {
        if(g != null)
        {
            if(g.GCCounter != temp){
                int dir = g.dir[g.GCCounter];
                RightV.x = Mathf.Cos(Mathf.Deg2Rad*dir);
                RightV.y = Mathf.Sin(Mathf.Deg2Rad*dir);
                LeftV.x = Mathf.Cos(Mathf.Deg2Rad*(dir+180));
                LeftV.y = Mathf.Sin(Mathf.Deg2Rad*(dir+180));
                temp = g.GCCounter;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "PushZone")
        {
            rb.AddForce(Vector3.up * stuck, ForceMode2D.Impulse);
        }
        
    }
}
