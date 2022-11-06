using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IDamagable
{
    public PlayerSO playerData;
    public int coin;
    public int health;
    public int damage;
    public float critRate;
    public int critDamage;

    public LayerMask enemyMask;
    public event Action OnUpdateStatUI;

    private void Start()
    {
        string load = SaveSystem.Load();
        
        if (load == null)
        {
            coin = 0;
            health = playerData.baseHealth;
            damage = playerData.baseDamage;
            critRate = playerData.baseCritRate;
            critDamage = playerData.baseCritDamage;
            
            OnUpdateStatUI?.Invoke();
        }
    }

    public void Update()
    { 
        if (GameManager.Instance.GlobalPause()) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 hitPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(hitPosition, Vector2.zero, enemyMask);
        
            if (hit.collider != null)
            {
                bool isCrit = Random.Range(0f, 100f) < critRate;
                
                IDamagable damagable = hit.collider.GetComponent<IDamagable>();
                DamagePopup.Create(hitPosition, damagable, damage, critDamage, isCrit);
                
                coin++;
                OnUpdateStatUI?.Invoke();
                GameData.Instance.Save();
                
                Debug.Log($"<color=green>++{coin}</color> Coin");
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0) Die();
    }

    void Die()
    {
        Debug.LogError("Player Death");

        GameManager.Instance.GameOver();
    }
}
