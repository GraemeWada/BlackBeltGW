using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public Vector2 attCenter = Vector2.zero;
    public float attGravity = -9.81f;

    public float attMass;

    // Start is called before the first frame update
    void Start()
    {
        attMass = this.GetComponentInParent<Rigidbody2D>().mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Vector2 FindSurface(Rigidbody2D rb)
    {
        float distance = Vector2.Distance(this.transform.position, rb.transform.position);
        Vector2 normal = Vector2.zero;

        RaycastHit2D hit;
        if(Physics2D.Raycast(rb.transform.position, -rb.transform.up, out hit, distance))
        {
            normal = hit.normal;
        }
        return normal;
    }

    public void OrientBody(Rigidbody2D rb, Vector2 normal)
    {
        rb.transform.localRotation = Quaternion.FromToRotation(rb.transform.up, normal) * rb.rotation;
    }

    public void Attract(Rigidbody2D rb)
    {
        Vector2 pullVec = FindSurface(rb);
        OrientBody(rb, pullVec);

        float pullForce = 0.0f;

        pullForce = attGravity * ((attMass * rb.mass)
            / Math.Pow(Vector3.Distance(this.transform.position + attCenter, rb.transform.position), 2));

        pullVec = rb.transform.position - attCenter;

        rb.AddForce(pullVec.normalized * pullForce * Time.deltaTime);
    }

    
}
