using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor currentAttractor;
    public Rigidbody2D rb;

    public Vector3 pv;

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
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        currentAttractor = c.GetComponentInParent<GravityAttractor>();
    }

    void OnTriggerExit2D()
    {
        currentAttractor = null;
        useGravity = true;
    }
}
