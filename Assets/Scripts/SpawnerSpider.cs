using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpider : MonoBehaviour
{
    public GameObject enemySpider;
    private GameObject cloneSpider;
    private GameObject[] enemies;
    public float delayTime = 5.0f;
    public bool canSpawn = false; 
    void Start()
    {
        SpawnSpider();
    }
    void OnEnable()
    {
        Spidergfx.SpiderDied += DelaySpider;
    }
    void OnDisable()
    {
        Spidergfx.SpiderDied -= DelaySpider;
    }
    public void DelaySpider()
    {
        Invoke("SpawnSpider", delayTime);
    }
    public void SpawnSpider()
    {
        if(canSpawn)
        {
            cloneSpider = Instantiate(enemySpider, transform.position, Quaternion.identity);
        }
    }
}
