using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swidge : MonoBehaviour
{
    public GameObject door;
    public Vector3 doorTarget;
    public bool a = false;
    public bool useTargetFromComponent = true;

    public AudioSource clickSounds;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SwidgeOn");
            if(!a){
                clickSounds.Play();
            }
            a = true;
        }
    }

    void Start()
    {
    }
    void Update()
    {
        if(a)
        {
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, doorTarget, Time.deltaTime);
        }
        if (useTargetFromComponent)
        {
            doorTarget = door.GetComponent<Door>().target;
        }
    }
}
