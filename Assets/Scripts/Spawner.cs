using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Spawner : MonoBehaviour
{
    public GameObject enemyBat;
    public GameObject enemyGhost;
    private GameObject cloneBat;
    private GameObject cloneGhost;
    public Transform player;
    private int numBats;
    private int numGhosts;
    private int numBatsCheck;
    private int numGhostsCheck;
    public float delayTimeBatGhost = 2.0f;
    public bool canSpawn = false; 
    private float xRange = 11f;
    private float yRange = 5f;
    private Vector2 randomBatPosition;
    private Vector2 randomGhostPosition;
    private bool ghostIsCalled = false;
    private bool batIsCalled = false;
    void Start()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(SpawnBatCoroutine());
        StartCoroutine(SpawnGhostCoroutine());
    }
    void Update()
    {
        GameObject[] batsOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
        numBatsCheck = batsOnScreen.Length;
        GameObject[] ghostsOnScreen = GameObject.FindGameObjectsWithTag("Ghost");
        numGhostsCheck = ghostsOnScreen.Length;
        if (numBatsCheck == 0)
        {
           if(batIsCalled == false) 
           {
                Invoke("SpawnBat", 2.0f);
                batIsCalled = true;
           }
        }
        if (numGhostsCheck == 0)
        {
            if (ghostIsCalled == false) 
            {
                Invoke("SpawnGhost", 2.0f);
                ghostIsCalled = true;
            }
        }
    }
    IEnumerator SpawnBatCoroutine()
    {
        while (true) 
        {
            GameObject[] bats = GameObject.FindGameObjectsWithTag("Enemy");
            numBats = bats.Length;
            if (numBats <= 4)
            {
                if(canSpawn)
                {
                    float xPosition = UnityEngine.Random.Range(0-xRange, 0+xRange);
                    float yPosition = UnityEngine.Random.Range(0-yRange, 0+yRange);
                    randomBatPosition = new Vector2(xPosition, yPosition);
                    cloneBat = Instantiate(enemyBat, randomBatPosition, Quaternion.identity);
                    cloneBat.GetComponent<AIDestinationSetter>().target = player;
                    yield return new WaitForSeconds(delayTimeBatGhost);
                }
            }
            yield return new WaitForSecondsRealtime(delayTimeBatGhost); 
        }
    }
    IEnumerator SpawnGhostCoroutine()
    {
        while (true)
        {
            GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
            numGhosts = ghosts.Length;
            if (numGhosts <= 4)
            {
                if(canSpawn)
                {
                    float xPosition = UnityEngine.Random.Range(0-xRange, 0+xRange);
                    float yPosition = UnityEngine.Random.Range(0-yRange, 0+yRange);
                    randomGhostPosition = new Vector2(xPosition, yPosition); 
                    cloneGhost = Instantiate(enemyGhost, randomGhostPosition, Quaternion.identity);
                    cloneGhost.GetComponent<AIDestinationSetter>().target = player;
                    yield return new WaitForSecondsRealtime(delayTimeBatGhost);
                }
            }
            yield return new WaitForSecondsRealtime(delayTimeBatGhost);
        }
    }
    private void SpawnBat()
    {
        if(canSpawn)
        {
            float xPosition = UnityEngine.Random.Range(0-xRange, 0+xRange);
            float yPosition = UnityEngine.Random.Range(0-yRange, 0+yRange);
            randomBatPosition = new Vector2(xPosition, yPosition);
            cloneBat = Instantiate(enemyBat, randomBatPosition, Quaternion.identity);
            cloneBat.GetComponent<AIDestinationSetter>().target = player;
            batIsCalled = false;
        }
    }
    private void SpawnGhost()
    {
        if(canSpawn)
        {
            float xPosition = UnityEngine.Random.Range(0-xRange, 0+xRange);
            float yPosition = UnityEngine.Random.Range(0-yRange, 0+yRange);
            randomGhostPosition = new Vector2(xPosition, yPosition); 
            cloneGhost = Instantiate(enemyGhost, randomGhostPosition, Quaternion.identity);
            cloneGhost.GetComponent<AIDestinationSetter>().target = player;
            ghostIsCalled = false;
        }
    }
}
