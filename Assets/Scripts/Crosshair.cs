using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Camera camera;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform gun;
    public Transform firePoint;
    public bool fire;
    public float timer;
    public float timeBetween = 5;
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - gun.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(0, 0, rotZ);
        if (fire == false)
        {
            timer += Time.deltaTime;
            if(timer > timeBetween)
            {
                fire = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButtonDown(0)&& fire== true)
        {
            fire = false;
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }
}