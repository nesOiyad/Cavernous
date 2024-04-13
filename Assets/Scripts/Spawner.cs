using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private GameObject[] enemies;
    void Start()
    {
        Spawn();
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies == null){
            Spawn();
        }
    }
    public void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    } 

}
