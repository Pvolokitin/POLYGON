using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _staticPosition = new Vector3(4.82f, 4.05f, 0);    // статическая позиция камеры

    // Ограничение поля
    private float posZ = 15.0f;
    private float posX = 25.0f;

    // объект пушка
    public GameObject Gun;     


    private GameManager gameManager;


    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void FixedUpdate()
    {
        if(gameManager.isGameActive == true)        // если игра активна, следуем за пушкой + ограничения поля
        {
            transform.position = Gun.transform.position + _staticPosition;
            // Ограничения по X
            if(transform.position.x > posX)
            {
                transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -posX)
            {
                transform.position = new Vector3(-posX, transform.position.y, transform.position.z);
            }
            // ограничения по Z
            if (transform.position.z > posZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, posZ);
            }
            else if (transform.position.z < -posZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -posZ);
            }
        }
        
    }

}
