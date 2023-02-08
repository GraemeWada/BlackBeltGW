using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        //a(target) rel to b(d&s)
        target = b.transform.InverseTransformPoint(a.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
