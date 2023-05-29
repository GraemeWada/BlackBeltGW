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

    public Transform t;

    public bool useSwitchButton = false;
    public bool CanSwitchGravity;

    public bool isLevel50;
    // Start is called before the first frame update
    void Start()
    {
        GCCounter = 0;
        CanSwitchGravity = true;
        t=this.GetComponentInParent<Transform>();
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
                RotateToAngle(225,t);
            }
            if(Input.GetKeyDown(KeyCode.T) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 4;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];
                Invoke("SwitchGravity", 1.0f);
                RotateToAngle(180,t);
            }
            if(Input.GetKeyDown(KeyCode.Y) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 3;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
                RotateToAngle(135,t);
            }
            if(Input.GetKeyDown(KeyCode.F) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 6;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
                RotateToAngle(270,t);
            }
            if(Input.GetKeyDown(KeyCode.H) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 2;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
                RotateToAngle(90,t);
            }
            if(Input.GetKeyDown(KeyCode.N) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 1;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
                RotateToAngle(45,t);
            }
            if(Input.GetKeyDown(KeyCode.V) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 7;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
                RotateToAngle(315,t);
            }
            if(Input.GetKeyDown(KeyCode.B) && CanSwitchGravity){
                CanSwitchGravity = false;
                GCCounter = 0;
                box[temp].tag = "Untagged";
                box[GCCounter].tag = "Floor";
                Physics2D.gravity = v[GCCounter];                
                Invoke("SwitchGravity", 1.0f);
                RotateToAngle(0,t);
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

    public void RotateToAngle(int angle, Transform t){
        t.rotation = new Quaternion(0f,0f,0f,0f);
        t.rotation = Quaternion.Euler(0f, 0f, (float)angle);
    }
}
