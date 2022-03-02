using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelController : MonoBehaviour
{
    private float speed = 45.0f;            // speed ball
    private float forceForSlide = 10.0f;    // push force

    private GameManager gameManager;
    private Rigidbody wheelRb;
    

    private void Start()
    {
        wheelRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

 
    void Update()       // ball controll
    {
        float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");
        DodgeWheel();

        wheelRb.AddTorque(Vector3.forward * speed * VerticalInput);
        wheelRb.AddTorque(Vector3.right * speed * HorizontalInput);
        
        Debug.Log(speed);
    }

    void DodgeWheel() // Dash in the direction of the ball 
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                wheelRb.AddForce(Vector3.forward * forceForSlide, ForceMode.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                wheelRb.AddForce(-Vector3.right * forceForSlide, ForceMode.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                wheelRb.AddForce(Vector3.right * forceForSlide, ForceMode.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                wheelRb.AddForce(-Vector3.forward * forceForSlide, ForceMode.Impulse);
            }
        }
    } 

    private void OnCollisionEnter(Collision collision)  // If you hit the enemy, - died
    {
        if (collision.gameObject.CompareTag("target"))
        {
            Destroy(GameObject.Find("gun"));
            Destroy(this.gameObject);
            gameManager.isGameActive = false;
        }
    }

}
