using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShade : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    PlayerC playerC;
    float fade;
    bool appear = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fade = 0;
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x - playerC.transform.position.x <= 7) 
        {
            appear = true;
        }
        if(appear == true)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, fade);
            fade += Time.deltaTime;
        }
    }
}
