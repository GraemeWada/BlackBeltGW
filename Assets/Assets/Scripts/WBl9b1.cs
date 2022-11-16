using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBl9b1 : MonoBehaviour
{
    public WeightButton wb;
    public GameObject o;
    public Vector3 start;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        wb = this.GetComponentInParent<WeightButton>();
        start = o.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (wb.pressed)
        {
            o.transform.localPosition = Vector3.Lerp(o.transform.localPosition, target, Time.deltaTime);
        }
        else
        {
            o.transform.localPosition = Vector3.Lerp(o.transform.localPosition, start, Time.deltaTime);
        }
    }
}
