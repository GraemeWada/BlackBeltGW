using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtonScript : MonoBehaviour
{
    public Vector3 target;
    public Vector3 pos;
    //public GameObject targetA;
    //public float speed;
    public bool moved = false;
    public Material usedRed;
    public string level;
    public Hazard player;
    public int tempcoins;
    public Vector2 lerp2;
    public bool l8;

    // Start is called before the first frame update
    void Start()
    {
        tempcoins = player.coins;//target = targetA.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(level == "8:b1"){
            
            if(tempcoins != player.coins){
                tempcoins = player.coins;
                l8 = true;
            }
            if(l8){
            transform.localPosition = Vector2.Lerp(transform.localPosition, lerp2, Time.deltaTime);
            }
        }
        if(moved)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
        }
        if(player.coins == 1)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target, Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            moved = true;
            gameObject.GetComponent<MeshRenderer>().material = usedRed;
        }
    }

    public bool SetFalse(bool b){
        b = false;
        return b;
    }
}
