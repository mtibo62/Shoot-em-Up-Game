using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headShooter : MonoBehaviour
{
    //gets gameobject for the enemybullet1
    public GameObject enemyBullet1Object;

    //gets gameobject for the enemybullet2
    public GameObject enemyBullet2Object;

   

    static public int vectorMove;

    static public bool headShoot;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBullet());
        headShoot = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void doShoot() { 
}
    //methods used to instantiate the boss bullet
     IEnumerator spawnBullet()
    {
        yield return new WaitForSeconds(5f);

        while (bossAlien.bossHealth > 50)
        {
            yield return new WaitForSeconds(1f);
        }

        while (bossAlien.bossHealth <= 50)
        {
            headShoot = true;

            enemyBullet1.speed = 80;
            enemyBullet2.speed = 80;

            yield return new WaitForSeconds(5f);

            for (int i = -30; i < 40; i++)
            {
                vectorMove = i;
                if (i <= -20 || (i > -15 && i <-5) || (i > 0 && i < 10 ) || (i > 15 && i < 25) || i > 30){ 
                
                Instantiate(enemyBullet1Object, transform.position, transform.rotation);
                yield return new WaitForSeconds(.08f);
                }

                else if( (i > -20 && i <= -15) || (i >= -5 && i < 0) || (i >= 10 && i <15) || (i>=25 && i < 30))
                {

                    Instantiate(enemyBullet2Object, transform.position, transform.rotation);
                    yield return new WaitForSeconds(.08f);
                }

            }
            
            headShoot = false;
            yield return new WaitForSeconds(20f);
        }

    }
}
