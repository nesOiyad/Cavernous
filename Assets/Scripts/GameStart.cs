using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public Animator animator;
    void Awake() 
    {
        Time.timeScale = 1.0f;    
    }
    public void StartGameButton()
    {
        animator.SetTrigger("isStart");
        Invoke("SceneChange", 0.5f);
    }
    private void SceneChange()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
