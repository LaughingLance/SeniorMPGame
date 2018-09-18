using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedArmor : MonoBehaviour
{
    DataController Controller;

    public GameObject Helm;
    public Renderer HelmRenderer;
    public GameObject Chestpiece;
    public Renderer ChestRenderer;
 //   public GameObject Leggings;
    public Renderer LegRenderer;
 //   public GameObject Shield;

    private string HeadSlotData;
    private string ChestSlotData;
    private string LegSlotData;
    //  private string ShieldSlotData;

    private string PreviousHeadSlotItem;
    private string PreviousChestSlotItem;
    private string PreviousLegSlotItem;
    //   private string PreviousShieldSlotItem;

    // Helm Materials
    public Material HelmWhite;
    public Material HelmGreen;
    public Material HelmBlue;

    // Chest Materials
    public Material ChestWhite;
    public Material ChestGreen;
    public Material ChestBlue;

    // Leg Materials
    public Material Base;
    public Material LegWhite;
    public Material LegGreen;
    public Material LegBlue;

    // Timer Variables
    private float ArmorUpdate = 1.3f;
    private float ArmorUpdateTime = 0;

	// Use this for initialization
	void Start ()
    {
        Controller = FindObjectOfType<DataController>();

        HeadSlotData = Controller.HeadSlot;

        if (HeadSlotData != "")
        {
            Helm.SetActive(true);
            UpdateHelm();
        }

        ChestSlotData = Controller.ChestSlot;

        if (ChestSlotData != "")
        {
            Chestpiece.SetActive(true);
            UpdateChest();
        }

        LegSlotData = Controller.LegSlot;

        if (LegSlotData != "")
        {
            UpdateLegs();
        }
/*
        ShieldSlotData = Controller.ShieldSlot;
        PreviousShieldSlotItem = ShieldSlotData;
*/
	}
	
	// Update is called once per frame
	void Update ()
    {
        ArmorUpdateTime += Time.deltaTime;

        if (ArmorUpdateTime > ArmorUpdate)
        {
            if (Controller.HeadSlot != HeadSlotData)
            {
                if (Controller.HeadSlot == "")
                {
                    Helm.SetActive(false);
                    HeadSlotData = Controller.HeadSlot;
                }

                if (HeadSlotData == "" && Controller.HeadSlot != "")
                {
                    Helm.SetActive(true);
                    HeadSlotData = Controller.HeadSlot;
                    UpdateHelm();
                }

                if (HeadSlotData != "" && HeadSlotData != Controller.HeadSlot)
                {
                    HeadSlotData = Controller.HeadSlot;
                    UpdateHelm();
                }
            }

            if (Controller.ChestSlot != ChestSlotData)
            {
                if (Controller.ChestSlot == "")
                {
                    Chestpiece.SetActive(false);
                    ChestSlotData = Controller.ChestSlot;
                }

                if (ChestSlotData == "" && Controller.ChestSlot != "")
                {
                    Chestpiece.SetActive(true);
                    ChestSlotData = Controller.ChestSlot;
                    UpdateChest();
                }

                if (ChestSlotData != "" && ChestSlotData != Controller.ChestSlot)
                {
                    ChestSlotData = Controller.ChestSlot;
                    UpdateChest();
                }
            }

            if (Controller.LegSlot != LegSlotData)
            {
                LegSlotData = Controller.LegSlot;
                UpdateLegs();
            }
        }
	}

    void UpdateHelm()
    {
        switch (HeadSlotData)
        {
            case "HeadWhite":
                HelmRenderer.material = HelmWhite;
                break;
            case "HeadGreen":
                HelmRenderer.material = HelmGreen;
                break;
            case "HeadBlue":
                HelmRenderer.material = HelmBlue;
                break;
        }
 //       PreviousHeadSlotItem = HeadSlotData;
    }

    void UpdateChest()
    {
        switch (ChestSlotData)
        {
            case "ChestWhite":
                ChestRenderer.material = ChestWhite;
                break;
            case "ChestGreen":
                ChestRenderer.material = ChestGreen;
                break;
            case "ChestBlue":
                ChestRenderer.material = ChestBlue;
                break;
        }
 //       PreviousChestSlotItem = ChestSlotData;
    }

    void UpdateLegs()
    {
        switch (LegSlotData)
        {
            case "":
                LegRenderer.material = Base;
                break;
            case "LegWhite":
                LegRenderer.material = LegWhite;
                break;
            case "LegGreen":
                LegRenderer.material = LegGreen;
                break;
            case "LegBlue":
                LegRenderer.material = LegBlue;
                break;
        }
  //      PreviousLegSlotItem = LegSlotData;
    }
}
