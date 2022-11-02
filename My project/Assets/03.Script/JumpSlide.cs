using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSlide : MonoBehaviour
{
    PlayerC playerC;
    public bool pointDown;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pointDown == true)
        {
            playerC.isSlide = true;
        }
        else
        {
            playerC.isSlide = false;
        }
    }
    public void InputJump()
    {
        if (playerC.jumpcount < 2)
        { playerC.inputJump = true; }
    }
    public void PointerDown()
    {
        pointDown = true;
        Play();
    }
    public void PointerUp()
    {
        pointDown = false;
    }
    public void Play()
    {
        audioSource.Play();
    }
}
