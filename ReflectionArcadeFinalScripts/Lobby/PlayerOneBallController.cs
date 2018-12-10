using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneBallController : MonoBehaviour
{
    public List<GameObject> PlayerTwoBallsList = new List<GameObject>();
    public GameObject BallOnDisplay;
    public bool switchingBall = false;
    private int currentlySelectedBallID;

    // Use this for initialization
    void Start()
    {
        BallOnDisplay = PlayerTwoBallsList[0];
        currentlySelectedBallID = 0;
        for (int i = 0; i < PlayerTwoBallsList.Count; i++)
        {
            PlayerTwoBallsList[i].SetActive(false);
        }
        BallOnDisplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        BallOnDisplay.transform.Rotate(Vector3.forward * 4 * Time.deltaTime);
    }

    public void RemoveOldBallRight()
    {
        if (switchingBall)
        {
            BallOnDisplay.SetActive(false);
            StartCoroutine("ReplaceNewBallRight");
        }
    }

    IEnumerator ReplaceNewBallRight()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedBallID == PlayerTwoBallsList.Count - 1)
        {
            currentlySelectedBallID = 0;
            BallOnDisplay = PlayerTwoBallsList[currentlySelectedBallID];
            BallOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedBallID++;
            BallOnDisplay = PlayerTwoBallsList[currentlySelectedBallID];
            BallOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    public void RemoveOldBallLeft()
    {
        if (switchingBall)
        {
            BallOnDisplay.SetActive(false);
            StartCoroutine("ReplaceNewBallLeft");
        }
    }

    IEnumerator ReplaceNewBallLeft()
    {
        yield return new WaitForSeconds(1f);
        if (currentlySelectedBallID == 0)
        {
            currentlySelectedBallID = 0;
            BallOnDisplay = PlayerTwoBallsList[currentlySelectedBallID];
            BallOnDisplay.SetActive(true);
        }
        else
        {
            currentlySelectedBallID--;
            BallOnDisplay = PlayerTwoBallsList[currentlySelectedBallID];
            BallOnDisplay.SetActive(true);
        }
        StartCoroutine("ReactivateButtons");
    }

    IEnumerable ReactivateButtons()
    {
        yield return new WaitForSeconds(1f);
        switchingBall = false;
    }
}
