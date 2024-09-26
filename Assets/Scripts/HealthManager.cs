using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public UnityEngine.UI.Image healthBar;
    public float healthAmount;
    public GameObject player;
    void Start()
    {
        healthAmount = 200f;
    }

    void Update()
    {
        if (healthAmount > 0)
        {
            healthAmount = player.GetComponent<PlayerMovement>().playerHealth;
            healthBar.fillAmount = healthAmount / 200f;
        }
    }
}
