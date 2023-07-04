using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AlignPlayerZ : MonoBehaviour
{
    void Start(){
        transform.position = new Vector3(transform.position.x, transform.position.y, 9);
    }

    public void ExitToMain(){
        SceneManager.LoadScene(0);
    }
}
