using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ghostgfx : MonoBehaviour
{
    public AIPath aiPath;
    public int ghostHealth;
    public GameObject gameObject;
    public int ghostDamage = 10;
    public Animator animator;
    private bool isDead = false;
    void Start()
    {
        GameObject solid = GameObject.FindGameObjectWithTag("solid");
        Physics2D.IgnoreCollision(solid.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        ghostHealth = 20;
    }
    void Update(){
        if(aiPath.desiredVelocity.x >= 0.01){
            transform.localScale = new Vector3(-6f, 6f, 6f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(6f, 6f, 6f);
        }
        if(ghostHealth <= 0)
        {
            if (isDead == false) 
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("GhostDeath");
                GameObject.Find("Main_Char").GetComponent<PlayerMovement>().score += 1;
                animator.SetTrigger("isDead");
                isDead = true;
            }
        }
    }
    public void GhostDamage(int damage){
        ghostHealth -= damage;
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("isHit");
        } else if (hit.gameObject.tag == "Player") {
            animator.SetTrigger("isAttack");
        }
    }
}
