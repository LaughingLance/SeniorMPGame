using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public List<GameObject> WeaponList = new List<GameObject>();
    public GameObject WeaponOnDisplay;
    public bool switchingWeapon = false;
    private int currentlySelectedWeaponID;

    public GameObject Weapon_GoldenSword;
    public GameObject Weapon_WoodClub;

    private GameObject dataController;
    PlayerDataController playerData;

    // Use this for initialization
    void Start ()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        for (int i = 0; i < WeaponList.Count; i++)
        {
            WeaponList[i].SetActive(false);
        }

        currentlySelectedWeaponID = playerData.AllPlayerWeapons.IndexOf(playerData.PlayerWeapon);
        DetermineNewlySelectedWeapon(currentlySelectedWeaponID);
        WeaponOnDisplay.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        WeaponOnDisplay.transform.Rotate(Vector3.forward * 4 * Time.deltaTime);
	}

    public void RotatingWeaponsRight()
    {
        if (switchingWeapon)
        {
            WeaponOnDisplay.SetActive(false);
            StartCoroutine("WeaponRotationRightTimer");
        }
    }

    IEnumerator WeaponRotationRightTimer()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedWeaponID == playerData.AllPlayerWeapons.Count - 1)
        {
            currentlySelectedWeaponID = 0;
            DetermineNewlySelectedWeapon(currentlySelectedWeaponID);
            WeaponOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedWeaponID++;
            DetermineNewlySelectedWeapon(currentlySelectedWeaponID);
            WeaponOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    public void RotatingWeaponsLeft()
    {
        if (switchingWeapon)
        {
            WeaponOnDisplay.SetActive(false);
            StartCoroutine("WeaponRotationLeftTimer");
        }        
    }

    IEnumerator WeaponRotationLeftTimer()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedWeaponID == 0)
        {
            currentlySelectedWeaponID = playerData.AllPlayerWeapons.Count - 1;
            DetermineNewlySelectedWeapon(currentlySelectedWeaponID);
            WeaponOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedWeaponID--;
            DetermineNewlySelectedWeapon(currentlySelectedWeaponID);
            WeaponOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    IEnumerator ReactivateButtons()
    {
        yield return new WaitForSeconds(0.25f);
        switchingWeapon = false;
    }

    private void DetermineNewlySelectedWeapon(int newListPosition)
    {
        switch (playerData.AllPlayerWeapons[newListPosition])
        {
            case "GoldenSword":
                playerData.PlayerWeapon = playerData.AllPlayerWeapons[newListPosition];
                playerData.Save();
                WeaponOnDisplay = Weapon_GoldenSword;
                break;
            case "WoodenClub":
                playerData.PlayerWeapon = playerData.AllPlayerWeapons[newListPosition];
                playerData.Save();
                WeaponOnDisplay = Weapon_WoodClub;
                break;
        }
    }
}
