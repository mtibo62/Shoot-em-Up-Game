using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hackedShipBullet : MonoBehaviour
{
    public float speed = 100;

    private Rigidbody2D rigidbody;

    public Sprite explodedAlienImage;

    // Use this for initialization
    void Start()
    {



        rigidbody = GetComponent<Rigidbody2D>();


        rigidbody.velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.tag == "Alien")
        {
            //Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.alienDies);

            

            //col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

            DestroyObject(col.gameObject);




        }

        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }



    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }



}

