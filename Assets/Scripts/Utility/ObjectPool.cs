using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : SingletonMonoBehavior<ObjectPool>
{
    public override void Awake()
    {
        base.Awake();
    }

    [SerializeField] private List<GameObject> _pooledObject = new List<GameObject>();
    public GameObject damagePopUp;
    public int poolSize = 20;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(damagePopUp, transform);
            obj.SetActive(false);
            _pooledObject.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObject.Count; i++)
        {
            if (!_pooledObject[i].activeInHierarchy) return _pooledObject[i];
        }
        
        return null;
    }
}