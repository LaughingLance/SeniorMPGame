using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    public List<GameObject> Players = new List<GameObject>();
    public List<Transform> PlayerOneBallLaunchPositions = new List<Transform>();
    public List<Transform> PlayerTwoBallLaunchPositions = new List<Transform>();
    public List<GameObject> Balls = new List<GameObject>();

    public GameObject BallPrefab;
    public GameObject BottomSpeaker;
    public GameObject TopSpeaker;
    public GameObject LeftSpeaker;
    public GameObject RightSpeaker;
    public AudioClip CannonFire;

    public bool PlayerOneReady = false;
    public bool PlayerTwoReady = false;
    public bool GameStarted = false;
    public bool StartPauseTimerComplete = false;

    AudioSource BottomSpeakerSource;
    AudioSource TopSpeakerSource;
    AudioSource LeftSpeakerSource;
    AudioSource RightSpeakerSource;

    public GameObject GameTimer;
    NetworkBroadcastingGameTimer BroadcastingGameTimer;

    private float BallLastLaunchedTime;
    private float RandomBallLaunchDelayTime;

    private int CurrentLaunchPosition;
    
    NetworkScoreTracker ScoreTracker;

	// Use this for initialization
	void Start ()
    {
        ScoreTracker = GameObject.Find("GameScoreController").GetComponent<NetworkScoreTracker>();

        RandomBallLaunchDelayTime = Random.Range(1f, 4f);
        BallLastLaunchedTime = Time.time;
        BottomSpeakerSource = BottomSpeaker.GetComponent<AudioSource>();
        TopSpeakerSource = TopSpeaker.GetComponent<AudioSource>();
        LeftSpeakerSource = LeftSpeaker.GetComponent<AudioSource>();
        RightSpeakerSource = RightSpeaker.GetComponent<AudioSource>();
        BroadcastingGameTimer = GameTimer.GetComponent<NetworkBroadcastingGameTimer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerOneReady && PlayerTwoReady)
        {
            if (!BroadcastingGameTimer.gameOver)
            {
                if (GameStarted)
                {
                    if (StartPauseTimerComplete)
                    {
                        if (RandomBallLaunchDelayTime < Time.time - BallLastLaunchedTime)
                        {
                            // Launch a ball at PlayerOne
                            CmdFireAtPlayerOne();

                            // Launch a ball at PlayerTwo
                            CmdFireAtPlayerTwo();

                            RandomBallLaunchDelayTime = Random.Range(3f, 10f);
                            BallLastLaunchedTime = Time.time;
                        }
                    }
                }
                else
                {
                    Debug.Log("Am I here");
                    Players[0].GetComponent<PlayerWeaponSwapNetwork>().RpcWeaponInitialUpdatePlayerOne();
                    Players[1].GetComponent<PlayerWeaponSwapNetwork>().RpcWeaponInitialUpdatePlayerTwo();
                    Players[0].GetComponent<Player>().RpcInitialGoalSetupPlayerOne();
                    Players[1].GetComponent<Player>().RpcInitialGoalSetupPlayerTwo();
                    ScoreTracker.RpcPlayerOnesName();
                    ScoreTracker.RpcPlayerTwosName();
                    ScoreTracker.RpcScoresUpdaterPlayerOne();
                    ScoreTracker.RpcScoresUpdaterPlayerTwo();
                    StartCoroutine("StartDelayTimer");
                    GameStarted = true;
                }
            }
        }		
	}

    IEnumerator StartDelayTimer()
    {
        yield return new WaitForSeconds(5f);
        StartPauseTimerComplete = true;
    }

    private void PlayLaunchSound()
    {
        switch (CurrentLaunchPosition)
        {
            case 0:
                BottomSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
            case 1:
                TopSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
            case 2:
                LeftSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
            case 3:
                RightSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
        }
    }

    [Command]
    void CmdFireAtPlayerOne()
    {
        CurrentLaunchPosition = Random.Range(0, (PlayerOneBallLaunchPositions.Count - 1));
        var ballOne = (GameObject)Instantiate(BallPrefab, PlayerOneBallLaunchPositions[CurrentLaunchPosition].position, PlayerOneBallLaunchPositions[CurrentLaunchPosition].rotation);
        Balls.Add(ballOne);
        NetworkServer.Spawn(ballOne);
        PlayLaunchSound();
    }
    
    [Command]
    void CmdFireAtPlayerTwo()
    {
        CurrentLaunchPosition = Random.Range(0, (PlayerTwoBallLaunchPositions.Count - 1));
        var ballTwo = (GameObject)Instantiate(BallPrefab, PlayerTwoBallLaunchPositions[CurrentLaunchPosition].position, PlayerTwoBallLaunchPositions[CurrentLaunchPosition].rotation);
        Balls.Add(ballTwo);
        NetworkServer.Spawn(ballTwo);
        PlayLaunchSound();
    }
}
