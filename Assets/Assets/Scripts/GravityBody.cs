using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor currentAttractor;
    public Collider2D lastTrigger;
    public Collider2D cac;
    public Rigidbody2D rb;

    public Vector3 pv;
    public float pf;

    public bool useGravity;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponentInParent<Rigidbody2D>();
        useGravity = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(currentAttractor != null && rb != null)
        {
            currentAttractor.Attract(rb);
            useGravity = false;
            pv = currentAttractor.pullVec;
            pf = currentAttractor.pullForce;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Planet")
        {
            currentAttractor = c.GetComponentInParent<GravityAttractor>();
            cac = c;
        }
        else
        {
            if (c.gameObject.name != "Confiner")
            {
                lastTrigger = c;
            }
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.name != "Confiner")
        {
            lastTrigger = c;
        }
    }

    void OnTriggerExit2D()
    {
        if (lastTrigger == cac)
        {
            Debug.Log("Exit");
            currentAttractor = null;
            useGravity = true;
        }
    }
}
