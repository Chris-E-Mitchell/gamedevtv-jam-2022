using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minEnginePitch = 1.5f;
    [SerializeField] float maxEnginePitch = 2.5f;

    SpeedManager speedManager;
    Rigidbody2D myRigidBody;
    AudioSource myAudioSource;
    Vector2 rawMoveInput;
    float roadEdgeXPosition = 1.8f;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        speedManager = FindObjectOfType<SpeedManager>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AdjustEnginePitch();
    }

    public void SetRawMoveInput(Vector2 vector)
    {
        rawMoveInput = vector;
    }

    void Move()
    {
        // Note here that rawInput.x will be less if player input is pusing a y direction as well, consider for future improvement
        float xVelocity = rawMoveInput.x * moveSpeed;

        if ((xVelocity < 0 && transform.position.x <= -roadEdgeXPosition) || (xVelocity > 0 && transform.position.x >= roadEdgeXPosition))
        {
            myRigidBody.velocity = Vector2.zero;
        }
        else 
        {
            myRigidBody.velocity = new(xVelocity, 0f); 
        }
    }

    void AdjustEnginePitch()
    {
        float gameSpeedPercent = speedManager.GetGameSpeed() / speedManager.GetMaxGameSpeed();
        float newPitch = minEnginePitch + ((maxEnginePitch - minEnginePitch) * gameSpeedPercent);

        myAudioSource.pitch = newPitch;
    }
}
