using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Enemy Prefab (target)
    [SerializeField] private GameObject prefabEnemy;

    // Field limit values
    private float minBord = 15, maxBord = 32;

    // Enemy Count
    [SerializeField] private int enemyCount;
    // Wave Count
    [SerializeField] private int waveCount = 1;

    // for score
    public int _waveNumber = 0;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // find length enemy count in game
        if(enemyCount == 0)
        {
            gameManager.UpdateScore(++_waveNumber); // update score
            waveCount++;                    //  Increasing the number of enemies for the next wave
            SpawnEnemyWave(waveCount);      //  pass the number of enemies to create a wave
        }
    }

    void SpawnEnemyWave(int enemyToSpawn)   // wave Create (waveCount)
    {
        for(int i = 0; i < enemyToSpawn; i++)       // create enemy with generatePosition position
        {
            Instantiate(prefabEnemy, generatePosition(), prefabEnemy.transform.rotation);
        }
    }

    private Vector3 generatePosition()      // Enemy spawn random on playground
    {
        float PosX = Random.Range(-minBord, maxBord);
        float PosZ = Random.Range(-minBord, maxBord);
        Vector3 spawnPosition = new Vector3(PosX, 0, PosZ);
        return spawnPosition;
    }
}
