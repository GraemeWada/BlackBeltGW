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

    public bool useSwitchButton = false;
    public bool CanSwitchGravity;
    // Start is called before the first frame update
    void Start()
    {
        GCCounter = 0;
        CanSwitchGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((GCCounter - 1) < 0)
            {
                temp = maxGChanges;
            }
            else
            {
                temp = GCCounter - 1;
            }
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
            box[temp].tag = "Untagged";
            box[GCCounter].tag = "Floor";
            Physics2D.gravity = v[GCCounter];
            transform.Rotate(0.0f, 0.0f, rotation, Space.Self);
        }
        if(useSwitchButton){
            if(Input.GetKeyDown(KeyCode.R) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 5;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];
                Invoke("SwitchGravity", 1.0f);
            }
            if(Input.GetKeyDown(KeyCode.T) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 4;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];
                Invoke("SwitchGravity", 1.0f);
            }
            if(Input.GetKeyDown(KeyCode.Y) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 3;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
            }
            if(Input.GetKeyDown(KeyCode.F) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 6;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
            }
            if(Input.GetKeyDown(KeyCode.H) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 2;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
            }
            if(Input.GetKeyDown(KeyCode.N) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 1;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
            }
            if(Input.GetKeyDown(KeyCode.V) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 7;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
            }
            if(Input.GetKeyDown(KeyCode.B) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 0;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
            }
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

    void SwitchGravity(){
        CanSwitchGravity = true;
    }
}
