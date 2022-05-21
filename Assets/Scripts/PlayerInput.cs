using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void OnMove(InputValue value)
    {
        Vector2 rawInput = value.Get<Vector2>();       
        player.SetRawMoveInput(rawInput);
    }
}
