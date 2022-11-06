using System;
using UnityEngine;

public class ManagerPowerUp : MonoBehaviour
{
    public Player player;

    [Header("Manage Power Up")] 
    public int heal;
    public int incDmg;
    public float incCritRate;
    public int incCritDmg;
    
    [Header("Power Up Requirment")]
    public int priceHeal;
    public int priceIncDmg;
    public int priceIncCritRate;
    public int priceIncCritDmg;

    public event Action OnUpdateStatus;
    
    public void Heal()
    {
        if (player.coin >= priceHeal)
        {
            player.coin -= priceHeal;
            player.health += heal;
            Debug.Log($"Coin <color=red>-{player.coin}</color>");
            
            GameData.Instance.Save();
            OnUpdateStatus?.Invoke();
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }

    public void IncreaseDamage()
    {
        if (player.coin >= priceIncDmg)
        {
            player.coin -= priceIncDmg;
            player.damage += incDmg;
            Debug.Log($"Coin <color=red>-{player.coin}</color>");
            
            GameData.Instance.Save();
            OnUpdateStatus?.Invoke();
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }

    public void IncreaseCritRate()
    {
        if (player.coin >= priceIncCritRate && player.critRate <= 100)
        {
            player.coin -= priceIncCritRate;
            player.critRate += incCritRate;
            Debug.Log($"Coin <color=red>-{player.coin}</color>");
            
            GameData.Instance.Save();
            OnUpdateStatus?.Invoke();
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }

    public void IncreaseCritDmg()
    {
        if (player.coin >= priceIncCritDmg)
        {
            player.coin -= priceIncCritDmg;
            player.critDamage += incCritDmg;
            Debug.Log($"Coin <color=red>-{player.coin}</color>");
            
            GameData.Instance.Save();
            OnUpdateStatus?.Invoke();
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }
}