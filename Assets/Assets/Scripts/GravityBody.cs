using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor currentAttractor;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(currentAttractor != null && rb != null)
        {
            currentAttractor.Attract(rb);
        }
    }
}
