using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    public float a;
    public bool g;
    public bool m;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        if(x != 0 && g)
        {
            m = true;
        }
        else if (x == 0 && g)
        {
            m = false;
        }
        
        if(Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            if (m && !g)
            {
                while (x != 0)
                {
                    transform.Translate(x, 0, 0);
                    if (x < 0)
                    {
                        x += a;
                    }
                    else
                    {
                        x -= a;
                    }
                }
                m = false;
            }
        }
        else
        {
            transform.Translate(x, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            g = true;
        }
    }
    void OnCollisionExit2D()
    {
        if (g) { g = false; }
    }
}
