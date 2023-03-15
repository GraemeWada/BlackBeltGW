using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sl34s3 : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public Swidge s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(s.a){
            Destroy(s1);
            Destroy(s2);
        }
    }
}
