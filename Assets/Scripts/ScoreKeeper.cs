using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int maxScore = 100;
    [SerializeField] Slider scoreSlider;

    int score;
    

    void Start()
    {
        scoreSlider.minValue = 0;
        scoreSlider.maxValue = maxScore;
        score = maxScore / 2;
        scoreSlider.value = score;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }

    public void AddScore(int value)
    {
        score += value;

        score = Mathf.Clamp(score, 0, maxScore);

        scoreSlider.value = score;
    }
}
