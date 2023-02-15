using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBl17b1 : MonoBehaviour
{
    public WeightButton wb;
    public GameObject o;
    public Vector3 start;
    public Vector3 target;

    public float sdtime;

    private bool pressed = false;

    Vector3 v_481274 = Vector3.zero;

    //use door target obj
    public bool asjkfhiuq2hht23icn2394823m98u98rtuctm983u984u289u8 = false;
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
            pressed = true;
        }
        if (asjkfhiuq2hht23icn2394823m98u98rtuctm983u984u289u8)
        {
            target = o.GetComponent<Door>().target;
        }
        if (pressed)
        {
            o.transform.localPosition = Vector3.SmoothDamp(o.transform.localPosition, target, ref v_481274, sdtime);
        }
        else
        {
            o.transform.localPosition = Vector3.SmoothDamp(o.transform.localPosition, start, ref v_481274, sdtime);
        }
    }
}
