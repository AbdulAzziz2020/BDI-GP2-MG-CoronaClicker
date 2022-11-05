using System;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Runtime.UIManager.Components;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [Header("Global Variable")] 
    public bool isGameOver = false;
    public bool isPause = false;

    [Header("GameView")] 
    public UIButton nextButton;
    public UIButton prevButton;


    [Header("Enemies")]
    public Transform enemyParent;
    public GameObject[] arrEnemy;

    private int _curIndex = 0;
    private List<GameObject> _listEnemy = new List<GameObject>();
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        InitializationEnemy();
    }

    public void InitializationEnemy()
    {
        for (int i = 0; i < arrEnemy.Length; i++)
        {
            GameObject obj = Instantiate(arrEnemy[i], enemyParent.position, Quaternion.identity, enemyParent.transform);
            obj.SetActive(false);
            _listEnemy.Add(obj);
        }
        
        ShowEnemy();
    }

    public bool GlobalPause()
    {
        if (isGameOver || isPause)
        {
            foreach (var obj in _listEnemy)
            {
                Animator _anim = obj.GetComponent<Animator>();
                _anim.speed = 0f;
            }
            
            return true;
        }
        else
        {
            foreach (var obj in _listEnemy)
            {
                Animator _anim = obj.GetComponent<Animator>();
                _anim.speed = 1f;
            }
            
            return false;
        }
    }


    #region Listener Region

    private void OnEnable()
    {
        nextButton.onClickEvent.AddListener(OnNextEnemy);
        prevButton.onClickEvent.AddListener(OnPreviousEnemy);
        
        Debug.LogWarning("Succes Added Listener!");
    }
    
    private void OnDisable()
    {
        nextButton.onClickEvent.RemoveListener(OnNextEnemy);
        prevButton.onClickEvent.RemoveListener(OnPreviousEnemy);
        
        Debug.LogError("Succes Remove Listener!");
    }

    #endregion
    
    
    #region EnemyNavigation

    public void ShowEnemy()
    {
        _listEnemy[_curIndex].SetActive(true);
    }

    public void HideEnemy()
    {
        _listEnemy[_curIndex].SetActive(false);
    }
    
    public void OnNextEnemy()
    {
        HideEnemy();

        if (_curIndex < _listEnemy.Count - 1) _curIndex++;
        else _curIndex = 0;
        
        ShowEnemy();
    }

    public void OnPreviousEnemy()
    {
        HideEnemy();

        if (_curIndex == 0) _curIndex = _listEnemy.Count - 1;
        else _curIndex--;
        
        ShowEnemy();
    }
    
    #endregion
}