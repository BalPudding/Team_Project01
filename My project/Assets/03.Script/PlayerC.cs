using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerC : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public int jumpForce = 700;
    private int jumpcount = 0;
    public int hp = 3;
    private bool oneHit = false;
    private bool twoHit = false;
    private bool healCycle = false;
    private bool oneFall = false;
    private bool twoFall = false;
    public GameObject hitplatform;
    private bool blink = false;
    float fade;
    public GameObject shieldObj;
    private bool shield = false;
    public GameObject superpowerObj;
    public GameObject notfallObj;
    private bool notfallB = false;
    private SpriteRenderer NotFallSprite;
    private bool isGround = true;
    private bool isRising = false;
    private bool isPower = false;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        NotFallSprite = notfallObj.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //hp최댓값제한
        if(hp>3)
        {
            hp = 3;
        }
        //보호막
        if(shield == true)
        {
            shieldObj.SetActive(true);
        }
        //1히트
        if (shield == true && oneHit == true)
        {
            oneHit = false;
            shield = false;
            shieldObj.SetActive(false);
        }
        else if (transform.position.x < -2.9f)
        { oneHit = false; }
        else if(oneHit == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(-3,-3), 0.01f);
        }
        //2히트
        if (shield == true && twoHit == true)
        {
            twoHit = false;
            shield = false;
            shieldObj.SetActive(false);
        }
        if(transform.position.x < -5.9f)
        { twoHit = false; }
        else if (twoHit == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(-6, -3), 0.01f);
        }
        //낙사 1히트
        if (transform.position.x < -2.9f)
        { oneFall = false; }
        else if (oneFall == true)
        {
            transform.position = new Vector2(-3, -3);
        }

        //낙사 2히트
        if (transform.position.x < -5.9f)
        { twoFall = false; }
        else if (twoFall == true)
        {
            transform.position = new Vector2(-6, -3);
        }

        //힐사이클
        if (healCycle == true)
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
        //블링크
        if (blink == true)
        {

            if (fade < 0.5f)
            { 
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f - fade); 
            }
            else
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, fade);
                if(fade>1f)
                {
                    fade = 0;
                }
            }
            fade += Time.deltaTime;
        }
        //낫폴 블링크
        if (notfallB == true)
        {

            if (fade < 0.5f)
            {
                NotFallSprite.color = new Color(1f, 1f, 1f, 1f - fade);
            }
            else
            {
                NotFallSprite.color = new Color(1f, 1f, 1f, fade);
                if (fade > 1f)
                {
                    fade = 0;
                }
            }
            fade += Time.deltaTime;
        }

        //애니메이터
        animator.SetBool("Grounded", isGround);
        animator.SetBool("Rising", isRising);
        animator.SetBool("Power", isPower);
        if(playerRigidbody.velocity.y<0)
        {
            isRising = false;
        }
        if (playerRigidbody.velocity.y > 0)
        {
            isRising = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            isGround = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) == false && jumpcount == 0)
        {
            isGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //적 태그
        if (other.gameObject.tag == "Enemy" && hp ==3)
        {
            oneHit = true;
            hp -= 1;
            other.gameObject.SetActive(false);
            OnDamaged(gameObject.transform.position) ;
        }
        else if(other.gameObject.tag == "Enemy" && hp == 2)
        {
            twoHit = true;
            hp -= 1;
            other.gameObject.SetActive(false);
            OnDamaged(gameObject.transform.position);
        }
        else if(other.gameObject.tag == "Enemy" && hp == 1)
        {
            Die();
        }
        //데스 태그
        if (other.gameObject.tag == "Death" && hp == 3)
        {
            oneFall = true;
            hp -= 1;
            OnDamaged(gameObject.transform.position);
        }
        else if (other.gameObject.tag == "Death" && hp == 2)
        {
            twoFall = true;
            hp -= 1;
            OnDamaged(gameObject.transform.position);
        }
        else if (other.gameObject.tag == "Death" && hp == 1)
        {
            Die();
        }
        //힐 태그
        if(other.gameObject.tag =="Food")
        {
            Heal();
            other.gameObject.SetActive(false);
        }
        //실드 태그
        if(other.gameObject.tag =="Shield")
        {
            shield = true;
            other.gameObject.SetActive(false);
        }
        //슈퍼파워 태그
        if(other.gameObject.tag =="SuperPower")
        {
            OnSuperPower();
            other.gameObject.SetActive(false);
        }
        //낫폴 태그
        if(other.gameObject.tag == "NotFall")
        {
            NotFall();
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            jumpcount = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isRising = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }
    private void Die()
    {
        SceneManager.LoadScene("04.Dead");
    }
    void OnDamaged(Vector2 targetPos2)
    {
        blink = true;
        hitplatform.SetActive(true);
        gameObject.layer = 11;
        Invoke("OffDamaged", 3);
    }
    void OffDamaged()
    {
        blink = false;
        hitplatform.SetActive(false);
        gameObject.layer = 0;
    }
    void OnSuperPower()
    {
        superpowerObj.SetActive(true);
        isPower = true;
        gameObject.layer = 11;
        playerRigidbody.velocity = Vector2.zero;
        transform.Translate(new Vector3(0, 2.5f, 0));
        playerRigidbody.gravityScale = 0;
        jumpcount = 3;
        Invoke("OffSuperPower", 3);
    }
    void OffSuperPower()
    {
        superpowerObj.SetActive(false);
        isPower = false;
        gameObject.layer = 0;
        playerRigidbody.gravityScale = 1;
        OnDamaged(gameObject.transform.position);
    }
    void Heal()
    {
        hp += 1;
        healCycle = true;
    }
    void NotFall()
    {
        notfallObj.SetActive(true);
        Invoke("OffNotFall", 3);
    }
    void OffNotFall()
    {
        notfallB = true;
        Invoke("QuitNotFall", 3);
    }
    void QuitNotFall()
    {
        notfallObj.SetActive(false);
    }
}
