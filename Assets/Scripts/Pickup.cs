using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int pointsValue = 1;
    SpeedManager speedManager;
    Rigidbody2D myRigidBody;
    float moveSpeed = 1f;
    
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        speedManager = FindObjectOfType<SpeedManager>();
    }

    void Update()
    {
        myRigidBody.velocity = new(0f,-moveSpeed * speedManager.GetGameSpeed());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Road"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
