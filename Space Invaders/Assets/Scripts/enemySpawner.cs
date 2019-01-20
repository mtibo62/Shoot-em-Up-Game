using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float delay = 5f;
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
    public GameObject enemyPattern5;
    public GameObject enemyPattern6;




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
        GameObject.Instantiate(carrierPattern1, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        GameObject.Instantiate(carrierPattern2, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(10);
        GameObject.Instantiate(carrierPattern3, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(10);
        GameObject.Instantiate(carrierPattern4, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        GameObject.Instantiate(carrierPattern5, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(7);



        while (Spaceship.score < 300 )
        {
            int patternNum = Random.Range(1, 4);

            if (patternNum == 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector3 spawnPosition = new Vector3(0, 0, 0);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject.Instantiate(enemyPattern1, transform.position, spawnRotation);
                    //yield return new WaitForSeconds(4f);
                }
            }
            else if(patternNum == 2)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector3 spawnPosition = new Vector3(0, 0, 0);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject.Instantiate(enemyPattern2, transform.position, spawnRotation);
                    //yield return new WaitForSeconds(4f);
                }
            }
            else if (patternNum == 3)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector3 spawnPosition = new Vector3(0, 0, 0);
                    Quaternion spawnRotation = Quaternion.identity;
                    GameObject.Instantiate(enemyPattern3, transform.position, spawnRotation);
                    //yield return new WaitForSeconds(4f);
                }
            }
            yield return new WaitForSeconds(8);
        }
    }







}
