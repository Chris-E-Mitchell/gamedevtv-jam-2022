using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    Timer timer;
    Image image;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        image = GetComponent<Image>();
    }

    void Start()
    {
        image.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = 1 - timer.GetTimerPercentage();
    }
}
