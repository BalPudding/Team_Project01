using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool pause = false;
    public GameObject pauseScene;
    public GameObject pauseButton;
    public  float fade;
    public Image image;
    public Image image2;
    public bool fadeIn = false;
    public bool fadeout = false;
    public bool fadeIn2 = false;
    public bool fadeout2 = false;


    // Update is called once per frame
    void Update()
    {
        //일시정지
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            Time.timeScale = 0;
            pause = true;
            pauseScene.SetActive(true);
            pauseButton.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            Time.timeScale = 1;
            pause = false;
            pauseScene.SetActive(false);
            pauseButton.SetActive(true);
        }
        //페이드 인/아웃
        if (fadeIn == true || fadeout == true)
        {
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
        if (fadeIn2 == true || fadeout2 == true)
        {
            if (fadeIn2 == true)
            {
                image2.color = new Color(255f, 255f, 255f, fade);
            }
            else if (fadeout2 == true)
            {
                image.color = new Color(255f, 255f, 255f, 0);
            }
            fade += Time.deltaTime;
        }
    }
}
