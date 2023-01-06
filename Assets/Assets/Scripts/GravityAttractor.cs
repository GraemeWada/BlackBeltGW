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

    // Start is called before the first frame update
    void Start()
    {
        if (useRbMass) { attMass = this.GetComponentInParent<Rigidbody2D>().mass; }
        attCenter = new Vector2(this.transform.position.x, this.transform.position.y);
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

        Vector2 dir = new Vector2(rb.transform.position.x, rb.transform.position.y) - attCenter;

        float distance = Vector3.Distance(this.transform.position, rb.transform.position);

        RcH2D = Physics2D.Raycast(rb.transform.position, dir, distance, 1 << 6);

        if (RcH2D)
        {
            if(RcH2D.collider.tag == "Planet")
            {
                point = RcH2D.point;
            }
        }

        return point;
    }

    public void OrientBody(Rigidbody2D rb, Vector3 normal)
    {
        rb.transform.localRotation = Quaternion.FromToRotation(rb.transform.up, normal) * rb.transform.rotation;
    }

    public void Attract(Rigidbody2D rb)
    {
        //Debug.Log("attract");
        pullVec = FindSurface(rb);
        OrientBody(rb, pullVec);

        pullForce = 0.0f;

        if (repellant)
        {
            pullForce = (attGravity * ((attMass * rb.mass)
                / Mathf.Pow(Vector2.Distance(attCenter, new Vector2(rb.transform.position.x, rb.transform.position.y)), 2))) * -1;
        }
        else
        {
            //TODO: If FindNearestPointOnSurface != 0,0 do distance from FNPOS otherwise from centre.
            pullForce = (attGravity * ((attMass * rb.mass)
                / Mathf.Pow(Vector2.Distance(attCenter, new Vector2(rb.transform.position.x, rb.transform.position.y)), 2)));
        }

        //Debug.Log(pullVec);

        pullVec = new Vector2(rb.transform.position.x, rb.transform.position.y) - attCenter;

        rb.AddForce(pullVec.normalized * pullForce * Time.deltaTime);
    }

    
}
