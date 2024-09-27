using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float currentTime;
    private float timeLeft;
    void Update()
    {
        currentTime += Time.deltaTime;
        timeLeft = 360.0f - currentTime;
        int minutes = Mathf.FloorToInt(timeLeft/60);
        int seconds = Mathf.FloorToInt(timeLeft%60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
