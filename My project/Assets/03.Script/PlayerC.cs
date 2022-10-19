using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerC : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;
    public int jumpForce = 700;
    private int jumpcount = 0;
    public int hp = 3;
    private bool oneHit = false;
    private bool twoHit = false;
    private bool healCycle = false;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //1히트
        if (transform.position.x < -2.9f)
        { oneHit = false; }
        else if(oneHit == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(-3,-3), 0.01f);
        }
        //2히트
        if (transform.position.x < -5.9f)
        { twoHit = false; }
        else if (twoHit == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(-6, -3), 0.01f);
        }

        //힐사이클
        if(healCycle == true)
        {
            oneHit = false;
            twoHit = false;
            if(hp == 2)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector2(-3, -3), 0.01f);
                if (transform.position.x > -3.1f)
                { healCycle = false; }
            }
            else if(hp == 3)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector2(0, -3), 0.01f);
                if (transform.position.x > -0.1f)
                { healCycle = false; }
            }
        }

        //점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount < 2)
        {
            playerRigidbody.velocity = Vector2.zero;
            
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            jumpcount += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //적 태그
        if (other.gameObject.tag == "Enemy" && hp ==3)
        {
            oneHit = true;
            hp -= 1;
            OnDamaged(gameObject.transform.position) ;
        }
        else if(other.gameObject.tag == "Enemy" && hp == 2)
        {
            twoHit = true;
            hp -= 1;
            OnDamaged(gameObject.transform.position);
        }
        else if(other.gameObject.tag == "Enemy" && hp == 1)
        {
            Die();
        }
        //힐 태그
        if (other.gameObject.tag == "Food")
        {
            hp += 1;
            healCycle = true;
            other.gameObject.SetActive(false);
        }
        //데스 태그
        if (other.gameObject.tag == "Enemy" && hp == 3)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            jumpcount = 0;
        }
    }
    private void Die()
    {
        SceneManager.LoadScene("04.Dead");
    }
    void OnDamaged(Vector2 targetPos2)
    {
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        Invoke("OffDamaged", 3);
    }
    void OffDamaged()
    {
        gameObject.layer = 0;
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
