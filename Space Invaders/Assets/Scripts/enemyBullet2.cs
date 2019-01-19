using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet2 : MonoBehaviour
{
    private Rigidbody2D rb;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "despawner")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            if (Spaceship.health > 0)
            {
                Spaceship.health -= 1;


            }

            Destroy(gameObject);

            if (Spaceship.health <= 0)
            {
                DestroyObject(col.gameObject, 0.5f);
            }
        }

        if (col.gameObject.tag == "Shield")
        {
            Spaceship.numBullets++;
            Spaceship.IncreaseBulletAmountUI();

           

            Destroy(gameObject);
        }


    }

    
}
