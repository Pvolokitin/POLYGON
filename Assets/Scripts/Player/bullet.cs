using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("walls"))
        {
            Destroy(this.gameObject);
            Debug.Log("Задели стену");
        }

        if (other.gameObject.CompareTag("target"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Debug.Log("Задели цель");
        }
    }
}
