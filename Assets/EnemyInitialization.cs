using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyInitialization : SingletonMonoBehavior<EnemyInitialization>
{
    [Header("Enemies")] 
    public TMP_Text enemyName;
    public GameObject[] arrEnemy;
    
    private int _curIndex = 0;
    [HideInInspector] public List<GameObject> listEnemy = new List<GameObject>();

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
            GameObject obj = Instantiate(arrEnemy[i], transform.position, Quaternion.identity, transform);
            obj.SetActive(false);
            listEnemy.Add(obj);
        }
            
        ShowEnemy();
    }
        
    
    #region EnemyNavigation

        void ShowEnemy()
        {
            listEnemy[_curIndex].SetActive(true);
            enemyName.text = listEnemy[_curIndex].GetComponent<Enemy>().enemyName;
        }

        void HideEnemy()
        {
            listEnemy[_curIndex].SetActive(false);
        }
    
        public void OnNextEnemy()
        {
            HideEnemy();

            if (_curIndex < listEnemy.Count - 1) _curIndex++;
            else _curIndex = 0;
        
            ShowEnemy();
        }

        public void OnPreviousEnemy()
        {
            HideEnemy();

            if (_curIndex == 0) _curIndex = listEnemy.Count - 1;
            else _curIndex--;
        
            ShowEnemy();
        }
    
        #endregion
}
