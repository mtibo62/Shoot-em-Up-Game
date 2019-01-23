using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject ship;

    Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ship = GameObject.Find("Spaceship");

        //offset = Vector3(3, 0, 0);
    }

    void Update()
    {


        if (GameObject.Find("Spaceship") != null)
        {
            transform.position = ship.transform.position;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetButtonUp("Fire3"))
        {
            //Spaceship.isButtonPressed = false;
            Destroy(gameObject);
        }
    }
}
