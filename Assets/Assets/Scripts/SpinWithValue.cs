using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWithValue : MonoBehaviour
{
    public float spinval;
    public bool spin;
    public GameObject[] box;
    public float rot;
    public int direction;
    public bool canuseeq;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Spin(spinval, direction);
        if(spin){
            transform.Rotate(0.0f, 0.0f, spinval, Space.Self);
            if(rot >= 360){
                rot = 0;
            }
            rot += spinval;
        }
        if(canuseeq && Input.GetKeyDown(KeyCode.Q)){
            direction = 1;
        }
        if(canuseeq && Input.GetKeyDown(KeyCode.E)){
            direction = -1;
        }
        if(canuseeq && Input.GetKeyDown(KeyCode.Alpha2)){
            direction = 0;
        }
        
    }

    void Spin(float val, int dir){
        transform.Rotate(0.0f, 0.0f, spinval * dir, Space.Self);
            if(rot >= 360){
                rot = 0;
            }
            rot += spinval;
    }
}
