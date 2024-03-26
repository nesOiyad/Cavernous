using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float jumpingPower = 10f;
    private float speed = 4f;
    private float setSpeed = 4f;
    private bool isFacingRight = true;
    public int playerHealth = 200;
    private int remainingJump = 0;
    private float sprintSpeed = 6f;
    //Defining needed variables
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator animator;
    // Update is called once per frame
    void Start() {
        Debug.Log(Input.GetAxis("Horizontal"));
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal*speed));
        if (Input.GetKeyDown(KeyCode.A) && IsGrounded()){
            remainingJump += 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetKeyDown(KeyCode.A) && !IsGrounded() && remainingJump > 0){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            remainingJump = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) && rb.velocity.y > 0f){
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
        }
    }
    //Flipping the sprite from left to right if moving to right or left
    public void PlayerDamage(int damage){
        playerHealth -= damage;
    }
    //Player health damage
}
