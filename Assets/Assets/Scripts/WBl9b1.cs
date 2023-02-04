using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBl9b1 : MonoBehaviour
{
    public WeightButton wb;
    public GameObject o;
    public Vector3 start;
    public Vector3 target;

    //use door target obj
    public bool asjkfhiuq2hht23icn2394823m98u98rtuctm983u984u289u8 = false;
    // Start is called before the first frame update
    void Start()
    {
        wb = this.GetComponentInParent<WeightButton>();
        start = o.transform.localPosition;
        if (asjkfhiuq2hht23icn2394823m98u98rtuctm983u984u289u8)
        {
            target = o.GetComponent<Door>().target;
        }
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
