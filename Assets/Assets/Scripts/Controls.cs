using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    public float speedcap = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if( Input.GetAxis("Horizontal") < 0 )
        {
            Vector3 v = Vector3.left * speed;
            rb.AddForce(v, ForceMode2D.Force);
            Debug.Log(v);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 v = Vector3.right * speed;
            rb.AddForce(v, ForceMode2D.Force);
            Debug.Log(v);
        }

        //rb.AddForce(new Vector3(x, 0, 0), ForceMode2D.Impulse);
    }
}
