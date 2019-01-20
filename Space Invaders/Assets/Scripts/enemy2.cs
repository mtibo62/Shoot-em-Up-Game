using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    public GameObject enemyBullet2;

    private int bulletDelay = 6;



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
             Instantiate(enemyBullet2, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
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

        if(col.tag == "Player")
        {
            hackedReposition();
        }
    }

    void hackedReposition()
    {

    }
}
