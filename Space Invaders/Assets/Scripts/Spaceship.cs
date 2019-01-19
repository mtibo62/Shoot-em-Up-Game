﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    //adds slight delay between bullets when holding down space bar
    public int bulletDelay = 0;

    //start game off with 100 bullets for player to use 
    public static int numBullets = 100;

   //determins if player is out of ammo and can shoot or not
   static private bool canShoot = true;
    
    //determines if player has been hit by enemy
    //will make player slower and invulnerable for a short time
    static private bool isHit = false;

    //movement speed of ship
    public float speed = 30;

    //initializes Rigidbody
    private Rigidbody2D rb;

    //initializes SpriteRenderer
    public static SpriteRenderer renderer;

    //assigns bullet sprite that spaceship will shoot when holding down space bar/ctrl
    public GameObject theBullet;

    //assigns fireburst sprite that the spaceship will create when moving forward
    public GameObject fireBurst;

    //assigns shield sprite that will be created when player hoolds down shift
    public GameObject shield;

    //assigns UI sprite that will display when player is out of ammo
    public GameObject noAmmo;

    //determines if player is already holding down shoot button so they annot also hold down 
    //sheld button and vice versa
    public static bool isButtonPressed = false;

    //starts player out with 3 points of health
    public static int health = 3;

    //initalizes score variable that will increase whenever the player kills a alien
    public static int score;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        renderer = GetComponent<SpriteRenderer>();
        
        //sets the UI tesxt to the amount of bullets the player starts with
        var textUIComp = GameObject.Find("bulletAmount").GetComponent<Text>();
        textUIComp.text = numBullets.ToString();
    }

    void FixedUpdate()
    {

        // Get keyboard input (left/right/up/down arrows and a/s/d/w)
        float horzMove = Input.GetAxisRaw("Horizontal");
        float vertMove = Input.GetAxisRaw("Vertical");


        if (isHit == false)
        {
            rb.velocity = new Vector2(horzMove * speed, vertMove * speed);
        }
        else{
            rb.velocity = new Vector2(horzMove * (speed/2), vertMove * (speed/2));
        }

        //determines if player is pressing D or right arrow to create the fire burst behind spaceship
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            fireBoost();
        }

      
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    //prevents
    //    if (collision.gameObject.CompareTag("topUI"))  // or if(gameObject.CompareTag("YourWallTag"))
    //    {
    //        rb.velocity = Vector3.zero;
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1") && !Input.GetButton("Fire3"))
            {

                isButtonPressed = true;

                bulletShoot();
            }


            if (Input.GetButton("Jump") && bulletDelay > 5 && isButtonPressed != true)
            {
                bulletShoot();

            }
            bulletDelay++;
        }

        if (Input.GetButtonDown("Fire3") && !Input.GetButton("Jump"))
        {
            isButtonPressed = true;

            Instantiate(shield, new Vector3(transform.position.x + 7, transform.position.y, 0), Quaternion.identity);
          
        }

        

    }

    static public void IncreaseBulletAmountUI()
    {

        canShoot = true;

        var textUIComp = GameObject.Find("bulletAmount").GetComponent<Text>();

        int numBullets = int.Parse(textUIComp.text);

        numBullets += 1; ;

        textUIComp.text = numBullets.ToString();
    }

    void DecreaseBulletAmountUI()
    {
        var textUIComp = GameObject.Find("bulletAmount").GetComponent<Text>();

        int numBullets = int.Parse(textUIComp.text);

        numBullets -= 1; ;

        textUIComp.text = numBullets.ToString();
    }

    void fireBoost()
    {
      

        Instantiate(fireBurst, new Vector3(transform.position.x - 7,transform.position.y,0) , Quaternion.identity);


        

    }

    static public void IncreaseTestUIScore()
    {

        

        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        score = int.Parse(textUIComp.text);

        score += 10;

        textUIComp.text = score.ToString();
    }

    void bulletShoot()
    {

        if (numBullets > 0)
        {
            Instantiate(theBullet, transform.position, Quaternion.identity);
            bulletDelay = 0;

            Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.bulletFire);

            DecreaseBulletAmountUI();

            numBullets--;
        }
        else
        {
            Instantiate(noAmmo, new Vector3(0,0,-1), Quaternion.identity);
            canShoot = false;
        }
    }

    //spaceship collision with enemy that causes blinking to signifiy damage
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "carrier" || col.gameObject.tag == "Alien" || col.gameObject.tag == "AlienBullet")
        {
            StartCoroutine(blink());
        }


    }

    //
    public static IEnumerator blink()
    {
        isHit = true;

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);

        yield return new WaitForSeconds(.05f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
        yield return new WaitForSeconds(.05f);
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);

        yield return new WaitForSeconds(.05f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);

        yield return new WaitForSeconds(.5f);

        isHit = false;
    }
}
