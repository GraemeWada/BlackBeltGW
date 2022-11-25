using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
    public Vector3 target;
    public Vector3 startpos;

    public int buttonWeight;

    public bool pressed;

    public RaycastHit2D[] hit;

    private List<Collider2D> tList = new List<Collider2D>();
    private List<int> weights = new List<int>();
    private List<int> ids = new List<int>();
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
        hit = Physics2D.RaycastAll(transform.position, Vector2.up, 1.0f);
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
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        int id = c.gameObject.GetComponent<WeightValue>().id;
        if (c.gameObject.tag == "WeightObject" && !tList.Contains(c) && !ids.Contains(id))
        {
            tList.Add(c);
            ids.Add(id);
        }
    }

    void OnCollisionExit2D(Collider2D c)
    {
        int id = c.gameObject.GetComponent<WeightValue>().id;
        if (c.gameObject.tag == "WeightObject" && tList.Contains(c) && ids.Contains(id))
        {
            tList.Remove(c);
            ids.Remove(id);
            weight -= c.gameObject.GetComponent<WeightValue>().weight;
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
