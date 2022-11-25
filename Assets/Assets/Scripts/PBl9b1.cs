using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBl9b1 : MonoBehaviour
{
    public PuzzleButton wb;
    public bool press;
    public Vector3 spawn;
    public int limit = 12;
    public int objCount;
    public GameObject[] wObj;
    // Start is called before the first frame update
    void Start()
    {
        wb = this.GetComponentInParent<PuzzleButton>();
        objCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(wb.pressed && !press)
        {
            press = true;
            if (objCount < limit)
            {
                Instantiate(wObj[Random.Range(0, 6)], spawn, new Quaternion(0, 0, 0, 0), transform.parent);
                objCount++;
            }
        }
        if (!wb.pressed)
        {
            press = false;
        }
    }
}
