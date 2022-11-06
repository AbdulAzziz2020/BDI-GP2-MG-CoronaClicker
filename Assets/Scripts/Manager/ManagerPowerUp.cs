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
    
    public void Heal()
    {
        if (GameData.coin >= priceHeal)
        {
            GameData.coin -= priceHeal;
            player.health += heal;
            Debug.Log($"Coin <color=red>-{GameData.coin}</color>");
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }

    public void IncreaseDamage()
    {
        if (GameData.coin >= priceIncDmg)
        {
            GameData.coin -= priceHeal;
            player.damage += incDmg;
            Debug.Log($"Coin <color=red>-{GameData.coin}</color>");
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }

    public void IncreaseCritRate()
    {
        if (GameData.coin >= priceIncCritRate)
        {
            GameData.coin -= priceHeal;
            player.critRate += incCritRate;
            Debug.Log($"Coin <color=red>-{GameData.coin}</color>");
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }

    public void IncreaseCritDmg()
    {
        if (GameData.coin >= priceIncCritDmg)
        {
            GameData.coin -= priceHeal;
            player.critDamage += incCritDmg;
            Debug.Log($"Coin <color=red>-{GameData.coin}</color>");
        }
        else
        {
            Debug.Log($"<color=yellow>not enough coins</color>");
        }
    }
}