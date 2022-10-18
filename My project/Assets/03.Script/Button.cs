using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ToStory()
    {
        SceneManager.LoadScene("01.StoryBoard");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
