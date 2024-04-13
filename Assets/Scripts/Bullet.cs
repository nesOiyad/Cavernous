using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera camera;
    public Rigidbody2D rb;
    public int damage = 5;
    public float speed = 5f;
    public GameObject gameObject;
    public GameObject enemy;
    
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb = GetComponent<Rigidbody2D>();
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePos-transform.position;
        float distance = difference.magnitude;
        Vector2 direction = difference/distance;
        direction.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        rb.velocity = new Vector2(direction.x, direction.y).normalized*speed;
    }
    void OnBecameInvisible()
    {
        DestroyObject(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "solid")
        {
            Destroy(gameObject);
        }
        

        if (hit.gameObject.tag == "Enemy")
        {
            enemy.GetComponent<Enemygfx>().FlyerDamage(damage);
            
        }
        
    } 
    
}
