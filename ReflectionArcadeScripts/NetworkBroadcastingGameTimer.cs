using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkBroadcastingGameTimer : MonoBehaviour
{
    public GameObject controller;
    public GameObject PlayerOneExitButton;
    public GameObject PlayerTwoExitButton;
    public bool gameStarted = false;
    public bool gameOver = false;
    private bool timerStarted = false;
    private float startTime;
    private float gameTime;
    public int gameTimeInt;
    private int previousGameTimeInt;
    public int totalGameTime;

    public delegate void TimeChange();
    public static event TimeChange OnTimeChange;

    GameController gameController;

	// Use this for initialization
	void Start ()
    {
        gameController = controller.GetComponent<GameController>();
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
                previousGameTimeInt = gameTimeInt;
                if (OnTimeChange != null)
                {
                    OnTimeChange();
                }
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
            PlayerOneExitButton.SetActive(true);
            PlayerTwoExitButton.SetActive(true);
        }        
	}
}
