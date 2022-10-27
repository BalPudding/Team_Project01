using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSlide : MonoBehaviour
{
    public bool inputJump = false;
    public bool inputSlide = false;
    private PlayerC playerC;
    int jumpC;
    int jumpF;
    Rigidbody2D Prigid;
    // Start is called before the first frame update
    void Start()
    {
        playerC = GetComponent<PlayerC>();
        jumpC = playerC.GetComponent<PlayerC>().jumpcount;
        jumpF = playerC.GetComponent<PlayerC>().jumpForce;
        Prigid = playerC.GetComponent<PlayerC>().playerRigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputJump == true && jumpC < 2)
        {
            Prigid.velocity = Vector2.zero;

            Prigid.AddForce(new Vector2(0, jumpF));

            playerC.jumpcount += 1;
        }
        else
        {
            inputJump = false;
        }
    }
    public void InputJump()
    {
        inputJump = true;
    }
}
