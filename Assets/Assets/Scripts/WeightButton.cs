using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
    public Vector3 target;
    public Vector3 startpos;

    //not to be confused with weight...
    public int buttonWeight;

    public bool pressed;

    Vector3 v_2347897 = Vector3.zero;

    public RaycastHit2D[] hit;

    private List<Collider2D> tList = new List<Collider2D>();
    private List<int> weights = new List<int>();
    private List<int> ids = new List<int>();

    //Stays 0
    public int weight;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(0.5155001f, 8.867f, 0.1f);
        startpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move(pressed);
        hit = Physics2D.RaycastAll(transform.position, Physics2D.gravity * -1, 1.0f);
        Debug.DrawRay(transform.position, Vector2.up, Color.red);
        foreach (RaycastHit2D i in hit)
        {
            if (i)
            {
                if (i.collider.tag == "WeightedObject")
                {
                    if (!ids.Contains(i.collider.GetComponentInParent<WeightVal>().id))
                    {
                        weight += i.collider.GetComponentInParent<WeightVal>().weight;
                    }
                }
                else if (i.collider.tag == "Player")
                {
                    pressed = true;
                }
                else if (i.collider.tag == "Button") {
                    continue;
                }
                else { pressed = false; }
            }
        }
        if(weight >= buttonWeight)
        {
            pressed = true;
        }
        //Debug.Log(weight);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //Debug.Log(c.gameObject.name);
        
        if (c.gameObject.tag == "WeightedObject")
        {
            int id = c.gameObject.GetComponent<WeightVal>().id;
            if (!tList.Contains(c) && !ids.Contains(id))
            {
                weight += c.gameObject.GetComponent<WeightVal>().weight;
                tList.Add(c);
                ids.Add(id);
            }
            
        }
            foreach (int i in ids)
            {
                Debug.Log(i);
            }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "WeightedObject")
        {
            int id = c.gameObject.GetComponent<WeightVal>().id;
            if (tList.Contains(c) && ids.Contains(id))
            {
                weight -= c.gameObject.GetComponent<WeightVal>().weight;
                tList.Remove(c);
                ids.Remove(id);
            }
        }
    }

    void Move(bool p)
    {
        if (p)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startpos, Time.deltaTime);
        }
    }
}
