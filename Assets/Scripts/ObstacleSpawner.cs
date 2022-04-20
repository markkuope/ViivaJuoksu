using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    Vector3 spawnPos;
    public float spawnRate;
    void Start()
    {
        // alussa spawnPos on sama kuin ObstacleSpawner paikka
        spawnPos = transform.position;

        //Spawn();

        StartCoroutine("SpawnObstacles");
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            GameManager.gameManager.UpdateScore();

            yield return new WaitForSeconds(spawnRate);
            
        }
    }



    void Spawn()
    {
        int randObstacle = Random.Range(0, obstacles.Length);
        int randomSpot = Random.Range(0, 2); // 0 = top, 1 = bottom

        spawnPos = transform.position;

        if (randomSpot < 1)
        {
            // spawn at top
            //spawnataan (synnytetään) satunnainen este paikkaan spawnPos, rotaatiolla transform.rotation
            Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
        }
        else
        {
            // spawn at bottom            
            spawnPos.y = -transform.position.y;
            //spawnataan (synnytetään) satunnainen este paikkaan spawnPos, rotaatiolla transform.rotation
            Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
        }

    }

}
