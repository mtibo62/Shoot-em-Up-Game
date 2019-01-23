using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hackerMove : MonoBehaviour
{
    public float speed = 100;

    private Rigidbody2D rigidbody;

    public SpriteRenderer spriteRenderer;

    public Sprite startSprite;

    public Sprite secondSprite;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rigidbody.velocity = Vector2.right * speed;

        StartCoroutine(hackAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.tag == "Alien")
        {
            //Soundmanager.Instance.PlayOneShot(Soundmanager.Instance.alienDies);

            

            //col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

            Destroy(gameObject);

       


        }

        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }

    public IEnumerator hackAnimation()
    {
        while (gameObject != null)
        {
            if ((spriteRenderer.sprite == startSprite))
            {
                spriteRenderer.sprite = secondSprite;
                yield return new WaitForSeconds(.15f);
            }
            else
            {
                spriteRenderer.sprite = startSprite;
                yield return new WaitForSeconds(.15f);
            }
        }
    }
}
