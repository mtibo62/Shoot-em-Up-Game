using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{

    public int bulletDelay = 0;

    public static int numBullets = 100;

   static private bool canShoot = true;


    public float speed = 30;

    private Rigidbody2D rb;

    public GameObject theBullet;

    public GameObject fireBurst;

    public GameObject shield;

    public GameObject noAmmo;

    public static bool isButtonPressed = false;

    public static int health = 3;

    public static int score;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


        var textUIComp = GameObject.Find("bulletAmount").GetComponent<Text>();
        textUIComp.text = numBullets.ToString();
    }

    void FixedUpdate()
    {

        // Get keyboard input
        float horzMove = Input.GetAxisRaw("Horizontal");
        float vertMove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horzMove * speed, vertMove * speed);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            fireBoost();
        }

      
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("topUI"))  // or if(gameObject.CompareTag("YourWallTag"))
        {
            rb.velocity = Vector3.zero;
        }
    }


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
}
