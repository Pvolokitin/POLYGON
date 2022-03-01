using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject wheel;
    private GameManager gameManager;

    // Статическая позиция башни
    [SerializeField] private Vector3 _staticPosition = new Vector3(-0.2f, -1f, 0);
    // Скорость поворота башни
    [SerializeField] private float _speedRotation = 0;
    // Пуля
    [SerializeField] private GameObject prefabBullet;
    // Дуло
    [SerializeField] private GameObject turret;

    // Положение прицела
    [SerializeField] private Transform crosshair;

    // Эффект выстрела
    [SerializeField] private ParticleSystem turretParticle;

    // Период между выстрелами
    [SerializeField] float _attackPeriod;
                     private float _timer;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = crosshair.transform.position - transform.position; // Находим координаты курсора для поворота
        Quaternion rotation = Quaternion.LookRotation(direction);   // заставляем башне смотреть в сторону курсора
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime); // скорость поворота за курсором
        transform.position = wheel.transform.position + _staticPosition;    // двигаемся вместе с колесом

        // Выстрел с паузой (пауза настраивается в Инспекторе)
        _timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _timer > _attackPeriod)
        {
           _timer = 0;
           turretParticle.Play();
           ShootThem();                
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))  // Если задели врага = смерть
        {
            Destroy(GameObject.Find("wheel"));
            Destroy(this.gameObject);
            gameManager.isGameActive = false;
        }
    }

    void ShootThem()    // Выстрел префаба Пуля
    {
        Vector3 prefPos = new Vector3(turret.transform.position.x, turret.transform.position.y, turret.transform.position.z);   // получаем координаты дула по XYZ
        Instantiate(prefabBullet, prefPos, transform.rotation); // используем эти координаты для местополжения выстрела из пушки
        
    }
}
