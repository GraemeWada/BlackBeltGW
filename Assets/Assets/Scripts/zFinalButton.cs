using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zFinalButton : MonoBehaviour
{
    public Vector3 target;
    public Vector3 pos;
    //public GameObject targetA;
    //public float speed;
    public bool moved = false;
    public Material usedRed;

    public Hazard h;

    private bool a;

    public GameObject finalDoor;
    public Vector3 fdt;

    public GameObject f3s;
    public Vector3 t1 = new Vector3(175,0,0);
    public GameObject finalsection;
    public Vector3 t2 = new Vector3(-100,0,0);
    public GameObject lave;
    public bool booleans2;

    public Vector3 vzero = Vector3.zero;
    public Vector3 vzero1 = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        h = GameObject.Find("Player(9)").GetComponent<Hazard>();
        booleans2 = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(moved)
        {
            finalDoor.transform.localPosition = Vector3.Lerp(finalDoor.transform.localPosition, fdt, Time.deltaTime);
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
            if (!a)
            {
                a = true;
                Invoke("F", 0.5f);
            }
            f3s.transform.localPosition = Vector3.SmoothDamp(f3s.transform.localPosition, t1, ref vzero, 10f);
            lave.SetActive(true);
        }
        if(moved){finalsection.transform.localPosition = Vector3.SmoothDamp(finalsection.transform.localPosition, t2, ref vzero1, 10f);}
    }

    void OnCollisionEnter2D(Collision2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            moved = true;
            gameObject.GetComponent<MeshRenderer>().material = usedRed;
        }
    }

    void F()
    {
        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins")+h.coins));
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
}
