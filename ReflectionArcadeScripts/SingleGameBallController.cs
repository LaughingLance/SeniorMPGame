using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGameBallController : MonoBehaviour
{
    private GameObject Score;
    SingleplayerScoreTracker ScoreTracker;
    private GameObject controller;
    GameControllerSingle gameController;
    Renderer rend;
    private int BallListPosition;
    private string PlayerOneBallMaterialString;
    public Material PlayerOneBallMaterial;

    private GameObject dataController;
    PlayerDataController playerData;

    private GameObject targetLauncherController;
    TargetPopSoundController TargetSoundController;

    private GameObject GoalController;
    OneShotSoundController OneShotGoalController;

    private GameObject StationaryTargets;
    OneShotSoundController OneShotStationaryScoreController;

    public Material Grape;
    public Material Gray;
    public Material Black;

    // Use this for initialization
    void Start()
    {
        StationaryTargets = GameObject.Find("StationaryScores");
        OneShotStationaryScoreController = StationaryTargets.GetComponent<OneShotSoundController>();

        GoalController = GameObject.Find("PlayerGoal");
        OneShotGoalController = GoalController.GetComponent<OneShotSoundController>();

        targetLauncherController = GameObject.Find("TargetLaunchers");
        TargetSoundController = targetLauncherController.GetComponent<TargetPopSoundController>();

        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        controller = GameObject.Find("Game Controller");
        gameController = controller.GetComponent<GameControllerSingle>();

        Score = GameObject.Find("GameScoreController");
        ScoreTracker = Score.GetComponent<SingleplayerScoreTracker>();

        rend = GetComponent<Renderer>();        
        GetComponent<Rigidbody>().AddForce(transform.up * 10, ForceMode.Impulse);

        PlayerOneBallMaterialString = playerData.PlayerOneBallMaterial;

        switch (PlayerOneBallMaterialString)
        {
            case "Grape":
                PlayerOneBallMaterial = Grape;
                break;
            case "Gray":
                PlayerOneBallMaterial = Gray;
                break;
            case "Black":
                PlayerOneBallMaterial = Black;
                break;
        }
    }
    
    private void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "PlayerOne":
                if (gameObject.tag == "NeutralBall")
                {
                    gameObject.tag = "PlayerOneBall";
                    rend.material = PlayerOneBallMaterial;
                    ScoreTracker.ScoreIncrease(10);
                }
                else 
                {
                    ScoreTracker.ScoreIncrease(5);
                }
                break;
            case "PlayerOneBase":
                if (gameObject.tag == "PlayerOneBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    OneShotGoalController.PlaySoundOneShot();
                    ScoreTracker.ScoreDecrease(25);
                    Destroy(gameObject);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    OneShotGoalController.PlaySoundOneShot();
                    ScoreTracker.ScoreDecrease(50);
                    Destroy(gameObject);
                }
                break;
            case "MovingTarget":
                if (gameObject.tag == "PlayerOneBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.ScoreIncrease(1000);
                    TargetSoundController.PlayPopSound();
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.ScoreIncrease(100);
                    TargetSoundController.PlayPopSound();
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                }
                break;
            case "BallDestroyer":
                Destroy(gameObject);
                break;
        }

        switch (col.gameObject.name)
        {
            case "50":
                ScoreTracker.ScoreIncrease(50);
                OneShotStationaryScoreController.PlaySoundOneShot();
                Destroy(gameObject);
                break;
            case "100":
                ScoreTracker.ScoreIncrease(100);
                OneShotStationaryScoreController.PlaySoundOneShot();
                Destroy(gameObject);
                break;
            case "500":
                ScoreTracker.ScoreIncrease(500);
                OneShotStationaryScoreController.PlaySoundOneShot();
                Destroy(gameObject);
                break;
        }
    }
    
}
