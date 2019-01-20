using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    public GameObject enemyBullet2;

    private int bulletDelay = 6;

    public GameObject hackedEnemy;


    //private static Transform openSpot;


    // Movement speed in units/sec.
    //public float moveSpeed = 50;

    // Time when the movement started.
    //private float startTime;

    // Total distance between the markers.
    //private float journeyLength;

    //private static bool beginMove = false;

  


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.left * speed;

        StartCoroutine(spawnBullet());

    }

    // Update is called once per frame
    IEnumerator spawnBullet()
    {

            yield return new WaitForSeconds(.5f);


            for (int i = 0; i < 4; i++)
            {

                //Instantiate(enemyBullet2, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1);
            
            }
        

    }
    private void Update()
    {
        //if (beginMove == true)
        //{
        //    //journeyLength = Vector3.Distance(transform.position, openSpot.transform.position);

        //    //// Distance moved = time * speed.
        //    //float distCovered = (Time.time - startTime) * speed;

        //    //// Fraction of journey completed = current distance divided by total distance.
        //    //float fracJourney = distCovered / journeyLength;

        //    //// Set our position as a fraction of the distance between the markers.
        //    //transform.position = Vector3.Lerp(transform.position, openSpot.transform.position, fracJourney);

        //    //if(transform.position == openSpot.transform.position)
        //    //{
        //    //    beginLerping = false;
        //    //}

        //    // The step size is equal to speed times frame time.
        //    float step = moveSpeed * Time.deltaTime;

        //    rb.velocity = Vector2.left * 0;
        //    // Move our position a step closer to the target.
        //    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, openSpot.position, 1);

        //    if (gameObject.transform.position == openSpot.position)
        //    {
        //        beginMove = false;
        //    }
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "despawner")
        {
            Destroy(gameObject);
        }

        if(col.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (col.tag == "hacker")
        {
            //if (Spaceship.currentspot < 6)
            //{
            //hackedreposition();
            //beginmove = true;
            //openspot = spaceship.nextopenspot.transform;

            //this.getComponent<isHacked>().enabled = true;
            //this.getcomponent<enemy2>().enabled = false;
            Spaceship.amountHacked++;
            GameObject go = Instantiate(hackedEnemy, new Vector3(transform.position.x + 7, transform.position.y, 0), Quaternion.identity);
                
                //hackedenemy.transform.parent = spaceship.instance.hackedspots[0];
            //}
        }
    }

    //void hackedReposition()
    //{
    //    enemyLerp.moveAlien(Spaceship.nextOpenSpot, this.gameObject);
    //    Spaceship.incrementOpenSpot();
    //}

}
