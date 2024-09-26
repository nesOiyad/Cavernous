using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWonPlayerScreen : MonoBehaviour
{
    public TMP_Text wonText;
    private  int scoreText;
    void Start() {
        Time.timeScale = 1.0f;
    }
    public void SetScoreWon(int score) 
    {
        scoreText = score;
        Invoke("SetScoreDelay", 1.2f);
    }
    private void SetScoreDelay() 
    {
        gameObject.SetActive(true);
        wonText.text = "SCORE:" + scoreText.ToString();
    }
}
