using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedEnemy;      // �������� �����

    private Rigidbody EnemyRb;

    private GameObject Player;
    private GameManager gameManager;
    

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        Player = GameObject.Find("wheel");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        speedEnemy = Random.Range(3.0f, 4.5f);      // �������� ��������� ��������
    }

    
    void Update()
    {
        if (gameManager.isGameActive == true)       // ���� ���� �������, ������� ����� � ������� ������
        {
            Vector3 lookDirection = (Player.transform.position - transform.position).normalized;
            EnemyRb.AddForce(lookDirection * speedEnemy);
        }
        
    }
}
