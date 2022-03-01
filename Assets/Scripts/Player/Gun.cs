using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject wheel;
    private GameManager gameManager;

    // ����������� ������� �����
    [SerializeField] private Vector3 _staticPosition = new Vector3(-0.2f, -1f, 0);
    // �������� �������� �����
    [SerializeField] private float _speedRotation = 0;
    // ����
    [SerializeField] private GameObject prefabBullet;
    // ����
    [SerializeField] private GameObject turret;

    // ��������� �������
    [SerializeField] private Transform crosshair;

    // ������ ��������
    [SerializeField] private ParticleSystem turretParticle;

    // ������ ����� ����������
    [SerializeField] float _attackPeriod;
                     private float _timer;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = crosshair.transform.position - transform.position; // ������� ���������� ������� ��� ��������
        Quaternion rotation = Quaternion.LookRotation(direction);   // ���������� ����� �������� � ������� �������
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime); // �������� �������� �� ��������
        transform.position = wheel.transform.position + _staticPosition;    // ��������� ������ � �������

        // ������� � ������ (����� ������������� � ����������)
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
        if (collision.gameObject.CompareTag("target"))  // ���� ������ ����� = ������
        {
            Destroy(GameObject.Find("wheel"));
            Destroy(this.gameObject);
            gameManager.isGameActive = false;
        }
    }

    void ShootThem()    // ������� ������� ����
    {
        Vector3 prefPos = new Vector3(turret.transform.position.x, turret.transform.position.y, turret.transform.position.z);   // �������� ���������� ���� �� XYZ
        Instantiate(prefabBullet, prefPos, transform.rotation); // ���������� ��� ���������� ��� ������������� �������� �� �����
        
    }
}
