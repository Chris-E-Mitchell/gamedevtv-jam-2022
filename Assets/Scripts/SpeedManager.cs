using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] float gameSpeedIncrement = 0.1f;
    [SerializeField] float maxGameSpeed = 10f;
    [SerializeField] int secondsBeforeSpeedIncrease = 5;
    float gameSpeed = 1f;

    void Start()
    {
        StartCoroutine(IncreaseGameSpeed());
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

    IEnumerator IncreaseGameSpeed()
    {
        while(gameSpeed <= maxGameSpeed)
        {
            gameSpeed += gameSpeedIncrement;
            Debug.Log("Game Speed is now:" + gameSpeed);
            yield return new WaitForSecondsRealtime(secondsBeforeSpeedIncrease);
        }
    }

}
