using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [Header("Global Variable")] 
    public bool isGameOver = false;
    public bool isPause = false;

    public override void Awake()
    {
        base.Awake();
        
    }

    public bool GlobalPause()
    {
        if (isGameOver || isPause)
        {
            foreach (var obj in EnemyInitialization.Instance.listEnemy)
            {
                Animator _anim = obj.GetComponent<Animator>();
                _anim.speed = 0f;
            }
            
            return true;
        }
        else
        {
            foreach (var obj in EnemyInitialization.Instance.listEnemy)
            {
                Animator _anim = obj.GetComponent<Animator>();
                _anim.speed = 1f;
            }
            
            return false;
        }
    }

    private void Start()
    {
        GameData.Instance.Load();
    }

    public void GameOver()
    {
        isGameOver = true;
        SaveSystem.DeleteData();
        GameView.Instance.GameOverPanel.Show();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.LogError("Application Exit!");
    }
}