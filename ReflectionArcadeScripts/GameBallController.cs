using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallController : MonoBehaviour
{
    private GameObject Score;
    private GameObject controller;
    NetworkScoreTracker ScoreTracker;
    GameController gameController;
    Renderer rend;
    Player playerOne;
 //   Player playerTwo;
    private int BallListPosition;
    public Material PlayerOneBallMaterial;
 //   public Material PlayerTwoBallMaterial;
    private GameObject PlayerOne;
 //   private GameObject PlayerTwo;

	// Use this for initialization
	void Start ()
    {
        controller = GameObject.Find("Game Controller");
        gameController = controller.GetComponent<GameController>();
        Score = GameObject.Find("GameScoreController");
        ScoreTracker = Score.GetComponent<NetworkScoreTracker>();
        rend = GetComponent<Renderer>();
        PlayerOne = gameController.Players[0];
  //      PlayerTwo = gameController.Players[1];
        playerOne = PlayerOne.GetComponent<Player>();
    //    playerTwo = PlayerTwo.GetComponent<Player>();
        PlayerOneBallMaterial = playerOne.PlayerBallMaterial;
    //    PlayerTwoBallMaterial = playerTwo.PlayerBallMaterial;
        GetComponent<Rigidbody>().AddForce(transform.up * 10, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "PlayerOne":
                if (gameObject.tag == "PlayerTwoBall")
                {
                    gameObject.tag = "PlayerOneBall";
                    rend.material = PlayerOneBallMaterial;
                    ScoreTracker.PlayerOneScoreIncrease(50);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    gameObject.tag = "PlayerOneBall";
                    rend.material = PlayerOneBallMaterial;
                    ScoreTracker.PlayerOneScoreIncrease(25);
                }
                else if (gameObject.tag == "PlayerOneBall")
                {
                    ScoreTracker.PlayerOneScoreIncrease(5);
                }
                break;
            case "PlayerTwo":
                if (gameObject.tag == "PlayerOneBall")
                {
                    gameObject.tag = "PlayerTwoBall";
            //        rend.material = PlayerTwoBallMaterial;
                    ScoreTracker.PlayerTwoScoreIncrease(50);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    gameObject.tag = "PlayerTwoBall";
            //        rend.material = PlayerTwoBallMaterial;
                    ScoreTracker.PlayerTwoScoreIncrease(25);
                }
                else if (gameObject.tag == "PlayerTwoBall")
                {
                    ScoreTracker.PlayerTwoScoreIncrease(5);
                }
                break;
            case "PlayerOneBase":
                if (gameObject.tag == "PlayerOneBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerOneScoreDecrease(100);
                    Destroy(gameObject);
                }
                else if (gameObject.tag == "PlayerTwoBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerTwoScoreIncrease(1000);
                    Destroy(gameObject);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerOneScoreDecrease(250);
                    Destroy(gameObject);
                }
                break;
            case "PlayerTwoBase":
                if (gameObject.tag == "PlayerOneBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerOneScoreIncrease(1000);
                    Destroy(gameObject);
                }
                else if (gameObject.tag == "PlayerTwoBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerTwoScoreDecrease(100);
                    Destroy(gameObject);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerTwoScoreDecrease(250);
                    Destroy(gameObject);
                }
                break;            
        }
    }
}
