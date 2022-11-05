using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player SO", menuName = "Player SO/Player")]
public class PlayerSO : ScriptableObject
{
    public int baseHealth;
    public int baseDamage;
    [Range(1, 100)] public int baseCritRate;
    public int baseCritDamage;
}
