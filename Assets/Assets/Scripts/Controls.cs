using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    public float speedcap = 25f;
    public Jump jump;
    public bool isKeyPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if( Input.GetAxis("Horizontal") < 0 && rb.velocity.x > (speedcap * -1))
        {
            Vector3 v = new Vector3(-1 * speed * -Input.GetAxis("Horizontal"), 0, 0);
            rb.AddForce(v, ForceMode2D.Impulse);
            Debug.Log(rb.velocity);
        }
        if (Input.GetAxis("Horizontal") > 0 && rb.velocity.x < speedcap)
        {
            Vector3 v = Vector3.right * (float)(speed/1.5) * Input.GetAxis("Horizontal");
            rb.AddForce(v, ForceMode2D.Impulse);
            Debug.Log(rb.velocity);
        }

        //rb.AddForce(new Vector3(x, 0, 0), ForceMode2D.Impulse);
    }
}
