using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Buffers;

public class SpawnerSnake : MonoBehaviour
{
    public GameObject enemySnake;
    private GameObject cloneSnake;
    public Transform pointA;
    public Transform pointB;
    public float delayTimeSnake = 3.0f;
    public bool canSpawn = false; 
    private bool before = false;
    private int numSnakes;
    private int numSnakesCheck;
    private Vector2 randomPosition;
    private bool snakeIsCalled = false;
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (before == canSpawn)
        {
            before = canSpawn;
        } else {
            StartCoroutine(SpawnSnakeCoroutine());
            before = canSpawn;
        }
        if (canSpawn == true)
        {
            GameObject[] snakesOnScreen = GameObject.FindGameObjectsWithTag("Snake");
            numSnakesCheck = snakesOnScreen.Length;
            if (numSnakesCheck == 0)
            {
                if (snakeIsCalled == false) 
                {
                    Invoke("SpawnSnake", 2.0f);
                    snakeIsCalled = true;
                }
            }
        }
    }
    IEnumerator SpawnSnakeCoroutine()
    {
        while (true) 
        {
            GameObject[] snakes = GameObject.FindGameObjectsWithTag("Snake");
            numSnakes = snakes.Length;
            if (numSnakes <= 2)
            {
                if(canSpawn)
                {
                    float xPosition = UnityEngine.Random.Range(pointA.position.x, pointB.position.x);
                    randomPosition = new Vector2(xPosition, transform.position.y);
                    cloneSnake = Instantiate(enemySnake, randomPosition, Quaternion.identity);
                    cloneSnake.GetComponent<Snakegfx>().startPoint = pointA;
                    cloneSnake.GetComponent<Snakegfx>().endPoint = pointB;
                    yield return new WaitForSecondsRealtime(delayTimeSnake);
                }
            }
            yield return new WaitForSecondsRealtime(delayTimeSnake);
        }
    }
    private void SpawnSnake()
    {
        if(canSpawn)
        {
            float xPosition = UnityEngine.Random.Range(pointA.position.x, pointB.position.x);
            randomPosition = new Vector2(xPosition, transform.position.y);
            cloneSnake = Instantiate(enemySnake, randomPosition, Quaternion.identity);
            cloneSnake.GetComponent<Snakegfx>().startPoint = pointA;
            cloneSnake.GetComponent<Snakegfx>().endPoint = pointB;
            snakeIsCalled = false;
        }
    }
}