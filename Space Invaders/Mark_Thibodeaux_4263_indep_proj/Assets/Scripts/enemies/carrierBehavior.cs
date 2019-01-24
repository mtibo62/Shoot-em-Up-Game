using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrierBehavior : MonoBehaviour
{

     private int speed = 25;

    private Rigidbody2D rb;

    public GameObject enemyBullet1;

    public SpriteRenderer renderer;

    public int bulletDelay;

    int carrierHealth = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        renderer = GetComponent<SpriteRenderer>();

        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bullet")
        {
            StartCoroutine(blink());

            carrierHealth--;

            if(carrierHealth <= 0)
            {
                Destroy(gameObject);
                Spaceship.IncreaseTestUIScore();
            }

            Destroy(col.gameObject);
        }

        if (col.tag == "despawner")
        {
            Destroy(gameObject);
        }

        if(col.tag == "Player")
        {
            Spaceship.health--;
        }
    }

    IEnumerator blink()
    {
       

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);

        yield return new WaitForSeconds(.05f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);

    }
}
