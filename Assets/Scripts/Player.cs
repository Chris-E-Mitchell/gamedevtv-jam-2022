using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D myRigidBody;
    Vector2 rawMoveInput;
    float roadEdgeXPosition = 1.8f;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
}
