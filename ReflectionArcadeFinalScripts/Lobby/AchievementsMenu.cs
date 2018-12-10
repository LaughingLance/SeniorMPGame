using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsMenu : MonoBehaviour
{
    public Text CircusScore;
    public Text CircusGamesPlayed;
    public Text MtnValleyWinsOne;
    public Text MtnValleyScoreTen;
    public Text MtnValleyScoreTwenty;
    public Text MtnValleyWinsTen;
    
    public int CircusScoreTotal;
    public int CircusGamesPlayedTotal;
    public int MtnValleyScoreTotal;
    public int MtnValleyWinsTotal;

    private GameObject dataController;
    PlayerDataController playerData;

    // Use this for initialization
    void Start ()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();
    }

    public void UpdateAchievementsMenu()
    {
        playerData.Load();

        CircusScoreTotal = playerData.PlayerCircusTopScore;
        CircusGamesPlayedTotal = playerData.PlayerCircusPlays;
        MtnValleyScoreTotal = playerData.PlayerMountainVillageTopScore;
        MtnValleyWinsTotal = playerData.PlayerMtnValleyWins;

        CircusScore.text = CircusScoreTotal.ToString("d6");
        if (CircusScoreTotal >= 20000)
        {
            CircusScore.color = Color.green;
        }
        else { CircusScore.color = Color.red; }

        CircusGamesPlayed.text = CircusGamesPlayedTotal.ToString("d6");
        if (CircusGamesPlayedTotal >= 5)
        {
            CircusGamesPlayed.color = Color.green;
        }
        else { CircusGamesPlayed.color = Color.red; }

        MtnValleyWinsOne.text = MtnValleyWinsTotal.ToString("d6");
        if (MtnValleyWinsTotal >= 1)
        {
            MtnValleyWinsOne.color = Color.green;
        }
        else { MtnValleyWinsOne.color = Color.red; }

        MtnValleyScoreTen.text = MtnValleyScoreTotal.ToString("d6");
        if (MtnValleyScoreTotal >= 30000)
        {
            MtnValleyScoreTen.color = Color.green;
        }
        else { MtnValleyScoreTen.color = Color.red; }

        MtnValleyScoreTwenty.text = MtnValleyScoreTotal.ToString("d6");
        if (MtnValleyScoreTotal >= 20000)
        {
            MtnValleyScoreTwenty.color = Color.green;
        }
        else { MtnValleyScoreTwenty.color = Color.red; }

        MtnValleyWinsTen.text = MtnValleyWinsTotal.ToString("d6");
        if (MtnValleyWinsTotal >= 10)
        {
            MtnValleyWinsTen.color = Color.green;
        }
        else { MtnValleyWinsTen.color = Color.red; }
    }
}
