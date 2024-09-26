using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float jumpingPower = 10f;
    private float speed = 4f;
    private float setSpeed = 4f;
    private bool isFacingRight = true;
    public float playerHealth = 200f;
    private int remainingJump = 0;
    private float sprintSpeed = 6f;
    public int score;
    public Transform gun;
    public Transform self;
    public Animator animator;
    private float netSpeed;
    public GameObject gameOverScreen;
    public GameObject normalScreen;
    private bool isDead = false;
    public GameObject displayBoss;
    //Defining needed variables
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            remainingJump += 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded() && remainingJump > 0){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            remainingJump = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f);
        }
        //Jumping
        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded()){
            speed = sprintSpeed;
        } 
        if (Input.GetKeyUp(KeyCode.LeftShift) && IsGrounded()){
            speed = setSpeed;
        }
        Flip();
        netSpeed = Mathf.Abs(rb.velocity.x); 
        animator.SetFloat("Speed", netSpeed);
        animator.SetFloat("UpwardSpeed", rb.velocity.y);
        if (playerHealth <= 0)
        {
            if (isDead == false) 
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("MainTheme");
                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("BossTheme");
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("GameOverTheme");
                isDead = true;
                normalScreen.SetActive(false);
                displayBoss.SetActive(false);
                gameOverScreen.GetComponent<GameOverPlayerScreen>().SetScore(score);
                animator.SetTrigger("isDead");
            }
        }
    }
    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    //Fixed update for the sprite
    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    //Check if grounded
    private void Flip(){
        if (isFacingRight && (horizontal < 0f) || !isFacingRight && (horizontal > 0f)){
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
            gun.Rotate(180f, 0f, 0f);
        }
    }
    //Flipping the sprite from left to right if moving to right or left
    public void PlayerDamage(int damage){
        playerHealth -= damage;
    }
    //Player health damage
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            playerHealth -= 10f;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerHit");
            animator.SetTrigger("isHit");
        }  
        if (hit.gameObject.tag == "Ghost")
        {
            playerHealth -= 10f;
            animator.SetTrigger("isHit");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerHit");
        } 
        if (hit.gameObject.tag == "Snake")
        {
            playerHealth -= 15f;
            animator.SetTrigger("isHit");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerHit");
        }
        if (hit.gameObject.tag == "EyeEnemy")
        {
            playerHealth -= 15f;
            animator.SetTrigger("isHit");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerHit");
        }
        if (hit.gameObject.tag == "BallEnemy")
        {
            playerHealth -= 10f;
            animator.SetTrigger("isHit");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerHit");
        }
    }
}
