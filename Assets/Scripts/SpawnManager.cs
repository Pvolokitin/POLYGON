using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ������ �����
    [SerializeField] private GameObject prefabEnemy;
    
    // ����������� ��������� ����� �� ����
    private float minBord = 15, maxBord = 32;

    // ���������� ������
    [SerializeField] private int enemyCount;
    // ���������� ����
    [SerializeField] private int waveCount = 1;
    // �������� ��� �����
    public int _waveNumber = 0;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // ������� ���������� ������ �� ����
        if(enemyCount == 0)     // ���� ���������� ������ 0
        {
            gameManager.UpdateScore(++_waveNumber); // ����������� ����
            waveCount++;                    //  ����������� ���������� ������ ��� ���� �����
            SpawnEnemyWave(waveCount);      //  �������� ���������� ������ ��� �������� �����
        }
    }

    void SpawnEnemyWave(int enemyToSpawn)   // �������� ����� (waveCount ���������� �����)
    {
        for(int i = 0; i < enemyToSpawn; i++)       // ������� ����� �� ���������� ������ ���������� �� generatePosition
        {
            Instantiate(prefabEnemy, generatePosition(), prefabEnemy.transform.rotation);
        }
    }

    private Vector3 generatePosition()      // ��������� ��������� ������ �� ����
    {
        float PosX = Random.Range(-minBord, maxBord);
        float PosZ = Random.Range(-minBord, maxBord);
        Vector3 spawnPosition = new Vector3(PosX, 0, PosZ);
        return spawnPosition;
    }
}
