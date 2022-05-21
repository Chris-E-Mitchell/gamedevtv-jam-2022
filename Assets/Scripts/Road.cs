using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] float offsetAdjustment = 2.75f;

    SpeedManager speedManager;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        speedManager = FindObjectOfType<SpeedManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yOffset = spriteRenderer.material.mainTextureOffset.y;
        yOffset += (speedManager.GetGameSpeed()/offsetAdjustment) * Time.deltaTime;
        spriteRenderer.material.mainTextureOffset = new(0f, yOffset);
    }
}
