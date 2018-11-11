using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerGameTimer : MonoBehaviour
{
    public GameObject controller;
    public GameObject StartButton;
    public GameObject ExitButton;
    public GameObject AwardRedBall;
    public GameObject AwardCircusGoal;
    public bool gameStarted = false;
    public bool gameOver = false;
    public bool timerStarted = false;
    private float startTime;
    private float gameTime;
    public int gameTimeInt;
    private int previousGameTimeInt;
    public int totalGameTime;

    public Text spGameTime;
    public GameObject WarningSpeaker;
    public AudioClip WarningSound;

    private int GameMinutes;
    private int GameSeconds;
    private string Colon = ":";
    private string Minutes;
    private string Seconds;

    GameControllerSingle gameController;
    AudioSource WarningSpeakerSource;

    private GameObject dataController;
    PlayerDataController playerData;

    private GameObject scoreTracker;
    SingleplayerScoreTracker singlePlayerScore;

    // Use this for initialization
    void Start ()
    {
        gameController = controller.GetComponent<GameControllerSingle>();
        WarningSpeakerSource = WarningSpeaker.GetComponent<AudioSource>();

        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        scoreTracker = GameObject.Find("GameScoreController");
        singlePlayerScore = scoreTracker.GetComponent<SingleplayerScoreTracker>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameStarted)
        {
            if (!timerStarted)
            {
                startTime = Time.time;
                timerStarted = true;
                gameTimeInt = totalGameTime;
                previousGameTimeInt = totalGameTime;
            }
            else
            {
                gameTime = Time.time - startTime;
                gameTimeInt = totalGameTime - (int)gameTime;
            }

            if (gameTimeInt < previousGameTimeInt && gameTimeInt >= 0)
            {
                if (gameTimeInt / 60 >= 1)
                {
                    GameMinutes = (int)(gameTimeInt / 60);
                    GameSeconds = gameTimeInt - (GameMinutes * 60);
                }
                else if (gameTimeInt / 60 < 1 && gameTimeInt > 30)
                {
                    GameMinutes = 0;
                    GameSeconds = gameTimeInt;
                }
                else if (gameTimeInt / 60 < 1 && gameTimeInt > 10)
                {
                    spGameTime.color = Color.yellow;
                    GameMinutes = 0;
                    GameSeconds = gameTimeInt;
                }
                else if (gameTimeInt / 60 < 1 && gameTimeInt > 0)
                {
                    WarningSpeakerSource.PlayOneShot(WarningSound, 1f);
                    spGameTime.color = Color.red;
                    GameMinutes = 0;
                    GameSeconds = gameTimeInt;
                }
                else
                {
                    GameMinutes = 0;
                    GameSeconds = 0;
                }
                Minutes = GameMinutes.ToString();
                Seconds = GameSeconds.ToString("d2");
                spGameTime.text = Minutes + Colon + Seconds;

                previousGameTimeInt = gameTimeInt;
            }
            else if (gameTimeInt == 0)
            {
                gameStarted = false;
                gameOver = true;
            }
        }
        else
        {
            if (gameController.StartPauseTimerComplete)
            {
                spGameTime.color = Color.black;
                gameStarted = true;
            }
        }

        if (gameOver)
        {
            while (gameController.Balls.Count > 0)
            {
                Destroy(gameController.Balls[0]);
                gameController.Balls.RemoveAt(0);
            }

            gameStarted = false;
            timerStarted = false;
            gameController.PlayerReady = false;
            gameController.GameStarted = false;
            gameController.StartPauseTimerComplete = false;

            playerData.PlayerCircusPlays++;
            playerData.Save();

            if (playerData.PlayerCircusTopScore < 20000 && singlePlayerScore.PlayerScoreTotal >= 20000)
            {
                if (playerData.AllPlayerTwoBalls.Contains("Red"))
                {

                }
                else
                {
                    playerData.AllPlayerTwoBalls.Add("Red");
                    playerData.Save();
                    AwardRedBall.SetActive(true);
                    if (playerData.PlayerCircusPlays == 5)
                    {
                        StartCoroutine("PlayRedBallAwardBeforeCircusGoalAward");
                    }
                    else
                    {
                        StartCoroutine("PlayRedBallAwardOnly");
                    }
                }
            }

            if (singlePlayerScore.PlayerScoreTotal > playerData.PlayerCircusTopScore)
            {
                playerData.PlayerCircusTopScore = singlePlayerScore.PlayerScoreTotal;
                playerData.Save();
                singlePlayerScore.PlayerHiScoreTotal = playerData.PlayerCircusTopScore;
            }

            if (playerData.PlayerCircusPlays == 5)
            {
                if (playerData.AllPlayerGoals.Contains("Circus"))
                {

                }
                else
                {
                    playerData.AllPlayerGoals.Add("Circus");
                    playerData.Save();
                    if (playerData.PlayerCircusTopScore < 20000 && singlePlayerScore.PlayerScoreTotal >= 20000)
                    {

                    }
                    else
                    {

                        AwardCircusGoal.SetActive(true);
                        StartCoroutine("PlayCircusGoalAward");
                    }
                }
            }

            StartButton.SetActive(true);
            ExitButton.SetActive(true);
            gameOver = false;
        }
    }

    IEnumerator PlayRedBallAwardOnly()
    {
        yield return new WaitForSeconds(5f);
        AwardRedBall.SetActive(false);
    }

    IEnumerator PlayRedBallAwardBeforeCircusGoalAward()
    {
        yield return new WaitForSeconds(5f);
        AwardRedBall.SetActive(false);
        AwardCircusGoal.SetActive(true);
        StartCoroutine("PlayCircusGoalAward");
    }

    IEnumerator PlayCircusGoalAward()
    {
        yield return new WaitForSeconds(5f);
        AwardCircusGoal.SetActive(false);
    }
}
