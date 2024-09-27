using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnerEye : MonoBehaviour
{
    public GameObject enemyEye;
    private GameObject cloneEye;
    private GameObject[] enemies;
    public Transform player;
    public float delayTimeEye = 1.0f;
    public bool canSpawn = false; 
    private bool before = false;
    private int numEyes;
    private int numEyesCheck;
    private float xRange = 6f;
    private float yRange = 3f;
    private Vector2 randomPosition;
    private bool eyeIsCalled = false;
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (canSpawn == before)
        {
            before = canSpawn;
        } else {
            StartCoroutine(SpawnEyeCoroutine());
            before = canSpawn;
        }
        if (canSpawn == true) 
        {
            GameObject[] eyesOnScreen = GameObject.FindGameObjectsWithTag("EyeEnemy");
            numEyesCheck = eyesOnScreen.Length;
            if (numEyesCheck == 0)
            {
                if (eyeIsCalled == false) 
                {
                    Invoke("SpawnEye", 3.0f);
                    eyeIsCalled = true;
                }
            }
        }
    }
    IEnumerator SpawnEyeCoroutine()
    {
        while (true) 
        {
            GameObject[] eyes = GameObject.FindGameObjectsWithTag("EyeEnemy");
            numEyes = eyes.Length;
            if (numEyes <= 2)
            {
                if(canSpawn)
                {
                    float xPosition = UnityEngine.Random.Range(0-xRange, 0+xRange);
                    float yPosition = UnityEngine.Random.Range(0-yRange, 0+yRange);
                    randomPosition = new Vector2(xPosition, yPosition);
                    cloneEye = Instantiate(enemyEye, randomPosition, Quaternion.identity);
                    cloneEye.GetComponent<AIDestinationSetter>().target = player;
                    yield return new WaitForSecondsRealtime(delayTimeEye);
                }
            }  
            yield return new WaitForSecondsRealtime(delayTimeEye);
        }
    }
    private void SpawnEye()
    {
        if(canSpawn)
        {
            float xPosition = Random.Range(0-xRange, 0+xRange);
            float yPosition = Random.Range(0-yRange, 0+yRange);
            randomPosition = new Vector2(xPosition, yPosition);
            cloneEye = Instantiate(enemyEye, randomPosition, Quaternion.identity);
            cloneEye.GetComponent<AIDestinationSetter>().target = player;
            eyeIsCalled = false;
        }
    }
}
