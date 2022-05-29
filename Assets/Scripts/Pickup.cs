using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int pointsValue = 5;
    [SerializeField] Sprite splatSprite;
    [SerializeField] AudioClip splatSFX;
    [SerializeField] float splatVolume = 0.1f;
    SpeedManager speedManager;
    Rigidbody2D myRigidBody;
    SpriteRenderer spriteRenderer;
    ScoreKeeper scoreKeeper;
    float moveSpeed = 1f;
    bool isHit;
    
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        speedManager = FindObjectOfType<SpeedManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
        if (collision.CompareTag("Player") && !isHit)
        {
            if (gameObject.CompareTag("Addition"))
            {
                scoreKeeper.AddScore(pointsValue);
            }
            else if (gameObject.CompareTag("Reduction"))
            {
                scoreKeeper.AddScore(-pointsValue);
            }

            //Destroy(gameObject);
            isHit = true;
            spriteRenderer.sprite = splatSprite;
            AudioSource.PlayClipAtPoint(splatSFX, Camera.main.transform.position, splatVolume);
        }
    }
}
