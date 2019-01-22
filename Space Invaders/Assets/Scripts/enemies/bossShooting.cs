using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting : MonoBehaviour
{

    //gets gameobject for the enemybullet1
    public GameObject enemyBullet1;

    //gets gameobject for the enemybullet2
    public GameObject enemyBullet2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBullet());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //methods used to instantiate the boss bullet
    IEnumerator spawnBullet()
    {
        yield return new WaitForSeconds(3f);

        while (bossAlien.isAlive == true)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemyBullet2, transform.position, transform.rotation);
                yield return new WaitForSeconds(1f);
                if(i % 3 == 0)
                {
                    Instantiate(enemyBullet1, transform.position, transform.rotation);
                    yield return new WaitForSeconds(1f);
                }


            }

            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemyBullet1, transform.position, transform.rotation);
                yield return new WaitForSeconds(.8f);

                Instantiate(enemyBullet1, transform.position, transform.rotation);
                yield return new WaitForSeconds(.9f);


            }
        }
    }
}
