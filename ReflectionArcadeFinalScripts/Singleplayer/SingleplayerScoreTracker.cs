using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleplayerScoreTracker : MonoBehaviour
{
    public Text ScoreText;
    public Text PlayerScore;
    public Text HiScoreText;
    public Text PlayerHiScore;
    public int PlayerScoreTotal = 0;
    public int PlayerHiScoreTotal;

    private string PlayerScoreString;
    private string PlayerHiScoreString;

    public bool isGameScoreShowing = false;
    private bool isHiScoreShowing = true;
    private bool isSwitchingScore = false;

    private GameObject dataController;
    PlayerDataController playerData;

    private GameObject gameController;
    GameControllerSingle singleController;

    // Use this for initialization
    void Start ()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        gameController = GameObject.Find("Game Controller");
        singleController = gameController.GetComponent<GameControllerSingle>();

        ScoreText.gameObject.SetActive(false);
        PlayerScore.gameObject.SetActive(false);

        PlayerHiScoreTotal = playerData.PlayerCircusTopScore;
        PlayerHiScoreString = PlayerHiScoreTotal.ToString("d6");
        PlayerHiScore.text = PlayerHiScoreString;
	}

    public void ScoreIncrease(int ScoreAddition)
    {
        PlayerScoreTotal += ScoreAddition;
        PlayerScoreString = PlayerScoreTotal.ToString("d6");
        PlayerScore.text = PlayerScoreString;
    }

    public void ScoreDecrease(int ScoreSubtraction)
    {
        PlayerScoreTotal -= ScoreSubtraction;
        PlayerScoreString = PlayerScoreTotal.ToString("d6");
        PlayerScore.text = PlayerScoreString;
    }

    public void ResetScores()
    {
        PlayerScoreTotal = 0;
        PlayerScoreString = PlayerScoreTotal.ToString("d6");
        PlayerScore.text = PlayerScoreString;
    }

    public void SetScoreTextForGamePlay()
    {
        StopCoroutine("SwitchToHiScore");
        StopCoroutine("SwitchToCurrentScore");
        ResetScores();
        HiScoreText.gameObject.SetActive(false);
        PlayerHiScore.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        PlayerScore.gameObject.SetActive(true);
    }

    void Update()
    {
        if (singleController.GameStarted)
        {
 
        }
        else
        {
            if (isHiScoreShowing)
            {
                if (!isSwitchingScore)
                {
                    isSwitchingScore = true;
                    StartCoroutine("SwitchToCurrentScore");
                }
            }
            else
            {
                if (!isSwitchingScore)
                {
                    isSwitchingScore = true;
                    StartCoroutine("SwitchToHiScore");
                }
            }
        }
    }

    IEnumerator SwitchToCurrentScore()
    {
        yield return new WaitForSeconds(5f);
        HiScoreText.gameObject.SetActive(false);
        PlayerHiScore.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        PlayerScore.gameObject.SetActive(true);
        isSwitchingScore = false;
        isHiScoreShowing = false;
    }

    IEnumerator SwitchToHiScore()
    {
        yield return new WaitForSeconds(5f);
        HiScoreText.gameObject.SetActive(true);
        PlayerHiScore.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        PlayerScore.gameObject.SetActive(false);
        isSwitchingScore = false;
        isHiScoreShowing = true;
    }

}
