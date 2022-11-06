using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour, IDamagable
{
    public EnemySO enemyData;

    public string enemyName;
    private int health;
    private int damage;
    private float _rate;
    private Vector2 attackRate;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        InitializationEnemy();
    }

    void InitializationEnemy()
    {
        enemyName = enemyData.enemyName;
        health = enemyData.baseHealth;
        damage = enemyData.baseDamage;
        attackRate = enemyData.baseAttackRate;
        _rate = Random.Range((int)attackRate.x, (int)attackRate.y);
    }

    private void OnEnable()
    {
        if (health <= 0) Die();
    }

    public void Update()
    {
        if (GameManager.Instance.GlobalPause()) return;
        
        if (_rate <= Time.time)
        {
            _animator.SetTrigger("Attack");
            _rate = Random.Range((int)attackRate.x, (int)attackRate.y) + Time.time;

            IDamagable pDamagable = GameObject.Find("Player").GetComponent<IDamagable>();
            pDamagable.TakeDamage(damage);
        }
        
        Debug.Log("isPause or isGameOver");
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        _animator.SetTrigger("Hit");

        if (health <= 0) Die();
    }

    void Die()
    {
        Debug.LogError("Death!!");
        _animator.SetBool("isDeath", true);
            
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.enabled = false;
    }
}
