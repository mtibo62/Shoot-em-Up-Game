using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float delay = 4f;
    public float blueDelay = 5f;

    public GameObject carrierPattern1;
    public GameObject carrierPattern2;
    public GameObject carrierPattern3;
    public GameObject carrierPattern4;
    public GameObject carrierPattern5;

    public GameObject enemyPattern1;
    public GameObject enemyPattern2;
    public GameObject enemyPattern3;
    public GameObject enemyPattern4;

    public GameObject bossAlienObject;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnWaves()
    {



        //first wave of carriers (player should run out of bullets to learn that theier is a limited number of bullets)
        GameObject.Instantiate(carrierPattern1, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        GameObject.Instantiate(carrierPattern2, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4);
        //GameObject.Instantiate(carrierPattern3, transform.position, Quaternion.identity);
        //yield return new WaitForSeconds(4);
        GameObject.Instantiate(carrierPattern4, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        GameObject.Instantiate(carrierPattern5, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(6);



        while (Spaceship.score < 600)
        {
            int patternNum = Random.Range(1, 4);

            Debug.Log(patternNum);

            if (patternNum == 1)
            {
                for (int i = 0; i < 1; i++)
                {

                    enemy2.speed = 25;
                    enemyBullet2.speed = 8;


                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject.Instantiate(enemyPattern4, new Vector3(transform.position.x, Random.Range(-25, 16), 0), spawnRotation);
                    yield return new WaitForSeconds(4f);
                }

            }
            if (patternNum == 2)
            {

                enemy1.speed = 30;
                enemyBullet1.speed = 80;
                enemy2.speed = 25;
                enemyBullet2.speed = 60;


                Quaternion spawnRotation = Quaternion.identity;
                GameObject.Instantiate(enemyPattern2, new Vector3(transform.position.x, Random.Range(-15, 10), 0), spawnRotation);
                yield return new WaitForSeconds(6f);

            }
            if (patternNum == 3)
            {

                enemy1.speed = 30;
                enemyBullet1.speed = 80;
                enemy2.speed = 25;
                enemyBullet2.speed = 65;


                Quaternion spawnRotation = Quaternion.identity;
                GameObject.Instantiate(enemyPattern3, transform.position, spawnRotation);
                yield return new WaitForSeconds(7f);

            }
            if (patternNum == 4)
            {
                for (int i = 0; i < 3; i++)
                {

                    enemy2.speed = 25;
                    enemyBullet2.speed = 8;


                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject.Instantiate(enemyPattern1, new Vector3(transform.position.x, Random.Range(-25, 16), 0), spawnRotation);
                    yield return new WaitForSeconds(2);
                }


                yield return new WaitForSeconds(5);
            }

        }

        
        yield return new WaitForSeconds(delay);
        GameObject.Instantiate(bossAlienObject, transform.position, Quaternion.identity);


        /////////BOSS FIGHT///////////
        while (bossAlien.bossHealth > 50)
        {
            yield return new WaitForSeconds(1);
        }
        while (bossAlien.bossHealth <= 50 && !headShooter.headShoot)
        {

             enemy2.speed = 25;
             enemyBullet2.speed = 8;


              Quaternion spawnRotation = Quaternion.identity;
              GameObject.Instantiate(enemyPattern1, new Vector3(transform.position.x, Random.Range(-25, 16), 0), spawnRotation);
              yield return new WaitForSeconds(8);
        }
        
    }
    
}
