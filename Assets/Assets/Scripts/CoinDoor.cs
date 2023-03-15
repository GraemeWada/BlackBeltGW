using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDoor : MonoBehaviour
{
    public Hazard hazard;
    public Vector3 target;
    public GameObject coin;
    public bool useh = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hazard.coins == 1 && useh)
        {
           gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target, Time.deltaTime);
        }
        if(!useh){
            if(!coin.activeSelf){
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target, Time.deltaTime);
            }
        }
    }
}
