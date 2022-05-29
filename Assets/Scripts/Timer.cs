using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float levelTime = 20f;
    float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        UpdateTimer();
    }

    public float GetTimerValue()
    {
        return timer;
    }

    public float GetTimerPercentage()
    {       
        return Mathf.Clamp(timer / levelTime, 0f, 1f);
    }

    public bool IsTimerExpired()
    {
        bool timerExpired = false;

        if(timer >= levelTime)
        {
            timerExpired = true;
        }

        return timerExpired;
    }

    void UpdateTimer()
    {
        timer += Time.deltaTime;
    }
}
