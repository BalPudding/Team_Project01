using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool pause = false;
    private float fade;
    public Image image;
    public bool fadeIn = false;
    public bool fadeout = false;

    // Update is called once per frame
    void Update()
    {
        //일시정지
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            Time.timeScale = 0;
            pause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            Time.timeScale = 1;
            pause = false;
        }
        //페이드 인/아웃
        if (fadeIn == true || fadeout == true)
        {
            Debug.Log(fade);
            if (fadeIn == true)
            {
                image.color = new Color(0f, 0f, 0f, fade);
            }
            else if (fadeout == true)
            {
                image.color = new Color(0f, 0f, 0f, 0f - fade);
            }
            fade += Time.deltaTime;
        }
    }
}
