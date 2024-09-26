using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplayText;
    public GameObject player;
    void Update()
    {
        int number = player.GetComponent<PlayerMovement>().score;
        scoreDisplayText.text = "SCORE:" + number.ToString();
    }
}
