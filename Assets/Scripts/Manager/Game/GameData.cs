using System;
using System.IO;
using UnityEngine;

public class GameData : SingletonMonoBehavior<GameData>
{
    public PlayerSO playerData;
    public Player player;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SaveSystem.Init();
    }

    public void Save()
    {
        SaveData savePlayer = new SaveData
        {
            coin = player.coin,
            health = player.health,
            damage = player.damage,
            crit = player.critRate,
            critDmg = player.critDamage,
        };
        

        string playerJson = JsonUtility.ToJson(savePlayer);

        SaveSystem.Save(playerJson);

        Debug.LogWarning("Saved!");
        Debug.LogWarning(playerJson);
    }

    public void Load()
    {
        string saveString = SaveSystem.Load();
        
        if(saveString != null)
        {
            Debug.LogWarning("Loaded " + saveString);

            SaveData saveData = JsonUtility.FromJson<SaveData>(saveString);

            player.coin = saveData.coin;
            player.health = saveData.health;
            player.damage = saveData.damage;
            player.critRate = saveData.crit;
            player.critDamage = saveData.critDmg;
            
            Debug.LogWarning("Load Successful");
        }
        else
        {
            Debug.LogWarning("No Save");
        }
    }

    public class SaveData
    {
        public int coin;
        public int health;
        public int damage;
        public float crit;
        public int critDmg;
    }
}