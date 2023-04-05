using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wbl41b1 : MonoBehaviour
{
    public WeightButton wb;
    public GameObject o;
    public Vector3 start;
    public Vector3 target;

    public float sdtimeopen;
    public float sdtimeclose;

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
            o.transform.localPosition = Vector3.SmoothDamp(o.transform.localPosition, target, ref v_481274, sdtimeopen);
        }
        else
        {
            o.transform.localPosition = Vector3.SmoothDamp(o.transform.localPosition, start, ref v_481274, sdtimeclose);
        }
        if (asjkfhiuq2hht23icn2394823m98u98rtuctm983u984u289u8)
        {
            target = o.GetComponent<Door>().target;
        }
    }
}
