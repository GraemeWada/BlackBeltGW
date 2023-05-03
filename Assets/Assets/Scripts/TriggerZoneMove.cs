using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneMove : MonoBehaviour
{
    public bool playerHasTriggeredZone = false;
    public GameObject movingObject;
    public Vector3 startingPosition;
    public Vector3 target;
    public bool useTargetFromComponent;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = movingObject.transform.localPosition;
        playerHasTriggeredZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHasTriggeredZone)
        {
            movingObject.transform.localPosition = Vector3.Lerp(movingObject.transform.localPosition, target, Time.deltaTime);
        }
        if (useTargetFromComponent)
        {
            target = movingObject.GetComponent<Door>().target;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.name == "Player")
        {
            playerHasTriggeredZone = true;
            print("Player entered trigger zone");
        }
    }
}
