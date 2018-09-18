using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataController : MonoBehaviour
{
    public static DataController controller;

    public string PortalDestination;
    public string HeadSlot;
    public string ChestSlot;
    public string LegSlot;
    public string ShieldSlot;

    public List<GameObject> HeadInventory = new List<GameObject>();
    public List<GameObject> ChestInventory = new List<GameObject>();
    public List<GameObject> LegInventory = new List<GameObject>();
    public List<GameObject> ShieldInventory = new List<GameObject>();

    private void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        
        data.G_PortalDestination = PortalDestination;
        data.G_HeadSlot = HeadSlot;
        data.G_ChestSlot = ChestSlot;
        data.G_LegSlot = LegSlot;
        data.G_ShieldSlot = ShieldSlot;
        data.G_HeadInventory = HeadInventory;
        data.G_ChestInventory = ChestInventory;
        data.G_LegInventory = LegInventory;
        data.G_ShieldInventory = ShieldInventory;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            PortalDestination = data.G_PortalDestination;
            HeadSlot = data.G_HeadSlot;
            ChestSlot = data.G_ChestSlot;
            LegSlot = data.G_LegSlot;
            ShieldSlot = data.G_ShieldSlot;
            HeadInventory = data.G_HeadInventory;
            ChestInventory = data.G_ChestInventory;
            LegInventory = data.G_LegInventory;
            ShieldInventory = data.G_ShieldInventory;

        }
    }
}


[Serializable]
class PlayerData
{
    public string G_PortalDestination;
    public string G_HeadSlot;
    public string G_ChestSlot;
    public string G_LegSlot;
    public string G_ShieldSlot;

    public List<GameObject> G_HeadInventory = new List<GameObject>();
    public List<GameObject> G_ChestInventory = new List<GameObject>();
    public List<GameObject> G_LegInventory = new List<GameObject>();
    public List<GameObject> G_ShieldInventory = new List<GameObject>();
}