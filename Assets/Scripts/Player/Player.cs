using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IDamagable
{
    public PlayerSO playerData;
    
    [HideInInspector] public int health;
    [HideInInspector] public int damage;
    [HideInInspector] public float critRate;
    [HideInInspector] public int critDamage;

    public LayerMask enemyMask;

    private void Awake()
    {
        health = playerData.baseHealth;
        damage = playerData.baseDamage;
        critRate = playerData.baseCritRate;
        critDamage = playerData.baseCritDamage;
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

                GameData.coin++;
                Debug.Log($"<color=green>++{GameData.coin}</color> Coin");
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
        Debug.Log("Player Death");
        
    }
}
