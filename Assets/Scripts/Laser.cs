using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float distanceRay = 100f;
    public LineRenderer myLineRenderer;
    public Transform laserPoint;
    public Transform player;
    private float timeWait = 3.0f;
    private float timeShoot = 6.0f;
    private float currentTime = 0f;
    private int nShoot = 0;
    private int nWait = 0;
    public Animator animator;
    void Start()
    {
        Time.timeScale = 1.0f;  
        animator.SetBool("isShooting", true);  
        ShootLaser();
        nShoot += 1;
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (nShoot > nWait)
        {
            if (currentTime < timeShoot)
            {
                ShootLaser();
            } else {
                currentTime -= timeShoot;
                nWait += 1;
                animator.SetBool("isShooting", false);
            }
        } else if (nShoot == nWait) 
        {
            if (currentTime < timeWait)
            {
                Draw2DRay(laserPoint.position, laserPoint.position);
            }
            else
            {
                nShoot += 1;
                animator.SetBool("isShooting", true);
                ShootLaser();
            }
        }
    }
    private void ShootLaser()
    {
        Vector3 direction = (laserPoint.position - player.position).normalized;
        direction *= -1;
        if (Physics2D.Raycast(laserPoint.position, direction))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserPoint.position, direction);
            if (hit.collider.tag == "Player")
            {
                hit.collider.GetComponent<PlayerMovement>().playerHealth -= 0.05f;
            }
            Draw2DRay(laserPoint.position, hit.point);
        } else {
            Draw2DRay(laserPoint.position, direction*distanceRay);
        }
    }
    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        myLineRenderer.SetPosition(0, startPos);
        myLineRenderer.SetPosition(1, endPos);
    }
}
