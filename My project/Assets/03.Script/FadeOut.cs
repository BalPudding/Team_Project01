using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    float fade;
    public Image image;
    public bool fadeout = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            Debug.Log(fade);
            image.color = new Color(255f, 255f, 255f, fade);
            fade += Time.deltaTime;
            gameObject.SetActive(false);
        }
    }

    public void Fade()
    {
        fadeout = true;
    }
}
