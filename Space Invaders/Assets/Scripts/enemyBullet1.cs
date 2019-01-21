using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet1 : MonoBehaviour
   
{
    private Rigidbody2D rb;

    public int speed = 30;

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

        if (col.tag == "Despawner")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            if(Spaceship.health > 0)
            {
                Spaceship.health -= 1;

                
            }
            else
            {
                DestroyObject(col.gameObject, 0.5f);
            }
            Destroy(gameObject);

            
        }
    }
  }
