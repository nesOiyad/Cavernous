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
    public Transform original;
    public bool fire;
    public float timer;
    public float timeBetween = 5f;
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
        if(Input.GetMouseButtonDown(0)&& fire == true)
        {
            fire = false;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("Bullet");
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            original.position = new Vector3(gun.position.x, gun.position.y, gun.position.z);
            gun.position -= gun.forward * 0.1f;
            Invoke("BackToNormal", 0.5f);
        }
    }
    private void BackToNormal()
    {
        gun.position = new Vector3(original.position.x, original.position.y, original.position.z);
    }
    private void Flip()
    {
        gun.Rotate(0f, 180f, 0f);
    }
}