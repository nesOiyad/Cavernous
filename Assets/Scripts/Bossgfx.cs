using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bossgfx : MonoBehaviour
{
    public AIPath aiPath;
    public int bossHealth;
    public GameObject gameObject;
    public Transform targetPlayer;
    public GameObject laser;
    private bool isDead = false;
    public GameObject gameWon;
    public GameObject gameDisplay;
    public Animator animator;
    public GameObject bossDisplay;
    void Start()
    {
        bossHealth = 100;
        laser.GetComponent<Laser>().player = targetPlayer;
    }
    void Update(){
        if(aiPath.desiredVelocity.x >= 0.01){
            transform.localScale = new Vector3(-3f, 3f, 3f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(3f, 3f, 3f);
        }
        if(bossHealth <= 0)
        {
            if (isDead == false) 
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("BossTheme");
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                if (players.Length == 0){}
                else
                {
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("GameWonTheme");
                    int scoreTo = GameObject.Find("Main_Char").GetComponent<PlayerMovement>().score + 10;
                    gameDisplay.SetActive(false);
                    bossDisplay.SetActive(false);
                    gameWon.GetComponent<GameWonPlayerScreen>().SetScoreWon(scoreTo);
                    animator.SetTrigger("isDead");
                }
            }
        }
    }
    public void BossDamage(int damage){
        bossHealth -= damage;
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("isHit");
        }
    }
}
