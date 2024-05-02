using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private GameObject cloneEnemy;
    private GameObject[] enemies;
    void Start()
    {
        cloneEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies == null){
            Spawn();
        }
        if(cloneEnemy.GetComponent<Enemygfx>.flyerHealth <= 0)
        {
            Destroy(cloneEnemy);
        }
    }
    public void Spawn()
    {
        cloneEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
    } 

}
