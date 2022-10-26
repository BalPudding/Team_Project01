using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    GameManager gameManager;
    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ToStory()
    {
        gameManager.fadeIn = true;
        Invoke("ToStoryActive", 1);
        
    }
    public void ToStoryActive()
    {
        gameManager.fadeIn = false;
        SceneManager.LoadScene("01.StoryBoard");
    }
    public void Skip()
    {
        gameManager.fadeIn = true;
        Invoke("OnSkip", 1);
    }
    public void OnSkip()
    {
        gameManager.fadeIn = false;
        SceneManager.LoadScene("02.Game");
    }
    public void Quit()
    {
        gameManager.fadeIn = true;
        Invoke("OnQuit", 1);
    }
    public void OnQuit()
    {
        gameManager.fadeIn = false;
        Debug.Log("Quit");
        Application.Quit();
    }
}