using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sl49s1 : MonoBehaviour
{
    public Swidge s;
    public GameObject[] planets;
    public RuntimeAnimatorController a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (s.a) {
            foreach (GameObject o in planets){
                o.GetComponent<GravityAttractor>().repellant=false;
                o.transform.GetChild(0).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = a;
            }
        }
    }
}
