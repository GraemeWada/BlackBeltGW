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

    // Start is called before the first frame update
    void Start()
    {
        h = GameObject.Find("Player(9)").GetComponent<Hazard>();
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

    void F()
    {
        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins")+h.coins));
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
}
