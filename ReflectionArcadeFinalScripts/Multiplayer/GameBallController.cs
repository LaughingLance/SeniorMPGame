using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameBallController : NetworkBehaviour
{
    private GameObject Score;
    private GameObject controller;
    NetworkScoreTracker ScoreTracker;
    GameController gameController;
    Renderer rend;

    public AudioClip ThunderClip;
    AudioSource SpeakerSource;
    
    private int BallListPosition;

    private GameObject PlayerOne;
    Player playerOne;
    public Material PlayerOneBallMaterial;

    private GameObject PlayerTwo;
    Player playerTwo;
    public Material PlayerTwoBallMaterial;

    // Use this for initialization
    void Start ()
    {
        SpeakerSource = GameObject.Find("CenterSoundSource").GetComponent<AudioSource>();

        controller = GameObject.Find("Game Controller");
        gameController = controller.GetComponent<GameController>();
        Score = GameObject.Find("GameScoreController");
        ScoreTracker = Score.GetComponent<NetworkScoreTracker>();
        rend = GetComponent<Renderer>();

        PlayerOne = gameController.Players[0];
        playerOne = PlayerOne.GetComponent<Player>();
        PlayerOneBallMaterial = playerOne.PlayerBallMaterial;

        PlayerTwo = gameController.Players[1];
        playerTwo = PlayerTwo.GetComponent<Player>();
        PlayerTwoBallMaterial = playerTwo.PlayerBallMaterial;

        GetComponent<Rigidbody>().AddForce(transform.up * 10, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "PlayerOne":
                if (gameObject.tag == "PlayerTwoBall")
                {
                    playerOne.GetComponent<PlayerWeaponSwapNetwork>().PlayWeaponHitSound();
                    RpcChangeBallColorPlayerOne();
                    ScoreTracker.PlayerOneScoreIncrease(50);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    playerOne.GetComponent<PlayerWeaponSwapNetwork>().PlayWeaponHitSound();
                    RpcChangeBallColorPlayerOne();
                    ScoreTracker.PlayerOneScoreIncrease(25);
                }
                else if (gameObject.tag == "PlayerOneBall")
                {
                    playerOne.GetComponent<PlayerWeaponSwapNetwork>().PlayWeaponHitSound();
                    ScoreTracker.PlayerOneScoreIncrease(5);
                }
                break;
            case "PlayerTwo":
                if (gameObject.tag == "PlayerOneBall")
                {
                    playerTwo.GetComponent<PlayerWeaponSwapNetwork>().PlayWeaponHitSound();
                    RpcChangeBallColorPlayerTwo();
                    ScoreTracker.PlayerTwoScoreIncrease(50);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    playerTwo.GetComponent<PlayerWeaponSwapNetwork>().PlayWeaponHitSound();
                    RpcChangeBallColorPlayerTwo();
                    ScoreTracker.PlayerTwoScoreIncrease(25);
                }
                else if (gameObject.tag == "PlayerTwoBall")
                {
                    playerTwo.GetComponent<PlayerWeaponSwapNetwork>().PlayWeaponHitSound();
                    ScoreTracker.PlayerTwoScoreIncrease(5);
                }
                break;
            case "PlayerOneBase":
                if (gameObject.tag == "PlayerOneBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerOneScoreDecrease(100);
                    NetworkServer.Destroy(gameObject);
                }
                else if (gameObject.tag == "PlayerTwoBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerTwoScoreIncrease(1000);
                    NetworkServer.Destroy(gameObject);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerOneScoreDecrease(250);
                    NetworkServer.Destroy(gameObject);
                }
                break;
            case "PlayerTwoBase":
                if (gameObject.tag == "PlayerOneBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerOneScoreIncrease(1000);
                    NetworkServer.Destroy(gameObject);
                }
                else if (gameObject.tag == "PlayerTwoBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerTwoScoreDecrease(100);
                    NetworkServer.Destroy(gameObject);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    BallListPosition = gameController.Balls.IndexOf(gameObject);
                    gameController.Balls.RemoveAt(BallListPosition);
                    ScoreTracker.PlayerTwoScoreDecrease(250);
                    NetworkServer.Destroy(gameObject);
                }
                break;
            case "MovingTarget":
                if (gameObject.tag == "PlayerOneBall")
                {
                    SpeakerSource.PlayOneShot(ThunderClip, 1f);
                    ScoreTracker.PlayerOneScoreIncrease(500);
                    NetworkServer.Destroy(col.gameObject);
                    NetworkServer.Destroy(gameObject);
                }
                else if (gameObject.tag == "PlayerTwoBall")
                {
                    SpeakerSource.PlayOneShot(ThunderClip, 1f);
                    ScoreTracker.PlayerTwoScoreIncrease(500);
                    NetworkServer.Destroy(col.gameObject);
                    NetworkServer.Destroy(gameObject);
                }
                else if (gameObject.tag == "NeutralBall")
                {
                    NetworkServer.Destroy(col.gameObject);
                }
                break;
        }
    }

    [ClientRpc]
    void RpcChangeBallColorPlayerOne()
    {
        gameObject.tag = "PlayerOneBall";
        rend.material = PlayerOneBallMaterial;
    }

    [ClientRpc]
    void RpcChangeBallColorPlayerTwo()
    {
        gameObject.tag = "PlayerTwoBall";
        rend.material = PlayerTwoBallMaterial;
    }
}
