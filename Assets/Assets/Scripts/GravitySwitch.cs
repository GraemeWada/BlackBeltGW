using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    public int maxGChanges;
    public int GCCounter;
    public Vector2[] v;
    public int[] dir;
    public bool test;
    public int temp;
    public GameObject[] box;
    public float rotation = 120.0f;
    // Start is called before the first frame update
    void Start()
    {
        GCCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            test = false;
            if (GCCounter == maxGChanges)
            {
                GCCounter = 0;
            }
            else
            {
                GCCounter++;
            }
            if ((GCCounter - 1) < 0)
            {
                temp = maxGChanges;
            }
            else
            {
                temp = GCCounter - 1;
            }
            box[temp].tag = "Untagged";
            box[GCCounter].tag = "Floor";
            Physics2D.gravity = v[GCCounter];
            transform.Rotate(0.0f, 0.0f, rotation, Space.Self);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (GCCounter == maxGChanges)
            {
                GCCounter = 0;
            }
            else
            {
                GCCounter++;
            }
            if((GCCounter - 1) < 0)
            {
                temp = maxGChanges;
            }
            else
            {
                temp = GCCounter - 1;
            }
            box[temp].tag = "Untagged";
            box[GCCounter].tag = "Floor";
            Physics2D.gravity = v[GCCounter];
            transform.Rotate(0.0f, 0.0f, rotation, Space.Self);
        }
    }
}
