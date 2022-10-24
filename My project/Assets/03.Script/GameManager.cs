using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool pause = false;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //일시정지
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            Time.timeScale = 0;
            pause = true;
            gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            Time.timeScale = 1;
            pause = false;
            gameObject.SetActive(false);
        }
    }
}
