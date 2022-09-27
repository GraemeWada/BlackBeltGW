using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Vector2 regularGravity;
    public Vector3 pos;
    public Vector2 centre;
    public float[] distFromCentre = new float[5];
    public int d;
    public int dir;
    // Start is called before the first frame update
    void Start()
    {
        regularGravity = Physics2D.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            pos = c.transform.position;
            distFromCentre[0] = pos.x - centre.x;
            distFromCentre[1] = pos.y - centre.y;
            if(Mathf.Abs(distFromCentre[0]) > Mathf.Abs(distFromCentre[1]))
            {
                d = 0;
            }
            else
            {
                d = 1;
            }
            distFromCentre[3] = Mathf.Sign(distFromCentre[d]) * -9.81f;
            if (d == 0)
            {
                Physics2D.gravity = new Vector2(distFromCentre[3], 0);
            }
            else
            {
                Physics2D.gravity = new Vector2(0, distFromCentre[3]);
            }
            dir = Mathf.Sqrt(Math.Pow(Mathf.Abs(Physics2D.gravity.x), 2) + Math.Pow(Mathf.Abs(Physics2D.gravity.y), 2));
        }
    }
    
    void OnTriggerExit2D()
    {
        Physics2D.gravity = regularGravity;
    }
}
