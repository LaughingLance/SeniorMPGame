using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerData : MonoBehaviour
{
    PlayerDataController playerData;

    private void OnEnable()
    {
        playerData = GetComponent<PlayerDataController>();

        if (playerData.CheckData() == false)
        {
            playerData.PlayerName = "Player";
            playerData.PlayerOneBallMaterial = "Grape";
            playerData.PlayerTwoBallMaterial = "Brown";
            playerData.PlayerWeapon = "GoldenSword";
            playerData.PlayerGoal = "WhiteStripesOnYellow";
            playerData.PlayerCircusTopScore = 0;
            playerData.PlayerMountainVillageTopScore = 0;
            playerData.AllPlayerGoals.Add("WhiteStripesOnYellow");
            playerData.AllPlayerGoals.Add("Rainbow");
            playerData.AllPlayerOneBalls.Add("Grape");
            playerData.AllPlayerOneBalls.Add("Gray");
            playerData.AllPlayerTwoBalls.Add("Brown");
            playerData.AllPlayerTwoBalls.Add("Yellow");
            playerData.AllPlayerWeapons.Add("GoldenSword");
            playerData.PlayerCircusPlays = 0;
            playerData.PlayerMtnValleyWins = 0;

            playerData.Save();
        }
        else
        {
            playerData.Load();
        }
    }

    private void OnDisable()
    {
        playerData.Save();
    }
}
