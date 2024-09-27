using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPlayerScreen : MonoBehaviour
{
    public TMP_Text pointText;
    private  int scoreText;
    void Start() {
        Time.timeScale = 1.0f;
    }
    public void SetScore(int score) 
    {
        scoreText = score;
        Invoke("SetScoreDelay", 1.0f);
    }
    private void SetScoreDelay() 
    {
        gameObject.SetActive(true);
        pointText.text = "SCORE:" + scoreText.ToString();
    }
}
