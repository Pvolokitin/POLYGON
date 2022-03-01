using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollider: MonoBehaviour
{
    private GameManager gameManager;

    // коллайдер на пушку

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)      // ≈сли враг задел пушку = смерть
    {
        if (collision.gameObject.CompareTag("target"))
        {
            Destroy(GameObject.Find("gun"));
            Destroy(GameObject.Find("wheel"));
            gameManager.isGameActive = false;
        }
    }
}
