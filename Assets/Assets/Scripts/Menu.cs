using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject main;
    public Animator animator;
    void Start()
    {
        animator = main.GetComponent<Animator>();
    }
    public void StartFromFirstLevel()
    {
        animator.SetTrigger("Click");
        Invoke("SFFL", 1.1f);
    }
    public void OpenLevelSelect()
    {
        animator.SetTrigger("Click");
        Invoke("OLS", 1.1f);
    }

    void SFFL()
    {
        SceneManager.LoadScene("Triangle1s1");
    }

    void OLS()
    {
SceneManager.LoadScene("nLevel110");
    }

    public void ShowCredits(){
        animator.SetTrigger("Click");
        Invoke("SC", 1.1f);
    }

    void SC(){
        SceneManager.LoadScene("CREDITSLMAO");
    }

    public void ShowCtrl(){
        animator.SetTrigger("Click");
        Invoke("SCtrl", 1.1f);
    }

    void SCtrl(){
        SceneManager.LoadScene("CONTROLS");
    }
}
