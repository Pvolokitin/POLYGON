using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject wheel;
    private GameManager gameManager;

    // Static Gun position 
    [SerializeField] private Vector3 _staticPosition = new Vector3(-0.2f, -1f, 0);
    // Speed rotate of Gun
    [SerializeField] private float _speedRotation = 0;
    // Bullet
    [SerializeField] private GameObject prefabBullet;
    // Turret
    [SerializeField] private GameObject turret;

    // crosshair position
    [SerializeField] private Transform crosshair;

    // particle of shot
    [SerializeField] private ParticleSystem turretParticle;

    // period between shots
    [SerializeField] float _attackPeriod;
                     private float _timer;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        Vector3 direction = crosshair.transform.position - transform.position; // find crosshair position
        Quaternion rotation = Quaternion.LookRotation(direction);   // rotate Gun into crosshair
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime); // The speed of rotation of the tower towards the sight
        transform.position = wheel.transform.position + _staticPosition;    // moving with the wheel

        // Shot with period (period setting in Inspector)
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
        if (collision.gameObject.CompareTag("target"))  // if hit the enemy, - died
        {
            Destroy(GameObject.Find("wheel"));
            Destroy(this.gameObject);
            gameManager.isGameActive = false;
        }
    }

    void ShootThem()    // create prefab Bullet
    {
        Vector3 prefPos = new Vector3(turret.transform.position.x, turret.transform.position.y, turret.transform.position.z);   // find turret position on XYZ
        Instantiate(prefabBullet, prefPos, transform.rotation); // use these coordinates for the location of the Turret shot

    }
}
