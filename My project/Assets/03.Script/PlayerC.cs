using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public int jumpForce = 700;
    private int jumpcount = 0;
    public int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpcount < 2)
        {
            playerRigidbody.velocity = Vector2.zero;
            
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            jumpcount += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dead")
        {
            gameObject.transform.position = new Vector2(-3,0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            jumpcount = 0;
        }
    }
}
