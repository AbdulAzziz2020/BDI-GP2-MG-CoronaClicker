using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    
    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + "SaveData.txt", saveString);
    }

    public static void DeleteData()
    {
        File.Delete(SAVE_FOLDER + "SaveData.txt");
    }

    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "SaveData.txt"))
        {
            string playerString = File.ReadAllText(SAVE_FOLDER + "SaveData.txt");
            return playerString;
        }
        else
        {
            return null;
        }
    }
}