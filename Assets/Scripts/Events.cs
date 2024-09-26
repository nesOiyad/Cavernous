using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Events : MonoBehaviour
{
    private float currentTime = 0;
    public GameObject spawnerBatGhost;
    public GameObject spawnerSnake;
    public GameObject spawnerEyeMonster;
    public GameObject spawnerBall;
    private GameObject cloneBoss;
    public GameObject enemyBoss;
    public Transform player;
    private bool bossSpawn = true;
    public GameObject wonGame;
    public GameObject lostGame;
    public GameObject displayGame;
    public GameObject bossHealthDisplay;
    public UnityEngine.UI.Image bossHealthBar;
    public int bossHealthAmount;
    void Update()
    {
        currentTime += Time.deltaTime;
        int rounded = Mathf.FloorToInt(currentTime);
        if (rounded == 60)
        {
            spawnerSnake.GetComponent<SpawnerSnake>().canSpawn = true;
        }
        else if (rounded == 120)
        {
            spawnerEyeMonster.GetComponent<SpawnerEye>().canSpawn = true;
        }
        else if (rounded == 180)
        {
            spawnerBall.GetComponent<BallSpawner>().canSpawn = true;
        } else if (rounded == 240)
        {
            spawnerBatGhost.GetComponent<Spawner>().canSpawn = false;
            spawnerSnake.GetComponent<SpawnerSnake>().canSpawn = false;
            spawnerEyeMonster.GetComponent<SpawnerEye>().canSpawn = false;
            spawnerBall.GetComponent<BallSpawner>().canSpawn = false;
        } else if (rounded == 270)
        {
            if (bossSpawn == true) 
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("MainTheme");
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("BossTheme");
                cloneBoss = Instantiate(enemyBoss, transform.position, Quaternion.identity);
                cloneBoss.GetComponent<AIDestinationSetter>().target = player;
                cloneBoss.GetComponent<Bossgfx>().targetPlayer = player;
                cloneBoss.GetComponent<Bossgfx>().gameWon = wonGame;
                cloneBoss.GetComponent<Bossgfx>().gameDisplay = displayGame;
                cloneBoss.GetComponent<Bossgfx>().bossDisplay = bossHealthDisplay;
                bossSpawn = false;
                bossHealthDisplay.SetActive(true);
            }
        } else if (rounded < 360 && rounded > 240)
        {
            GameObject[] isBoss = GameObject.FindGameObjectsWithTag("Boss");
            if (isBoss.Length > 0)
            {
                bossHealthAmount = cloneBoss.GetComponent<Bossgfx>().bossHealth;
                bossHealthBar.fillAmount = bossHealthAmount / 100f;
            }
        } else if (rounded == 360)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopSound("BossTheme");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySound("GameOverTheme");
            int scoreToSet = GameObject.Find("Main_Char").GetComponent<PlayerMovement>().score;
            lostGame.GetComponent<GameOverPlayerScreen>().SetScore(scoreToSet);
            displayGame.SetActive(false);
            bossHealthDisplay.SetActive(false);
        }

    }
}
