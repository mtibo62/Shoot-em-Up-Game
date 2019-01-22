using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAlien : MonoBehaviour
{

    public int speed;

    private Rigidbody2D rb;



    public SpriteRenderer renderer;

    public int bulletDelay;

    int bossHealth = 150;

    public static bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;

        rb = GetComponent<Rigidbody2D>();

        renderer = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameObject.Find("enemySpawner").transform.position.x - 35, 
            GameObject.Find("enemySpawner").transform.position.y, 0), .1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            StartCoroutine(blink());

            bossHealth--;

            if (bossHealth <= 0)
            {
                Destroy(gameObject);
                Spaceship.IncreaseTestUIScore();
            }

            Destroy(col.gameObject);
        }

    }

    IEnumerator blink()
    {


        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);

        yield return new WaitForSeconds(.05f);

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);

    }
}
