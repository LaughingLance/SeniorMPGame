using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSelectorController : MonoBehaviour
{
    public List<GameObject> PlayerGoalsList = new List<GameObject>();
    public GameObject GoalOnDisplay;
    public GameObject Goal_WhiteStripesOnYellow;
    public GameObject Goal_Rainbow;
    public GameObject Goal_Circus;
    public GameObject Goal_Mountains;
    public GameObject Goal_PirateFlag;

    public bool switchingGoal = false;
    private int currentlySelectedGoalID;

    private GameObject dataController;
    PlayerDataController playerData;


    // Use this for initialization
    void Start()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();
        
        for (int i = 0; i < PlayerGoalsList.Count; i++)
        {
            PlayerGoalsList[i].SetActive(false);
        }

        currentlySelectedGoalID = playerData.AllPlayerGoals.IndexOf(playerData.PlayerGoal);
        DetermineNewlySelectedGoal(currentlySelectedGoalID);
        GoalOnDisplay.SetActive(true);
    }

    public void RotateGoalRight()
    {
        if (switchingGoal)
        {
            GoalOnDisplay.SetActive(false);
            StartCoroutine("GoalRotationRightTimer");
        }
    }

    IEnumerator GoalRotationRightTimer()
    {
        yield return new WaitForSeconds(0.25f);
        if (currentlySelectedGoalID == playerData.AllPlayerGoals.Count - 1)
        {
            currentlySelectedGoalID = 0;
            DetermineNewlySelectedGoal(currentlySelectedGoalID);
            GoalOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedGoalID++;
            DetermineNewlySelectedGoal(currentlySelectedGoalID);
            GoalOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    public void RotateGoalLeft()
    {
        if (switchingGoal)
        {
            GoalOnDisplay.SetActive(false);
            StartCoroutine("GoalRotationLeftTimer");
        }
    }

    IEnumerator GoalRotationLeftTimer()
    {
        yield return new WaitForSeconds(0.25f);
        if (currentlySelectedGoalID == 0)
        {
            currentlySelectedGoalID = playerData.AllPlayerGoals.Count - 1;
            DetermineNewlySelectedGoal(currentlySelectedGoalID);
            GoalOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedGoalID--;
            DetermineNewlySelectedGoal(currentlySelectedGoalID);
            GoalOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    IEnumerator ReactivateButtons()
    {
        yield return new WaitForSeconds(0.75f);
        switchingGoal = false;
    }

    private void DetermineNewlySelectedGoal(int newListPosition)
    {
        switch (playerData.AllPlayerGoals[newListPosition])
        {
            case "WhiteStripesOnYellow":
                playerData.PlayerGoal = playerData.AllPlayerGoals[newListPosition];
                playerData.Save();
                GoalOnDisplay = Goal_WhiteStripesOnYellow;
                break;
            case "Rainbow":
                playerData.PlayerGoal = playerData.AllPlayerGoals[newListPosition];
                playerData.Save();
                GoalOnDisplay = Goal_Rainbow;
                break;
            case "Circus":
                playerData.PlayerGoal = playerData.AllPlayerGoals[newListPosition];
                playerData.Save();
                GoalOnDisplay = Goal_Circus;
                break;
            case "Mountains":
                playerData.PlayerGoal = playerData.AllPlayerGoals[newListPosition];
                playerData.Save();
                GoalOnDisplay = Goal_Mountains;
                break;
            case "PirateFlag":
                playerData.PlayerGoal = playerData.AllPlayerGoals[newListPosition];
                playerData.Save();
                GoalOnDisplay = Goal_PirateFlag;
                break;
        }
    }
}
