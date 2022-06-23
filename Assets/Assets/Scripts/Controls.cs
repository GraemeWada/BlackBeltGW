using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //var y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(x, 0, 0);
    }
}
