using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkScoreTracker : NetworkBehaviour
{
    public Text PlayerOneSelfName;
    public Text PlayerOneOpponentName;
    public Text PlayerTwoSelfName;
    public Text PlayerTwoOpponentName;
    public Text PlayerOneSelfScore;
    public Text PlayerOneOpponentScore;
    public Text PlayerTwoSelfScore;
    public Text PlayerTwoOpponentScore;
    public int PlayerOneScore = 0;
    public int PlayerTwoScore = 0;

    public string GameWinner;
    
    private string PlayerOneScoreString;
    private string PlayerTwoScoreString;
    private string PlayerOneNameTemp = "Player 1";
    private string PlayerTwoNameTemp = "Player 2";

    private GameObject PlayerOne;
    Player playerOne;
    public string PlayerOneName;

    private GameObject PlayerTwo;
    Player playerTwo;
    public string PlayerTwoName;

    private GameObject controller;
    GameController gameController;

    // Use this for initialization
    void Start ()
    {
        controller = GameObject.Find("Game Controller");
        gameController = controller.GetComponent<GameController>();

        PlayerOneScoreString = PlayerOneScore.ToString("d6");
        PlayerTwoScoreString = PlayerTwoScore.ToString("d6");
        PlayerOneSelfScore.text = PlayerOneScoreString;
        PlayerOneOpponentScore.text = PlayerTwoScoreString;
        PlayerTwoSelfScore.text = PlayerTwoScoreString;
        PlayerTwoOpponentScore.text = PlayerOneScoreString;
        PlayerOneSelfName.text = PlayerOneNameTemp;
        PlayerOneOpponentName.text = PlayerTwoNameTemp;
        PlayerTwoSelfName.text = PlayerTwoNameTemp;
        PlayerTwoOpponentName.text = PlayerOneNameTemp;
    }

    public void PlayerOneScoreIncrease(int ScoreAddition)
    {
        PlayerOneScore += ScoreAddition;
        PlayerOneScoreString = PlayerOneScore.ToString("d6");
        RpcScoresUpdaterPlayerOne();
        if (PlayerOneScore > PlayerTwoScore)
        {
            GameWinner = "PlayerOne";
        }
        else if (PlayerTwoScore > PlayerOneScore)
        {
            GameWinner = "PlayerTwo";
        }
    }

    public void PlayerOneScoreDecrease(int ScoreSubtraction)
    {
        PlayerOneScore -= ScoreSubtraction;
        PlayerOneScoreString = PlayerOneScore.ToString("d6");
        RpcScoresUpdaterPlayerOne();
        if (PlayerOneScore > PlayerTwoScore)
        {
            GameWinner = "PlayerOne";
        }
        else if (PlayerTwoScore > PlayerOneScore)
        {
            GameWinner = "PlayerTwo";
        }
    }

    public void PlayerTwoScoreIncrease(int ScoreAddition)
    {
        PlayerTwoScore += ScoreAddition;
        PlayerTwoScoreString = PlayerTwoScore.ToString("d6");
        RpcScoresUpdaterPlayerTwo();
        if (PlayerOneScore > PlayerTwoScore)
        {
            GameWinner = "PlayerOne";
        }
        else if (PlayerTwoScore > PlayerOneScore)
        {
            GameWinner = "PlayerTwo";
        }
    }

    public void PlayerTwoScoreDecrease(int ScoreSubtraction)
    {
        PlayerTwoScore -= ScoreSubtraction;
        PlayerTwoScoreString = PlayerTwoScore.ToString("d6");
        RpcScoresUpdaterPlayerTwo();
        if (PlayerOneScore > PlayerTwoScore)
        {
            GameWinner = "PlayerOne";
        }
        else if (PlayerTwoScore > PlayerOneScore)
        {
            GameWinner = "PlayerTwo";
        }
    }

    [ClientRpc]
    public void RpcScoresUpdaterPlayerOne()
    {
        PlayerOneSelfScore.text = PlayerOneScoreString;
        PlayerTwoOpponentScore.text = PlayerOneScoreString;
    }

    [ClientRpc]
    public void RpcScoresUpdaterPlayerTwo()
    {
        PlayerTwoSelfScore.text = PlayerTwoScoreString;
        PlayerOneOpponentScore.text = PlayerTwoScoreString;
    }

    [ClientRpc]
    public void RpcPlayerOnesName()
    {
        PlayerOne = gameController.Players[0];
        playerOne = PlayerOne.GetComponent<Player>();
        PlayerOneName = playerOne.PlayerName;

        PlayerOneSelfName.text = PlayerOneName;
        PlayerTwoOpponentName.text = PlayerOneName;
    }

    [ClientRpc]
    public void RpcPlayerTwosName()
    {
        PlayerTwo = gameController.Players[1];
        playerTwo = PlayerTwo.GetComponent<Player>();
        PlayerTwoName = playerTwo.PlayerName;

        PlayerTwoSelfName.text = PlayerTwoName;
        PlayerOneOpponentName.text = PlayerTwoName;
    }
}
