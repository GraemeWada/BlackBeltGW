using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject LinkedDoor;
    public Vector3 target;
    public bool a = false;

    public GameObject LockUI;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;

    public int eins;
    public int zwei;
    public int drei;
    public int vier;

    public int uno = 0;
    public int dos = 0;
    public int tres = 0;
    public int cuatro = 0;

    public bool un;
    public bool deux;
    public bool trois;
    public bool catre;

    public GameObject[] ichi;
    public GameObject[] ni;
    public GameObject[] san;
    public GameObject[] shi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            LockUI.SetActive(true);
        }
    }

    void Update()
    {
        if (a)
        {
            LinkedDoor.transform.position = Vector3.Lerp(LinkedDoor.transform.position, target, Time.deltaTime);
        }
        if (uno == eins) { un = true; } else { un = false }
        if (dos == zwei) { deux = true; } else { deux = false }
        if (tres == drei) { trois = true; } else { trois = false }
        if (cuatro == vier) { catre = true; } else { catre = false }
    }

    void OneClicked()
    {
        
    }
}
