using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemygfx : MonoBehaviour
{
    public AIPath aiPath;
    public int flyerHealth;
    public GameObject gameObject;
    public int flyerDamage = 10;
    public Animator animator;
    private bool isDead = false;
    void Start()
    {
        flyerHealth = 20;
    }
    void Update(){
        if(aiPath.desiredVelocity.x >= 0.01){
            transform.localScale = new Vector3(-6f, 6f, 6f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(6f, 6f, 6f);
        }
        if(flyerHealth <= 0)
        {
            if (isDead == false) 
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("BatDeath");
                GameObject.Find("Main_Char").GetComponent<PlayerMovement>().score += 1;
                animator.SetTrigger("isDead");
                isDead = true;
            }
        }
    }
    
    public void FlyerDamage(int damage){
        flyerHealth -= damage;
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("isHit");
        } else if (hit.gameObject.tag == "Player")
        {
            animator.SetTrigger("isAttack");
        }
    }
}
