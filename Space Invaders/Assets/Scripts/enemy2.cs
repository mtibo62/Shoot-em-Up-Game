using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    public GameObject enemyBullet2;

    public int bulletDelay;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.left * speed;


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > bulletDelay)
        {
            bulletDelay = bulletDelay + 3;
            Instantiate(enemyBullet2, transform.position, Quaternion.identity);
        }
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
    }
}
