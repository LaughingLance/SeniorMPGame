using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    public List<GameObject> PlayerOneBallsList = new List<GameObject>();
    public List<GameObject> PlayerTwoBallsList = new List<GameObject>();
    public GameObject PlayerOneBallOnDisplay;
    public GameObject PlayerTwoBallOnDisplay;
    public bool switchingBall = false;
    private int currentlySelectedPlayerOneBallID;
    private int currentlySelectedPlayerTwoBallID;
    public string ballBeingSwitched;

    public GameObject Ball_Grape;
    public GameObject Ball_Gray;
    public GameObject Ball_Black;
    public GameObject Ball_Brown;
    public GameObject Ball_Yellow;
    public GameObject Ball_Red;

    private GameObject dataController;
    PlayerDataController playerData;

    // Use this for initialization
    void Start ()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();
                
        for (int i = 0; i < PlayerOneBallsList.Count; i++)
        {
            PlayerOneBallsList[i].SetActive(false);
        }

        currentlySelectedPlayerOneBallID = playerData.AllPlayerOneBalls.IndexOf(playerData.PlayerOneBallMaterial);
        DetermineNewlySelectedPlayerOneBall(currentlySelectedPlayerOneBallID);
        PlayerOneBallOnDisplay.SetActive(true);


        for (int i = 0; i < PlayerTwoBallsList.Count; i++)
        {
            PlayerTwoBallsList[i].SetActive(false);
        }

        currentlySelectedPlayerTwoBallID = playerData.AllPlayerTwoBalls.IndexOf(playerData.PlayerTwoBallMaterial);
        DetermineNewlySelectedPlayerTwoBall(currentlySelectedPlayerTwoBallID);
        PlayerTwoBallOnDisplay.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerOneBallOnDisplay.transform.Rotate(Vector3.up * -4 * Time.deltaTime);
        PlayerTwoBallOnDisplay.transform.Rotate(Vector3.up * -4 * Time.deltaTime);
    }

    public void RemoveOldBallRight()
    {
        if (switchingBall)
        {
            if (ballBeingSwitched == "PlayerOne")
            {
                PlayerOneBallOnDisplay.SetActive(false);
                StartCoroutine("ReplaceNewPlayerOneBallRight");
            }
            else if (ballBeingSwitched == "PlayerTwo")
            {
                PlayerTwoBallOnDisplay.SetActive(false);
                StartCoroutine("ReplaceNewPlayerTwoBallRight");
            }
        }
    }

    IEnumerator ReplaceNewPlayerOneBallRight()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedPlayerOneBallID == playerData.AllPlayerOneBalls.Count - 1)
        {
            currentlySelectedPlayerOneBallID = 0;
            DetermineNewlySelectedPlayerOneBall(currentlySelectedPlayerOneBallID);
            PlayerOneBallOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedPlayerOneBallID++;
            DetermineNewlySelectedPlayerOneBall(currentlySelectedPlayerOneBallID);
            PlayerOneBallOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    IEnumerator ReplaceNewPlayerTwoBallRight()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedPlayerTwoBallID == playerData.AllPlayerTwoBalls.Count - 1)
        {
            currentlySelectedPlayerTwoBallID = 0;
            DetermineNewlySelectedPlayerTwoBall(currentlySelectedPlayerTwoBallID);
            PlayerTwoBallOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedPlayerTwoBallID++;
            DetermineNewlySelectedPlayerTwoBall(currentlySelectedPlayerTwoBallID);
            PlayerTwoBallOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    public void RemoveOldBallLeft()
    {
        if (switchingBall)
        {
            if (ballBeingSwitched == "PlayerOne")
            {
                PlayerOneBallOnDisplay.SetActive(false);
                StartCoroutine("ReplaceNewPlayerOneBallLeft");
            }
            else if (ballBeingSwitched == "PlayerTwo")
            {
                PlayerTwoBallOnDisplay.SetActive(false);
                StartCoroutine("ReplaceNewPlayerTwoBallLeft");
            }
        }
    }

    IEnumerator ReplaceNewPlayerOneBallLeft()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedPlayerOneBallID == 0)
        {
            currentlySelectedPlayerOneBallID = playerData.AllPlayerOneBalls.Count - 1;
            DetermineNewlySelectedPlayerOneBall(currentlySelectedPlayerOneBallID);
            PlayerOneBallOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedPlayerOneBallID--;
            DetermineNewlySelectedPlayerOneBall(currentlySelectedPlayerOneBallID);
            PlayerOneBallOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    IEnumerator ReplaceNewPlayerTwoBallLeft()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedPlayerTwoBallID == 0)
        {
            currentlySelectedPlayerTwoBallID = playerData.AllPlayerTwoBalls.Count - 1;
            DetermineNewlySelectedPlayerTwoBall(currentlySelectedPlayerTwoBallID);
            PlayerTwoBallOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedPlayerTwoBallID--;
            DetermineNewlySelectedPlayerTwoBall(currentlySelectedPlayerTwoBallID);
            PlayerTwoBallOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    IEnumerator ReactivateButtons()
    {
        yield return new WaitForSeconds(0.25f);
        switchingBall = false;
    }


    private void DetermineNewlySelectedPlayerOneBall(int newPlayerOneBallPosition)
    {
        switch (playerData.AllPlayerOneBalls[newPlayerOneBallPosition])
        {
            case "Grape":
                playerData.PlayerOneBallMaterial = playerData.AllPlayerOneBalls[newPlayerOneBallPosition];
                playerData.Save();
                PlayerOneBallOnDisplay = Ball_Grape;
                break;
            case "Gray":
                playerData.PlayerOneBallMaterial = playerData.AllPlayerOneBalls[newPlayerOneBallPosition];
                playerData.Save();
                PlayerOneBallOnDisplay = Ball_Gray;
                break;
            case "Black":
                playerData.PlayerOneBallMaterial = playerData.AllPlayerOneBalls[newPlayerOneBallPosition];
                playerData.Save();
                PlayerOneBallOnDisplay = Ball_Black;
                break;
        }
    }

    private void DetermineNewlySelectedPlayerTwoBall(int newPlayerTwoBallPosition)
    {
        switch (playerData.AllPlayerTwoBalls[newPlayerTwoBallPosition])
        {
            case "Brown":
                playerData.PlayerTwoBallMaterial = playerData.AllPlayerTwoBalls[newPlayerTwoBallPosition];
                playerData.Save();
                PlayerTwoBallOnDisplay = Ball_Brown;
                break;
            case "Yellow":
                playerData.PlayerTwoBallMaterial = playerData.AllPlayerTwoBalls[newPlayerTwoBallPosition];
                playerData.Save();
                PlayerTwoBallOnDisplay = Ball_Yellow;
                break;
            case "Red":
                playerData.PlayerTwoBallMaterial = playerData.AllPlayerTwoBalls[newPlayerTwoBallPosition];
                playerData.Save();
                PlayerTwoBallOnDisplay = Ball_Red;
                break;
        }
    }
}
