using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
    
{
    private bool isPause;
// Start is called before the first frame update
void Start()
    {
        isPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPause == true)
        {
            Time.timeScale = 0;
            return;
        }
        if (isPause == false)
        {
            Time.timeScale = 1;
            return;
        }
    }
    public void StartGame()
    {
        isPause = false;
    }
}
