using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.AI;
using System.Numerics;
using System;

public class Spidergfx : MonoBehaviour
{
    public int spiderHealth;
    public GameObject gameObject;
    public int spiderDamage = 10;
    public delegate void DeathAction();
    public static event DeathAction SpiderDied;
    public Transform target;
    public float speed = 400f;
    public float nextWayPointDistance = 1f;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath;
    float jumpPower = 300f;
    bool isGrounded;
    Seeker seeker;
    Rigidbody2D rb;
    float activeDistance = 100f;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        spiderHealth = 20;
        InvokeRepeating("UpdatePath", 0f, 1f);
    }
    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    void FixedUpdate()
    {
       if (UnityEngine.Vector2.Distance(transform.position, target.transform.position) < activeDistance)
       {
            PathFollow();
       }
    }
    void PathFollow()
    {
        if(path == null)
        {
            return;
        }
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else 
        {
            reachedEndOfPath = false;
        }
        isGrounded = Physics.Raycast(transform.position, -UnityEngine.Vector3.up, GetComponent<Collider2D>().bounds.extents.y+0.1f);
        UnityEngine.Vector2 direction = ((UnityEngine.Vector2) path.vectorPath[currentWayPoint] - rb.position).normalized;
        UnityEngine.Vector2 force = speed * Time.deltaTime * direction;
        if (direction.y > 0.05f && isGrounded)
        {
            rb.AddForce(jumpPower*UnityEngine.Vector2.up*speed);
        } else 
        {
            rb.AddForce(force);
        }
        float distance = UnityEngine.Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
        if(rb.velocity.x > 0.05f)
        {
            transform.localScale = new UnityEngine.Vector3(-1f*Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (rb.velocity.x < -0.05f)
        {
            transform.localScale = new UnityEngine.Vector3(1f*Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    } 
    void Update()
    {
        if (spiderHealth <= 0)
        {
            Die();
        }
    }

    public void SpiderDamage(int damage){
        spiderHealth -= damage;
        Debug.Log("Hitler");
    }
    private void Die() 
    {
        DestroyObject(gameObject);
        if (SpiderDied != null)
        {
            SpiderDied();
        }
    }
}
