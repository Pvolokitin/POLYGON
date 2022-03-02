using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollider: MonoBehaviour
{
    private GameManager gameManager;

    // Turret Collider

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)      // If the enemy hit the Turret, - died
    {
        if (collision.gameObject.CompareTag("target"))
        {
            Destroy(GameObject.Find("gun"));
            Destroy(GameObject.Find("wheel"));
            gameManager.isGameActive = false;
        }
    }
}
