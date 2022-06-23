using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void RBPOne()
    {
        anim.SetTrigger("Click");
        Invoke("ARBPOne", 1f);
    }
    public void ARBPOne()
    {
        SceneManager.LoadScene("nLevel1120");
    }
    public void RBPTwo()
    {
        anim.SetTrigger("Click");
        Invoke("ARBPTwo", 1f);
    }
    public void ARBPTwo()
    {
        SceneManager.LoadScene("nLevel2130");
    }
    public void LBPTwo()
    {
        anim.SetTrigger("Click");
        Invoke("ALBPTwo", 1f);
    }
    public void ALBPTwo()
    {
        SceneManager.LoadScene("nLevel110");
    }
    public void RBPThree()
    {
        anim.SetTrigger("Click");
        Invoke("ARBPThree", 1f);
    }
    public void LBPThree()
    {
        anim.SetTrigger("Click");
        Invoke("ALBPThree", 1f);
    }
    public void ARBPThree()
    {
        SceneManager.LoadScene("nLevel3140");
    }
    public void ALBPThree()
    {
        SceneManager.LoadScene("nLevel1120");
    }
    public void RBPFour()
    {
        anim.SetTrigger("Click");
        Invoke("ARBPFour", 1f);
    }
    public void LBPFour()
    {
        anim.SetTrigger("Click");
        Invoke("ALBPFour", 1f);
    }
    public void ARBPFour()
    {
        SceneManager.LoadScene("nLevel4150");
    }
    public void ALBPFour()
    {
        SceneManager.LoadScene("nLevel2130");
    }
    public void LBPFive()
    {
        anim.SetTrigger("Click");
        Invoke("ALBPFive", 1f);
    }
    public void ALBPFive()
    {
        SceneManager.LoadScene("nLevel3140");
    }

    /*







    */





    public void Level(int LevelNum)
    {
        anim.SetTrigger("Click");
        SceneManager.LoadScene(LevelNum);
    }
}
