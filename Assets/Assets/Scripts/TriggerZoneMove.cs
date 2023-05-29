using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneMove : MonoBehaviour
{
    public bool playerHasTriggeredZone = false;
    public GameObject movingObject;
    public Vector3 startingPosition;
    public Vector3 target;
    public bool useTargetFromComponent;

    public GameObject gs;
    public GravitySwitch g;

    public bool resetgs;
    public bool moveobj;
    public int temp;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = movingObject.transform.localPosition;
        playerHasTriggeredZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHasTriggeredZone)
        {
            if (moveobj)
            {   
                if (useTargetFromComponent)
                {
                target = movingObject.GetComponent<Door>().target;
                }
                movingObject.transform.localPosition = Vector3.Lerp(movingObject.transform.localPosition, target, Time.deltaTime);
            }

            Invoke("DAT", 5f);

            if (resetgs)
            {
                if ((g.GCCounter - 1) < 0)
                {
                    temp = g.maxGChanges;
                }
                else
                {
                    temp = g.GCCounter - 1;
                }
                g.GCCounter = 0;
                g.box[temp].tag = "Untagged";
                g.box[g.GCCounter].tag = "Floor";
                Physics2D.gravity = g.v[g.GCCounter];
                g.RotateToAngle(0, g.t);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            playerHasTriggeredZone = true;
        }
    }

    void DAT()
    {
        Destroy(this.gameObject);
    }

}
