using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBl50 : MonoBehaviour
{
    public PuzzleButton wb;
    public bool press;

    public GameObject o;
    public Vector3 target;
    public Vector3 va = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        wb = this.GetComponentInParent<PuzzleButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wb.pressed && !press)
        {
            press = true;
        }

        target = o.GetComponent<Door>().target;

        if (press == true)
        {
            o.transform.localPosition = Vector3.SmoothDamp(o.transform.localPosition, target, ref va, 2f);
        }
    }
}
