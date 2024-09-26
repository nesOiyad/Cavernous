using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyEye : MonoBehaviour
{
    public AIPath aiPath;
    public int eyeHealth;
    public GameObject gameObject;
    public int eyeDamage = 15;
    public Animator animator;
    private bool isDead = false;
    void Start()
    {
        eyeHealth = 30;
    }
    void Update(){
        if(aiPath.desiredVelocity.x >= 0.01){
            transform.localScale = new Vector3(-6f, 6f, 6f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(6f, 6f, 6f);
        }
        if(eyeHealth <= 0)
        {
            if (isDead == false) 
            {
                GameObject.Find("Main_Char").GetComponent<PlayerMovement>().score += 2;
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("EyeDeath");
                animator.SetTrigger("isDead");
                isDead = true;
            }
        }
    }   
    public void EyeDamage(int damage){
        eyeHealth -= damage;
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
