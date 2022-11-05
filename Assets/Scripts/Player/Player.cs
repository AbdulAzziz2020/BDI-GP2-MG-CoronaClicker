using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IDamagable
{
    public PlayerSO playerData;
    
    private int _health;
    private int _damage;
    private int _critRate;
    private int _critDamage;

    public LayerMask enemyMask;

    private void Awake()
    {
        _health = playerData.baseHealth;
        _damage = playerData.baseDamage;
        _critRate = playerData.baseCritRate;
        _critDamage = playerData.baseCritDamage;
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
                bool isCrit = Random.Range(0, 100) < _critRate;
                
                IDamagable damagable = hit.collider.GetComponent<IDamagable>();
                DamagePopup.Create(hitPosition, damagable, _damage, _critDamage, isCrit);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 0) Die();
    }

    void Die()
    {
        Debug.Log("Player Death");
        
    }
}
