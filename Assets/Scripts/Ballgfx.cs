using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ballgfx : MonoBehaviour
{
    public AIPath aiPath;
    public int ballHealth;
    public GameObject gameObject;
    public int ballDamage = 10;
    private float currentTime;
    private int timeInterval;
    public Animator animator;
    private bool isDead = false;
    void Start()
    {
        Time.timeScale = 1.0f;
        ballHealth = 20;
        currentTime = 0f;
        aiPath.canMove = false;
    }
    void Update(){
        if(aiPath.desiredVelocity.x >= 0.01){
            transform.localScale = new Vector3(-12f, 12f, 12f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(12f, 12f, 12f);
        }
        currentTime += Time.deltaTime;
        timeInterval = Mathf.FloorToInt(currentTime%5);
        if (timeInterval == 0)
        {
            if (aiPath.canMove == true)
            {
                animator.SetBool("isMoving", false);
                aiPath.canMove = false;
            } else {
                animator.SetBool("isMoving", true);
                aiPath.canMove = true;
            }
        }
        if(ballHealth <= 0)
        {
            if (isDead == false) 
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("BallDeath");
                GameObject.Find("Main_Char").GetComponent<PlayerMovement>().score += 2;
                animator.SetTrigger("isDead");
                isDead = true;
            }
        }
    }
    public void BallDamage(int damage){
        ballHealth -= damage;
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("isHit");
        }
    }
}
