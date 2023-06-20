using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Vector3 target;
    public Vector3 pos;
    //public GameObject targetA;
    //public float speed;
    public bool moved = false;
    public Material usedRed;

    public string nextLevel;

    public AudioSource buttonSound;

    public Hazard h;

    private bool a;

    private Fade f;

    // Start is called before the first frame update
    void Start()
    {
        h = GameObject.Find("Player(9)").GetComponent<Hazard>();
        f = this.GetComponentInParent<Fade>();
    }
    // Update is called once per frame
    void Update()
    {
        if(moved)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
            Invoke("NextLevel", 1.5f);
            if (!a)
            {
                a = true;
                buttonSound.Play();
                Invoke("F", 0.5f);
                f.FadeOut();
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

    void NextLevel()
    {
        
        SceneManager.LoadScene(nextLevel);
    }

    void F()
    {
        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins")+h.coins));
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
}
