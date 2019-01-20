using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hackerMove : MonoBehaviour
{
    public float speed = 100;

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();


        rigidbody.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.tag == "Alien")
        {
            //Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.alienDies);

            

            //col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

       


        }

        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
