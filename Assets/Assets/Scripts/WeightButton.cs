using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
    public Vector3 target;
    public Vector3 startpos;

    public bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(0.5155001f, 8.867f, 0.1f);
        startpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move(pressed);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "WeightedObject" || c.gameObject.tag == "Player")
        {
            pressed = true;
            //Debug.Log(c.gameObject.name);
        }
    }

    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "WeightedObject" || c.gameObject.tag == "Player") { pressed = true; }
        //Debug.Log(c.gameObject.name);
    }

    void OnCollisionExit2D()
    {
        if (pressed) { pressed = false; }
    }

    void Move(bool p)
    {
        if (p)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startpos, Time.deltaTime);
        }
    }
}
