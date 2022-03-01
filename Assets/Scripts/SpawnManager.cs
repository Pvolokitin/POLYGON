using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Префаб врага
    [SerializeField] private GameObject prefabEnemy;
    
    // Ограничения появления врага на поле
    private float minBord = 15, maxBord = 32;

    // Количество врагов
    [SerializeField] private int enemyCount;
    // Количество волн
    [SerializeField] private int waveCount = 1;
    // Значения для счета
    public int _waveNumber = 0;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Находим количество врагов на поле
        if(enemyCount == 0)     // Если количество врагов 0
        {
            gameManager.UpdateScore(++_waveNumber); // Увеличиваем счет
            waveCount++;                    //  увеличиваем количество врагов для след волны
            SpawnEnemyWave(waveCount);      //  передаем количество врагов для создания волны
        }
    }

    void SpawnEnemyWave(int enemyToSpawn)   // Создание волны (waveCount передается здесь)
    {
        for(int i = 0; i < enemyToSpawn; i++)       // Создаем врага от количества врагов переданных по generatePosition
        {
            Instantiate(prefabEnemy, generatePosition(), prefabEnemy.transform.rotation);
        }
    }

    private Vector3 generatePosition()      // Рандомное появления врагов по полю
    {
        float PosX = Random.Range(-minBord, maxBord);
        float PosZ = Random.Range(-minBord, maxBord);
        Vector3 spawnPosition = new Vector3(PosX, 0, PosZ);
        return spawnPosition;
    }
}
