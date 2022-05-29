using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    //This offset adjusts the speed of the scroll to match the velocity of the pickups
    //There should be some way to calculate this correctly, but is currently set manually
    //Road is 2.75f
    //Background is 30f
    //Clouds are 15f
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
        yOffset += (speedManager.GetGameSpeed() / offsetAdjustment) * Time.deltaTime;
        spriteRenderer.material.mainTextureOffset = new(0f, yOffset);
    }
}