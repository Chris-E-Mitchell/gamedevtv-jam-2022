using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int maxScore = 100;
    [SerializeField] float scoreThreshold = 0.1f;
    [SerializeField] Slider scoreSlider;
    [SerializeField] Timer timer;

    SceneLoader sceneLoader;
    int score;

    void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void Start()
    {
        scoreSlider.minValue = 0;
        scoreSlider.maxValue = maxScore;
        score = maxScore / 2;
        scoreSlider.value = score;
    }

    void Update()
    {
        if (timer.IsTimerExpired())
        {
            CheckEnding();
        }
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

    void CheckEnding()
    {
        float currentThreshold = (float)score / maxScore;

        if(currentThreshold <= scoreThreshold)
        {
            sceneLoader.LoadHellScene();
        }
        else if(currentThreshold >= (1  - scoreThreshold))
        {
            sceneLoader.LoadHeavenScene();
        }
        else
        {
            sceneLoader.LoadPurgatoryScene();
        }
    }
}
