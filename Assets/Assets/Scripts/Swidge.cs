using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swidge : MonoBehaviour
{
    public GameObject door;
    public Vector3 doorTarget;
    public bool a = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SwidgeOn");
            a = true;
        }
    }

    void Update()
    {
        if(a)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorTarget, Time.deltaTime);
        }
    }
}
