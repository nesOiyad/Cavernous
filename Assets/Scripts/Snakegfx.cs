using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snakegfx : MonoBehaviour
{
    public int snakeHealth;
    public GameObject gameObject;
    public Transform startPoint;
    public Transform endPoint;
    private Transform currentPoint;
    private Rigidbody2D rb;
    public float speed = 2f;
    public int snakeDamage = 10;
    private bool isDead = false;
    public Animator animator;
    void Start()
    {
        snakeHealth = 20;
        rb = GetComponent<Rigidbody2D>();
        currentPoint = endPoint.transform;
        GameObject snakes = GameObject.FindGameObjectWithTag("Snake");
        GameObject bats = GameObject.FindGameObjectWithTag("Enemy");
        GameObject eyes = GameObject.FindGameObjectWithTag("EyeEnemy");
        Physics2D.IgnoreCollision(snakes.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bats.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(eyes.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }
    void Update()
    {
        if (currentPoint == endPoint.transform)
        {
            if(speed < 0f)
            {
                speed*=-1;
            }
            rb.velocity = new Vector2(speed, 0);
        } 
        else 
        {
            if(speed > 0f)
            {
                speed*=-1;
            }
            rb.velocity = new Vector2(speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == endPoint.transform)
        {
            Flip();
            currentPoint = startPoint.transform;
        } else if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == startPoint.transform)
        {
            Flip();
            currentPoint = endPoint.transform;
        }
        if(snakeHealth <= 0)
        {
            if (isDead == false) 
            {
                GameObject.Find("Main_Char").GetComponent<PlayerMovement>().score += 1;
                animator.SetTrigger("isDead");
                isDead = true;
            }
        }
    }
    public void SnakeDamage(int damage)
    {
        snakeHealth -= damage;
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
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

