using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public static enemy2 Instance;

    //speed enemy will move at spawn
    public int speed;

    private Rigidbody2D rb;

    //gets gameobject for the enemybullet
    public GameObject enemyBullet2;

    
    public GameObject theBullet;

    //delay between each shot the enemy has
    private int bulletDelay = 6;

    //controls the delay of the hacked ship
    private int hackedBulletDelay = 0;

    
    private SpriteRenderer spriteRenderer;

    private Transform openSpot;

    public Sprite startSprite;

    public Sprite hackedSprite;


    // Movement speed in units/sec.
    public float moveSpeed = 50;

    private bool beginMove = false;

    private bool spotReached = false;

    private bool isHacked = false;




    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.velocity = Vector2.left * speed;

        StartCoroutine(spawnBullet());

    }

    //methods used to instantiate the enemybulley
    IEnumerator spawnBullet()
    {
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < 4; i++)
        {
            while (isHacked == false)
            {
                Instantiate(enemyBullet2, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
        }
    }


    private void Update()
    {

        //this will not happen until an unhacked enemy is hit with a hack shot
        if (beginMove == true)
        {

            // the step size is equal to speed times frame time.
            float step = moveSpeed * Time.deltaTime;

            //rb.velocity = Vector2.left * 0;
            // move our position a step closer to the target.
            this.transform.position = Vector3.MoveTowards(this.transform.position, openSpot.position, 1);


            //when hackedenemy reaches destination
            if (this.transform.position == openSpot.position)
            {
                beginMove = false;
                spotReached = true;

            }
        }

        //once the hacked enemy reaches its designated spot this will allow them to follow the player
        if (spotReached == true && Spaceship.health != 0)
        {
            this.transform.position = openSpot.position;
        }

        //determines if the enemy is hacked and will allow player control of shooting 
        if (isHacked == true)
        {
            if (Input.GetButton("Jump") && hackedBulletDelay > 10 && !Input.GetButton("Fire3"))
            {
                spawnShot();
            }
            hackedBulletDelay++;
        }
            
        
        //turn ship back to normal upon death
        if(Spaceship.health == 0)
            {
                transform.Rotate(0, 0, 180);
                transform.gameObject.tag = "hacked";
            }
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        //enemy has hit despawner on left of game screen
        if (col.tag == "despawner")
        {
            Destroy(gameObject);
        }

        //enemy has hit the player, but this will only happen when the enemy is not hacked
        ///causes player to blink and enemy gets destroyed
        if (col.tag == "Player" && isHacked != true)
        {
            StartCoroutine(Spaceship.blink());
            Destroy(gameObject);
        }
        
        //if enemy is hit with hacker shot they will be hacked and controled by player
        if (col.tag == "hacker" && isHacked != true)
        {
            Debug.Log("isHit");
            if (Spaceship.currentSpot <= 5)
            {

                isHacked = true;
                beginMove = true;
                openSpot = Spaceship.nextOpenSpot.transform;
                transform.Rotate(0, 0, 180);
                transform.gameObject.tag = "hacked";
                StartCoroutine(ChangeAlienSprite());

                if (Spaceship.currentSpot < 5)
                {
                    Spaceship.currentSpot++;
                }
            }
        }
    }

    //initializes the bullet when enemy is hacked
    void spawnShot()
    {
        if (Spaceship.numBullets > 0)
        {
            Instantiate(theBullet, this.transform.position, Quaternion.identity);
            hackedBulletDelay = 0;
        }
    }

    //changes sprite of enemy when hacked
    public IEnumerator ChangeAlienSprite()
    {
        if (spriteRenderer.sprite == startSprite)
        {
            spriteRenderer.sprite = hackedSprite;
        }
        else
        {
            spriteRenderer.sprite = startSprite;
        }
        yield return null;
    }
}
