using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedEnemy;      // Скорость врага

    private Rigidbody EnemyRb;

    private GameObject Player;
    private GameManager gameManager;
    

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        Player = GameObject.Find("wheel");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        speedEnemy = Random.Range(3.0f, 4.5f);      // Получаем рандомную скорость
    }

    
    void Update()
    {
        if (gameManager.isGameActive == true)       // Если игра активна, толкаем врага в сторону игрока
        {
            Vector3 lookDirection = (Player.transform.position - transform.position).normalized;
            EnemyRb.AddForce(lookDirection * speedEnemy);
        }
        
    }
}
