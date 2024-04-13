using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemygfx : MonoBehaviour
{
    public static event Action<Enemygfx> EnemyKilled;
    public AIPath aiPath;
    public int flyerHealth;
    public GameObject deathEffect;
    public int flyerDamage = 10;
    void Start()
    {
        flyerHealth = 10;
    }
    void Update(){
        if(aiPath.desiredVelocity.x >= 0.01){
            transform.localScale = new Vector3(-6f, 6f, 6f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(6f, 6f, 6f);
        }
    }
    
    public void FlyerDamage(int damage){
        flyerHealth -= damage;
        Debug.Log("Hitler");
        if (flyerHealth <= 0){
            Die();
        }
    }
    public void Die() {
        Destroy(gameObject);
        EnemyKilled?.Invoke(this);
    } 
    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        if (hitInfo){
            if (player != null){
                player.PlayerDamage(flyerDamage);

            }
            if (bullet!=null)
            {
                FlyerDamage(31);
                Debug.Log("Hitler");
            }
        }
    }
}
