using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image img;

    public bool endScreen = false;
    public bool fin = true;
    // Start is called before the first frame update
    void Start()
    {
        if(!endScreen){
            img = GameObject.Find("fadescreen").GetComponent<Image>();
        }
        if(fin){
            FadeIn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn(){
        StartCoroutine(FadeImage(true));
    }
    public void FadeOut(){
        StartCoroutine(FadeImage(false));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
