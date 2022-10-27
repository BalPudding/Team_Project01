using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image;
    public GameObject gameObject01;
    GameManager gameManager;
    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void Fade()
    {
        gameObject.SetActive(false);
    }
    public void FadeIn()
    {
        gameObject01.SetActive(true);
        gameManager.fadeIn2 = true;
    }
    public void Fadeout()
    {
        gameManager.fadeout2 = true;
    }
}
