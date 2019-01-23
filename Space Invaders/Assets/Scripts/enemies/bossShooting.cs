using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting : MonoBehaviour
{

    //gets gameobject for the enemybullet1
    public GameObject enemyBullet1Object;

    //gets gameobject for the enemybullet2
    public GameObject enemyBullet2Object;


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
        yield return new WaitForSeconds(5f);

        while (bossAlien.bossHealth > 50)
        {

            enemyBullet1.speed = 80;
            enemyBullet2.speed = 65;

            for (int i = 0; i < 8; i++)
            {
                Instantiate(enemyBullet2Object, transform.position, transform.rotation);
                yield return new WaitForSeconds(1f);
                if (i % 3 == 0)
                {
                    Instantiate(enemyBullet1Object, transform.position, transform.rotation);
                    yield return new WaitForSeconds(1f);
                }


            }

            for (int i = 0; i < 4; i++)
            {
                Instantiate(enemyBullet1Object, transform.position, transform.rotation);
                yield return new WaitForSeconds(.9f);

                Instantiate(enemyBullet1Object, transform.position, transform.rotation);
                yield return new WaitForSeconds(1f);


            }
        }



        while (bossAlien.bossHealth <= 50)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 1; i++)
            {
                if (!headShooter.headShoot)
                {
                    Instantiate(enemyBullet2Object, transform.position, transform.rotation);
                    yield return new WaitForSeconds(1f);
                    if (i % 3 == 0)
                    {
                        Instantiate(enemyBullet1Object, transform.position, transform.rotation);
                        yield return new WaitForSeconds(1f);
                    }

                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (!headShooter.headShoot)
                {
                    Instantiate(enemyBullet1Object, transform.position, transform.rotation);
                    yield return new WaitForSeconds(.8f);

                    Instantiate(enemyBullet1Object, transform.position, transform.rotation);
                    yield return new WaitForSeconds(.9f);
                }

            }
        }
    }
}
