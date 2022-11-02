using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAT : MonoBehaviour
{
    public float seconds;
    void Start()
    {
        Invoke("Delete", seconds);
    }
    void Delete()
    {
        Destroy(this.transform.parent);
    }
}
