using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public Vector2 attCenter;
    public float attGravity /*= -9.81f */;
    public bool repellant;
    public float pullForce;

    public float attMass;

    public Vector3 pullVec;

    public bool useRbMass;

    public float colRad;

    // Start is called before the first frame update
    void Start()
    {
        if (useRbMass) { attMass = this.GetComponentInParent<Rigidbody2D>().mass; }
        attCenter = new Vector2(this.transform.position.x, this.transform.position.y);
        colRad = this.GetComponentInParent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        attCenter = this.transform.position;
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

    public Vector2 FindNearestPointOnSurface(Rigidbody2D rb)
    {
        Vector2 point = Vector2.zero;

        RaycastHit2D RcH2D;

        Vector2 dir = attCenter - new Vector2(rb.transform.position.x, rb.transform.position.y);

        float distance = Vector3.Distance(this.transform.position, rb.transform.position);

        RcH2D = Physics2D.Raycast(rb.transform.position, dir, distance, 1 << 6);

        if (RcH2D)
        {
            if(RcH2D.collider.tag == "Planet")
            {
                point = RcH2D.point;//Debug.Log(point);
            }
        }

        
        Debug.DrawRay(rb.transform.position, dir, Color.blue);

        return point;
    }

    //[ContextMenu("Orient")]
    public void OrientBody(Rigidbody2D rb, Vector3 normal)
    {
        print("aligned");
        rb.transform.localRotation = Quaternion.FromToRotation(rb.transform.up, normal) * rb.transform.rotation;
    }

    public void Attract(Rigidbody2D rb)
    {
        //Debug.Log("attract");
        pullVec = FindSurface(rb);
        

        pullForce = 0.0f;
        if (FindNearestPointOnSurface(rb) != new Vector2(0, 0))
        {   
            Vector2 surface = FindNearestPointOnSurface(rb);
            if (Vector2.Distance(surface, new Vector2(rb.transform.position.x, rb.transform.position.y)) > 0.5f) {
                
                if (repellant)
                {
                    pullForce = (attGravity * ((attMass * rb.mass)
                        / Mathf.Pow(Vector2.Distance(surface, new Vector2(rb.transform.position.x, rb.transform.position.y)), 2))) * -1;
                }
                else
                {
                    pullForce = (attGravity * ((attMass * rb.mass)
                        / Mathf.Pow(Vector2.Distance(surface, new Vector2(rb.transform.position.x, rb.transform.position.y)), 2)));
                }
            }
            else
            {
                if (repellant)
                {
                    pullForce = (attGravity * ((attMass * rb.mass)
                        / 0.125f)) * -1;
                }
                else
                {
                    pullForce = (attGravity * ((attMass * rb.mass)
                        / 0.125f));
                }
            }
        } 

        //Debug.Log(pullVec);

        pullVec = new Vector2(rb.transform.position.x, rb.transform.position.y) - attCenter;
        OrientBody(rb, pullVec);
        rb.AddForce(pullVec.normalized * pullForce * Time.deltaTime);
    }

    
}
