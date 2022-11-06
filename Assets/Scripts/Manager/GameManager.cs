using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [Header("Global Variable")] 
    public bool isGameOver = false;
    public bool isPause = false;

    public void Start()
    {
        Debug.Log(GameData.coin);
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
}