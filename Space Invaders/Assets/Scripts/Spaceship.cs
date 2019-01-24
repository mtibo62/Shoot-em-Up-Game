using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{

    public static Spaceship Instance = null;


    //adds slight delay between bullets when holding down space bar
    public int bulletDelay = 0;

    //start game off with 100 bullets for player to use 
    public static int numBullets;

   //determins if player is out of ammo and can shoot or not
   static private bool canShoot = true;
    
    //determines if player has been hit by enemy
    //will make player slower and invulnerable for a short time
    static public bool isHit;

    //movement speed of ship
    public float speed;

    //initializes Rigidbody
    private Rigidbody2D rb;

    //initializes SpriteRenderer
    public static SpriteRenderer renderer;

    //assigns bullet sprite that spaceship will shoot when holding down space bar/ctrl
    public GameObject theBullet;

    public GameObject hackBullet;

    //assigns fireburst sprite that the spaceship will create when moving forward
    public GameObject fireBurst;

    //assigns shield sprite that will be created when player hoolds down shift
    public GameObject shield;

    //assigns UI sprite that will display when player is out of ammo
    public GameObject noAmmo;

    //assigns UI sprite that will display when player has hack ready
    public GameObject hackReadyDisplay;

    //determines if player is already holding down shoot button so they annot also hold down 
    //sheld button and vice versa
    public static bool isButtonPressed;

    //starts player out with 3 points of health
    public static int health;

    //initalizes score variable that will increase whenever the player kills a alien
    public static int score;

    //public GameObject helperSpots;

    public GameObject[] hackedSpots;

    public static GameObject nextOpenSpot;
    public static int currentSpot;
    
    public static int amountHacked;

    public deathScreen deathScreen;

    public winScreen winScreen;

    public bool hackReady = false;

    public static int killStreak;

    //public GameObject[] healthObject;

    static int currentHealthSpot;

    //static private bool canRemoveHealth;

    static public bool bossDead;

     




    //////////////////////////////////////////////////////

    void Awake()
    {
        //initializing values of all static vars so when game is restarted everything will work correctly
        canShoot = true;
        isButtonPressed = false;
        health = 5;
        score = 0;
        currentSpot = 0;
        amountHacked = 0;
        isHit = false;
        numBullets = 100;
        killStreak = 0;
        currentHealthSpot = 0;
        //canRemoveHealth = false;
        nextOpenSpot = hackedSpots[0];
        bossDead = false;


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
            rb.velocity = new Vector2(horzMove *  speed, vertMove * speed);
        }
        else
        {

            rb.velocity = new Vector2(horzMove * (speed / 1.5f), vertMove * (speed / 1.5f));
        }

        if (currentSpot <= 5)
        { 
            nextOpenSpot = hackedSpots[currentSpot];
        }

              
    }



    // Update is called once per frame
    void Update()
    {



        //determines if player is pressing D or right arrow to create the fire burst behind spaceship
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            fireBoost();
        }

        //will give the player ablility to shoot once bullet amount is over 0
        if (numBullets > 0)
        {
            canShoot = true;
        }


        ///////////////SHOOTING/////////////////


        //this if statement is checking to see if the player is able to shoot
        if (canShoot)
        {
            //chekcs to see if player is pressing Fire1(ctrl) to shoot a single bullet
            //and that the other action buttons (space/shift) are not also pressed
            if (Input.GetButtonDown("Fire1") && !Input.GetButton("Fire3"))
            {
                isButtonPressed = true;

                bulletShoot();
            }

            //checks to see if player is pressing Jump(Space bar) to create a rapid fire of bullets 
            //also checks the bulletDelay to create a space between fired bullets
            //also makes sure  the other action buttons (space/shift) are not also pressed
            if (Input.GetButton("Jump") && bulletDelay > 5 && !Input.GetButton("Fire3"))
            {


                bulletShoot();
            }
            bulletDelay++;
        }

        //////////CREATE SHIELD ////////////////

        //chekcs to see if player is pressing Fire3 (shift) which will cause the shield to appear
        //also makes sure the other action buttons(space / shift) are not also pressed
        if (Input.GetButtonDown("Fire3") && !Input.GetButton("Jump"))
        {
            isButtonPressed = true;

            Instantiate(shield, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }

        //if(Input.GetButtonUp("Fire3") && Input.GetButtonUp("Fire1") && Input.GetButtonUp("Jump"))
        //{
        //    isButtonPressed = false;
        //}

        ////////HACKED BULLETS///////////////
        if (hackReady == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(hackBullet, new Vector3(transform.position.x + 7, transform.position.y, 0), Quaternion.identity);
                hackReady = false;
                GameObject.Find("hackReadyText").GetComponent<Text>().text = "";
                
            }
        }


        ////DEATH SCREEN////
        if(health <= 0) {

            Destroy(GameObject.Find("hackready"));
            Destroy(GameObject.Find("noammo"));
            //Destroy(gameObject);
            StartCoroutine(deathScreenActivate());
            
        }

        /////CHERCK IF SCORE IS CORRECT FOR HACK ABILITY////////
        if (killStreak >= 5 && currentSpot < 6)
        {
            killStreak = 0;
            hackReady = true;
            GameObject.Find("hackReadyText").GetComponent<Text>().text = "Hack Ready";
            Instantiate(hackReadyDisplay, new Vector3(0, -4, -1), Quaternion.identity);
        }


        /////DESTROYS HEALTH ONJECT WHEN HIT/////
        //if (canRemoveHealth && currentHealthSpot <= 2 && !isHit)
        //{
        //    canRemoveHealth = false;
        //    Destroy(healthObject[currentHealthSpot]);
        //    currentHealthSpot++;

        //}

        ///CHECKS TO SEE IF BOSS IS DEAD///
        if (bossDead)
        {
            Destroy(GameObject.Find("hackready"));
            Destroy(GameObject.Find("noammo"));
            
            StartCoroutine(winScreenActivate());
        }
    }

    //////////CREATING BULLETS/////////////////
    //checks to see if there is enough ammo to shoot and will initialize either the bullets or the noAmmo sprites accordingly
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
            Instantiate(noAmmo, new Vector3(0, -4, -1), Quaternion.identity);
            canShoot = false;
        }
    }


    //////////CHANGING UI///////////////////

    //increases the bullets amount when enemy bullets collide witht he shield when engaged
    static public void IncreaseBulletAmountUI()
    {
        var textUIComp = GameObject.Find("bulletAmount").GetComponent<Text>();

        int numBullets = int.Parse(textUIComp.text);

        numBullets += 1; ;

        textUIComp.text = numBullets.ToString();
    }

    //decreases the bullets amount when the player fires a bullet
    void DecreaseBulletAmountUI()
    {
        var textUIComp = GameObject.Find("bulletAmount").GetComponent<Text>();

        int numBullets = int.Parse(textUIComp.text);

        numBullets -= 1; ;

        textUIComp.text = numBullets.ToString();
    }


    //increases score amount by 10 whenever a alien is destroyed
     static public void IncreaseTestUIScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        score = int.Parse(textUIComp.text);

        score += 10;

        textUIComp.text = score.ToString();

        killStreak++;
    }

    ///////////////CREATING FIRE BOOST///////////////////

    //creates the fireboost sprite when the player presses rigth arrow/D
    void fireBoost()
    {
        Instantiate(fireBurst, new Vector3(transform.position.x - 7,transform.position.y,0) , Quaternion.identity);
    }


    /////BLINKING ANIMATION /////////

    //spaceship collision with enemy that causes blinking to signifiy damage
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isHit && (col.tag == "carrier" || col.gameObject.tag == "AlienBullet" || col.gameObject.tag == "Alien"))
        {
            isHit = true;
            StartCoroutine(blink());

        }


    }

    //causes spaceship to blink when comes in contact with enemies/bullets
    public static IEnumerator blink()
    {
        //when this is true it will cause spaceship to move slower and become invaulnerable for a short epriod of time
        

        //canRemoveHealth = true;

        

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);
        Debug.Log("blink");

        yield return new WaitForSeconds(.05f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
        Debug.Log("blink");
        yield return new WaitForSeconds(.25f);
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);
        Debug.Log("blink");

        yield return new WaitForSeconds(.25f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
        Debug.Log("blink");

        yield return new WaitForSeconds(.5f);

        //when this is true it will cause spaceship to move slower and become invaulnerable for a short epriod of time
        isHit = false;
        


    }


    public IEnumerator deathScreenActivate()
    {
        
        yield return new WaitForSeconds(0);
        deathScreen.setActive();
        Destroy(gameObject);
    }

    public IEnumerator winScreenActivate()
    {

        yield return new WaitForSeconds(1);
        winScreen.setActive();
        
    }
}

