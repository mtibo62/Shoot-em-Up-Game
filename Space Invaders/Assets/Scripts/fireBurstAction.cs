using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBurstAction : MonoBehaviour

{
    public float speed = .5f;

    private Rigidbody2D rb;

    Vector3 targetScale;

   

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,0,90);

        //transform.position = Spaceship.gameObject.position + gameObject1.TransformDirection(new Vector3(0, 1, -1));

        rb = GetComponent<Rigidbody2D>();


        rb.velocity = Vector2.left * 10;
    }




    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);

        if(transform.localScale == targetScale)
        {
            Destroy(gameObject);
        }



    }
}
