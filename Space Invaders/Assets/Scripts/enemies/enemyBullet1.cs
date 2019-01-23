using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet1 : MonoBehaviour
{
    private Rigidbody2D rb;

    static public int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 65;

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.left * speed;

        
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = Vector2.left * speed;
        //if (headShooter.headShoot)
        //{
        //    rb.velocity = new Vector3(speed * -1, headShooter.vectorMove, 0);
        //}
        //else{
        //    rb.velocity = Vector2.left * speed;
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "despawner")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" )
        {
            
            Destroy(gameObject);
            if (Spaceship.health > 0 && !Spaceship.isHit)
            {
                
                Spaceship.health--;
                Debug.Log(Spaceship.health);
                //Spaceship.isHit = true;

            }
        }
    }

}
