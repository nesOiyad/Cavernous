using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.AI;
using System.Numerics;
using System;
public class TopCheck : MonoBehaviour 
{
    public bool passingThrough = false;
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "solid")
        {
            GameObject solid = GameObject.FindGameObjectWithTag("solid");
            GameObject spider = GameObject.FindGameObjectWithTag("Spider"); 
            Physics2D.IgnoreCollision(solid.GetComponent<Collider2D>(), spider.GetComponent<Collider2D>());
            passingThrough = true;
        }
    }
}