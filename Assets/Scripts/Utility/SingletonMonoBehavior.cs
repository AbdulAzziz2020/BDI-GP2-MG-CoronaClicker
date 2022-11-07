using System;
using UnityEngine;

public class SingletonDontDestroyOnLoad<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; set; }
    
    public virtual void Awake()
    {
        if (Instance != this && Instance != null) Destroy(this);
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
        }
    }
}
