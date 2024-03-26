using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public int flyerHealth = 100;
    public GameObject deathEffect;
    public int flyerDamage = 10;
    void Update(){
        if(aiPath.desiredVelocity.x >= 0.01){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public void FlyerDamage(int damage){
        flyerHealth -= damage;
        if (flyerHealth <= 0){
            Die();
        }
    }
    public void Die() {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    } 
    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (hitInfo){
            if (player != null){
                player.PlayerDamage(flyerDamage);
            }
        }
    }
}
