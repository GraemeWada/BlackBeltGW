using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPosition : MonoBehaviour
{
    public Vector3 target;
    public Vector3 start;
    public bool useCurrentPosition = true;
    public bool useLocalPosition = true;
    public void Mover()
    {
        if(useCurrentPosition && useLocalPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
        }
        else if (!useCurrentPosition && useLocalPosition)
        {
            transform.localPosition = Vector3.Lerp(start, target, Time.deltaTime);
        }
        else if (useCurrentPosition && !useLocalPosition)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        }
        else{
            transform.position = Vector3.Lerp(start, target, Time.deltaTime);
        }
    }
}
