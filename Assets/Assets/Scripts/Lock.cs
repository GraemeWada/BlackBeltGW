using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public GameObject LinkedDoor;
    public Vector3 target;
    public bool a = false;
    public bool pmopen;

    public GameObject LockUI;
    public GameObject LockIcon;
    public GameObject GameLockIcon;
    public GameObject PM;

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

    public Sprite[] ichi;
    public Sprite[] ni;
    public Sprite[] san;
    public Sprite[] shi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !a)
        {
            Time.timeScale = 0;
            LockUI.SetActive(true);
            PM.SetActive(false);
            pmopen = false;
        }
    }

    void Update()
    {
        if (a)
        {
            LinkedDoor.transform.position = Vector3.Lerp(LinkedDoor.transform.position, target, Time.deltaTime);
            GameLockIcon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LockOpen");
            LockIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("LockOpen");
        }
        if (uno == eins) { un = true; } else { un = false; }
        if (dos == zwei) { deux = true; } else { deux = false; }
        if (tres == drei) { trois = true; } else { trois = false; }
        if (cuatro == vier) { catre = true; } else { catre = false; }
        if (un && deux && trois && catre) {a = true;}
        if (Input.GetKeyDown(KeyCode.Escape) && !pmopen)
        {
            Time.timeScale = 1;
            LockUI.SetActive(false);
            PM.SetActive(true);
            pmopen = true;
        }
    }

    void Start()
    {
        pmopen = true;
    }

    public void OneClicked()
    {
        uno++;
        if(uno>9){uno=0;}
        one.GetComponent<Image>().sprite = ichi[uno];
    }
    public void TwoClicked()
    {
        dos++;
        if(dos>9){dos=0;}
        two.GetComponent<Image>().sprite = ni[dos];
    }
    public void ThreeClicked()
    {
        tres++;
        if(tres>9){tres=0;}
        three.GetComponent<Image>().sprite = san[tres];
    }
    public void FourClicked()
    {
        cuatro++;
        if(cuatro>9){cuatro=0;}
        four.GetComponent<Image>().sprite = shi[cuatro];
    }
}
