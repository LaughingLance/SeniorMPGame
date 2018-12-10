using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerDataController : MonoBehaviour
{
    public static PlayerDataController playerDataController;

    public string PlayerName;
    public string PlayerOneBallMaterial;
    public string PlayerTwoBallMaterial;
    public string PlayerWeapon;
    public string PlayerGoal;
    public int PlayerCircusTopScore;
    public int PlayerMountainVillageTopScore;
    public int PlayerCircusPlays;
    public int PlayerMtnValleyWins;
    public List<string> AllPlayerGoals;
    public List<string> AllPlayerOneBalls;
    public List<string> AllPlayerTwoBalls;
    public List<string> AllPlayerWeapons;
    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();

        // put data to be saved here
        data.G_PlayerName = PlayerName;
        data.G_PlayerOneBallMaterial = PlayerOneBallMaterial;
        data.G_PlayerTwoBallMaterial = PlayerTwoBallMaterial;
        data.G_PlayerWeapon = PlayerWeapon;
        data.G_PlayerGoal = PlayerGoal;
        data.G_PlayerCircusTopScore = PlayerCircusTopScore;
        data.G_PlayerMountainVillageTopScore = PlayerMountainVillageTopScore;
        data.G_PlayerCircusPlays = PlayerCircusPlays;
        data.G_PlayerMtnValleyWins = PlayerMtnValleyWins;
        data.G_AllPlayerGoals = AllPlayerGoals;
        data.G_AllPlayerOneBalls = AllPlayerOneBalls;
        data.G_AllPlayerTwoBalls = AllPlayerTwoBalls;
        data.G_AllPlayerWeapons = AllPlayerWeapons;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // put data to load here
            PlayerName = data.G_PlayerName;
            PlayerOneBallMaterial = data.G_PlayerOneBallMaterial;
            PlayerTwoBallMaterial = data.G_PlayerTwoBallMaterial;
            PlayerWeapon = data.G_PlayerWeapon;
            PlayerGoal = data.G_PlayerGoal;
            PlayerCircusTopScore = data.G_PlayerCircusTopScore;
            PlayerMountainVillageTopScore = data.G_PlayerMountainVillageTopScore;
            PlayerCircusPlays = data.G_PlayerCircusPlays;
            PlayerMtnValleyWins = data.G_PlayerMtnValleyWins;
            AllPlayerGoals = data.G_AllPlayerGoals;
            AllPlayerOneBalls = data.G_AllPlayerOneBalls;
            AllPlayerTwoBalls = data.G_AllPlayerTwoBalls;
            AllPlayerWeapons = data.G_AllPlayerWeapons;
        }
    }

    public bool CheckData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void OnEnable()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            Load();
        }            
    }

    private void OnDisable()
    {
        Save();
    }
}

[Serializable]
class PlayerData
{
    // Look into Get / Set for when I try and put this up on the Oculus store
    public string G_PlayerName;
    public string G_PlayerOneBallMaterial;
    public string G_PlayerTwoBallMaterial;
    public string G_PlayerWeapon;
    public string G_PlayerGoal;
    public int G_PlayerCircusTopScore;
    public int G_PlayerMountainVillageTopScore;
    public int G_PlayerCircusPlays;
    public int G_PlayerMtnValleyWins;
    public List<string> G_AllPlayerGoals;
    public List<string> G_AllPlayerOneBalls;
    public List<string> G_AllPlayerTwoBalls;
    public List<string> G_AllPlayerWeapons;
}
