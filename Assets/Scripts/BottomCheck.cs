using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.AI;
using System.Numerics;
using System;
public class BottomCheck : MonoBehaviour 
{
    public bool passThrough;
    public GameObject top;
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "solid")
        {
            GameObject solid = GameObject.FindGameObjectWithTag("solid");
            GameObject spider = GameObject.FindGameObjectWithTag("Spider"); 
            passThrough = top.GetComponent<TopCheck>().passingThrough;
            if (passThrough == true)
            {
                Physics2D.IgnoreCollision(solid.GetComponent<Collider2D>(), spider.GetComponent<Collider2D>(), false);
                passThrough = false;
            }
        }
    }
}