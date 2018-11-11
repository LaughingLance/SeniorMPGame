using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkScoreTracker : MonoBehaviour
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
    
    private string PlayerOneScoreString;
    private string PlayerTwoScoreString;
    private string PlayerOneName = "Player 1";
    private string PlayerTwoName = "Player 2";


	// Use this for initialization
	void Start ()
    {
        PlayerOneScoreString = PlayerOneScore.ToString("d6");
        PlayerTwoScoreString = PlayerTwoScore.ToString("d6");
        PlayerOneSelfScore.text = PlayerOneScoreString;
        PlayerOneOpponentScore.text = PlayerTwoScoreString;
        PlayerTwoSelfScore.text = PlayerTwoScoreString;
        PlayerTwoOpponentScore.text = PlayerOneScoreString;
        PlayerOneSelfName.text = PlayerOneName;
        PlayerOneOpponentName.text = PlayerTwoName;
        PlayerTwoSelfName.text = PlayerTwoName;
        PlayerTwoOpponentName.text = PlayerOneName;
    }

    public void PlayerOneScoreIncrease(int ScoreAddition)
    {
        PlayerOneScore += ScoreAddition;
        PlayerOneScoreString = PlayerOneScore.ToString("d6");
        PlayerOneSelfScore.text = PlayerOneScoreString;
        PlayerTwoOpponentScore.text = PlayerOneScoreString;
    }

    public void PlayerOneScoreDecrease(int ScoreSubtraction)
    {
        PlayerOneScore -= ScoreSubtraction;
        PlayerOneScoreString = PlayerOneScore.ToString("d6");
        PlayerOneSelfScore.text = PlayerOneScoreString;
        PlayerTwoOpponentScore.text = PlayerOneScoreString;
    }

    public void PlayerTwoScoreIncrease(int ScoreAddition)
    {
        PlayerTwoScore += ScoreAddition;
        PlayerTwoScoreString = PlayerTwoScore.ToString("d6");
        PlayerTwoSelfScore.text = PlayerTwoScoreString;
        PlayerOneOpponentScore.text = PlayerTwoScoreString;
    }

    public void PlayerTwoScoreDecrease(int ScoreSubtraction)
    {
        PlayerTwoScore -= ScoreSubtraction;
        PlayerTwoScoreString = PlayerTwoScore.ToString("d6");
        PlayerTwoSelfScore.text = PlayerTwoScoreString;
        PlayerOneOpponentScore.text = PlayerTwoScoreString;
    }
}
