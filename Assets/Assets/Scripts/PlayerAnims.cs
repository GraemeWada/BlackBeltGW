using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    public Animator a;
    public SpriteRenderer s;
    public Controls c;
    public Jump j;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0){
            a.SetTrigger("Walking");
            a.ResetTrigger("Idle");
            //Debug.Log("walking");
        }
        else{
            a.SetTrigger("Idle");
            a.ResetTrigger("Walking");
            //Debug.Log("idle");
        }
        if(Input.GetAxis("Horizontal") > 0){
            transform.localScale = new Vector3(-0.5f,0.5f,0.5f);
        }
        if(Input.GetAxis("Horizontal") < 0){
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
    }
}
