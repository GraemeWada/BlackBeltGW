using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightVal : MonoBehaviour
{
    public int weight;

    public int id;

    void Start()
    {
        id = Random.Range(1000000, 9999999);
    }
}
