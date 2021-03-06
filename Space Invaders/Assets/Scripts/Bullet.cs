﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {


   

    public float speed = 100;

    private Rigidbody2D rigidbody;

    public Sprite explodedAlienImage;

	// Use this for initialization
	void Start () {

        

        rigidbody = GetComponent<Rigidbody2D>();

       
        rigidbody.velocity = Vector2.right * speed;
	}

    void OnTriggerEnter2D(Collider2D col)
    {


        if(col.tag == "Alien")
        {
            //Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.alienDies);
            Destroy(col.gameObject);
            Spaceship.IncreaseTestUIScore();

            //col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

        }

        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }



    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }


	
}
