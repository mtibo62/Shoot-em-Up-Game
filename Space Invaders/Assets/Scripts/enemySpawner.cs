using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float delay = 5f;
    public float blueDelay = 5f;

    public GameObject redEnemy;

    public GameObject blueEnemy;

    public GameObject redCarrier;

    public GameObject blueCarrier;

    public GameObject emptyEnemy;


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
        yield return new WaitForSeconds(delay);

        //first wave of carriers (player should run out of bullets to learn that theier is a limited number of bullets)




        while (Spaceship.score < 300)
        {
            int patternNum = Random.Range(1, 3);

            if (patternNum == 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector3 spawnPosition = new Vector3(0, 0, 0);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(blueEnemy, transform.position, spawnRotation);
                    yield return new WaitForSeconds(.5f);
                }
            }
            else if(patternNum == 2)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector3 spawnPosition = new Vector3(0, 0, 0);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(redEnemy, transform.position, spawnRotation);
                    yield return new WaitForSeconds(.5f);
                }
            }
            yield return new WaitForSeconds(2);
        }
    }







}
