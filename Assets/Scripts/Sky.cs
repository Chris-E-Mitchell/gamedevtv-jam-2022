using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    SpriteRenderer spriteRenderer;
    int maxScore;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        maxScore = scoreKeeper.GetMaxScore();
    }

    void Update()
    {
        int score = scoreKeeper.GetScore();
        float transparency = (float)score / maxScore;
        Color currentColor = spriteRenderer.color;

        spriteRenderer.color = new(currentColor.r, currentColor.g, currentColor.b, transparency);

    }
}
