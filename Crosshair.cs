using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Camera camera;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform gun;
    public bool fire;
    public float time;
    public float timeBetween = 5;
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!fire)
        {
            timer += time.deltaTime;
            if(timer > timeBetween)
            {
                fire = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButton(0))
        {
            fire = false;
            Instantiate(bullet, gun.position, Quaternion.identity);
        }
    }
}