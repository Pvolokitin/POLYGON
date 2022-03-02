using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 0;       // Speed bullet
    
    void Start()
    {

    }

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);      // bullet traectory
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("walls"))       // if hit the walls => destroy bullet 
        {
            Destroy(this.gameObject);
            Debug.Log("Задели стену");
        }

        if (other.gameObject.CompareTag("target"))      // if hit the target(enemys) => destroy target(enemy)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Debug.Log("Задели цель");
        }
    }
}
