using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScroll : MonoBehaviour
{
    public float stopposit;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (gameObject.transform.position.x <= stopposit)
        {
            speed = 0;
        }
    }
}
