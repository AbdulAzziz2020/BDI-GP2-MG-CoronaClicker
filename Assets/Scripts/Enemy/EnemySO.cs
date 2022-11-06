using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy SO/Enemy", fileName = "Enemy SO")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public int baseHealth;
    public int baseDamage;
    public Vector2 baseAttackRate;
}