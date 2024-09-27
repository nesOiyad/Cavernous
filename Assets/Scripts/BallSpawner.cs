using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BallSpawner : MonoBehaviour
{
    public GameObject enemyBall;
    private GameObject cloneBall;
    public Transform player;
    public float delayTimeBall = 3.0f;
    public bool canSpawn = false; 
    private bool before = false;
    private int numBalls;
    private int numBallsCheck;
    private float xRange = 6f;
    private float yRange = 6f;
    private Vector2 randomPosition;
    private bool ballIsCalled = false;
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (canSpawn != before)
        {
            StartCoroutine(SpawnBallCoroutine());
        } else {
            before = canSpawn;
        }
        if (canSpawn == true) 
        {
            GameObject[] ballsOnScreen = GameObject.FindGameObjectsWithTag("BallEnemy");
            numBallsCheck = ballsOnScreen.Length;
            if (numBallsCheck == 0)
            {
                if (ballIsCalled == false) 
                {
                    Invoke("SpawnBall", 3.0f);
                    ballIsCalled = true;
                }
            }
        }
    }
    IEnumerator SpawnBallCoroutine()
    {
        while (true) 
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("BallEnemy");
            numBalls = balls.Length;
            if (numBalls <= 2)
            {
                if(canSpawn)
                {
                    float xPosition = Random.Range(0-xRange, 0+xRange);
                    float yPosition = Random.Range(0-yRange, 0+yRange);
                    randomPosition = new Vector2(xPosition, yPosition);
                    cloneBall = Instantiate(enemyBall, randomPosition, Quaternion.identity);
                    cloneBall.GetComponent<AIDestinationSetter>().target = player;
                    yield return new WaitForSeconds(delayTimeBall);
                }
            } 
            yield return new WaitForSeconds(delayTimeBall);
        }
    }
    private void SpawnBall()
    {
        if(canSpawn)
        {
            float xPosition = Random.Range(0-xRange, 0+xRange);
            float yPosition = Random.Range(0-yRange, 0+yRange);
            randomPosition = new Vector2(xPosition, yPosition);
            cloneBall = Instantiate(enemyBall, randomPosition, Quaternion.identity);
            cloneBall.GetComponent<AIDestinationSetter>().target = player;
            ballIsCalled = false;
        }
    }
}
