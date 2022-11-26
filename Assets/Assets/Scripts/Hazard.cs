using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hazard : MonoBehaviour
{
    public GameObject explo;
    public GameObject temp;
    public Vector3 pos;
    public GameObject cc;

    public Text coinText;
    public int coins;

    public string currentScene;

    public GameObject player;

    [Header("Test")]
    public bool ClearCoins;
    public int playerprefcoins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        playerprefcoins = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        //pos = transform.position;
        if (ClearCoins)
        {
            ClearCoins = false;
            PlayerPrefs.DeleteKey("Coins");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            //pos = transform.position;
            temp = Instantiate(explo, player.transform);
            transform.DetachChildren();
            player.SetActive(false);
            temp.SetActive(true);
            Invoke("Reload", 1.5f);
           // Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coin")
        {
            coins++;
            coinText.text = coins.ToString();
            temp = Instantiate(cc, collider.gameObject.transform);
            collider.gameObject.transform.DetachChildren();
            collider.gameObject.SetActive(false);
            temp.SetActive(true);
            temp.transform.rotation = new Quaternion(0,0,0,0);
            temp.transform.localScale = new Vector3(1,1,1);
            temp.GetComponent<ParticleSystem>().Play();

            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins")+1));
            Debug.Log(PlayerPrefs.GetInt("Coins"));
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(currentScene);
    }
}
