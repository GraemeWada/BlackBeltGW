using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public Vector3 attCenter = Vector2.zero;
    public float attGravity /*= -9.81f */;
    public bool repellant;

    public float attMass;

    // Start is called before the first frame update
    void Start()
    {
        attMass = this.GetComponentInParent<Rigidbody2D>().mass;
        attCenter = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Vector3 FindSurface(Rigidbody2D rb)
    {
        float distance = Vector3.Distance(this.transform.position, rb.transform.position);
        Vector3 normal = Vector3.zero;

        RaycastHit hit;

        if(Physics.Raycast(rb.transform.position, -rb.transform.up, out hit, distance))
        {
            normal = hit.normal;
        }
        return normal;
    }

    public void OrientBody(Rigidbody2D rb, Vector3 normal)
    {
        rb.transform.localRotation = Quaternion.FromToRotation(rb.transform.up, normal)/* * rb.rotation*/;
    }

    public void Attract(Rigidbody2D rb)
    {
        //Debug.Log("attract");
        Vector3 pullVec = FindSurface(rb);
        OrientBody(rb, pullVec);

        float pullForce = 0.0f;

        if (repellant)
        {
            pullForce = (attGravity * ((attMass * rb.mass)
                / Mathf.Pow(Vector3.Distance(this.transform.position + attCenter, rb.transform.position), 2))) * -1;
        }
        else
        {
            pullForce = (attGravity * ((attMass * rb.mass)
                / Mathf.Pow(Vector3.Distance(this.transform.position + attCenter, rb.transform.position), 2)));
        }

        Debug.Log(pullForce);

        pullVec = rb.transform.position - attCenter;

        rb.AddForce(pullVec.normalized * pullForce * Time.deltaTime);
    }

    
}
