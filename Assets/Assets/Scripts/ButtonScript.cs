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

    // Start is called before the first frame update
    void Start()
    {
        //target = targetA.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(moved)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime);
            Invoke("NextLevel", 1.5f);
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
}
