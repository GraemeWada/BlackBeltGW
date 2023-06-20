using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tick : MonoBehaviour
{
    public GameObject[] a;

    void Update()
    {
        foreach (GameObject b in a){
            b.tag = "Floor";
        }
    }
}
