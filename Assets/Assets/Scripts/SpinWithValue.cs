using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWithValue : MonoBehaviour
{
    public float spinval;
    public bool spin;
    public GameObject[] box;
    public float rot;
    private float a = 22.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spin){
            transform.Rotate(0.0f, 0.0f, spinval, Space.Self);
            if(rot >= 360){
                rot = 0;
            }
            rot += spinval;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            if(spin){
                spin = false;
            }
            else
            {
                spin = true;
            }
        }
    }
}
