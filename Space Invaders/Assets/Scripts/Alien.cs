using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public float speed = 10;

    public Rigidbody2D rigidBody;

    public Sprite startImage;

    public Sprite altImage;

    private SpriteRenderer spriteRenderer;

    public float secBeforeSpriteChange = 0.5f;

    public GameObject alienBullet;

    public float minFireRateTime = 1.0f;

    public float maxFireRateTime = 3.0f;

    public float baseFireWaitTime = 3.0f;

    public Sprite explodedShipImage;


    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(1, 0) * speed;

        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(ChangeAlienSprite());

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);



    }

    //Turn in opposiite direction
    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    //Move down after hitting wall
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "LWall")
        {
            Turn(1);
            MoveDown();
        }

        if (col.gameObject.name == "RWall")
        {
            Turn(-1);
            MoveDown();
        }

        if (col.gameObject.tag == "Bullet")
        {
            Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.alienDies);
            Destroy(gameObject);
        }
    }


    public IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            if(spriteRenderer.sprite == startImage)
            {
                spriteRenderer.sprite = altImage;
                //Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.alienBuzz1);
            }
            else
            {
                spriteRenderer.sprite = startImage;
                Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.alienBuzz2);
            }

            yield return new WaitForSeconds(secBeforeSpriteChange);
        }
    }


    void FixedUpdate()
    {
        if(Time.time > baseFireWaitTime)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.shipExplosion);

            col.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            Destroy(gameObject);
            DestroyObject(col.gameObject, 0.5f);
        }
    }
}
