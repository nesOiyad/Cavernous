using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    public GameObject snake;
    private RaycastHit2D hitInfo;
    private Rigidbody2D rb;
    public Transform firePoint;
    public float rushSpeed = 6f;
    public float setSpeed = 2f;
    void  Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        StartCoroutine(Rush());
    }
    IEnumerator Rush()
    {
        float dir = snake.GetComponent<Snakegfx>().speed;
        if(dir < 0f)
        {
            hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right*-1, 10f);
            Debug.DrawRay(firePoint.position, firePoint.right*-10f);
        }
        else 
        {
            hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 10f);
            Debug.DrawRay(firePoint.position, firePoint.right*10f);
        }
        if(hitInfo)
        {
            PlayerMovement player = hitInfo.transform.GetComponent<PlayerMovement>();
            if(player != null)
            { 
                snake.GetComponent<Snakegfx>().speed = rushSpeed;
                yield return new WaitForSeconds(1f);
            }
            else 
            {
                snake.GetComponent<Snakegfx>().speed = setSpeed;
            }
        }
        else 
        {
            snake.GetComponent<Snakegfx>().speed = setSpeed;
        }
    }
}
