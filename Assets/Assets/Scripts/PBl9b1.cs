using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBl9b1 : MonoBehaviour
{
    public PuzzleButton wb;
    // Start is called before the first frame update
    void Start()
    {
        wb = this.GetComponentInParent<PuzzleButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
