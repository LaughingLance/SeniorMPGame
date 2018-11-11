using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
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

	// Use this for initialization
	void Start ()
    {
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
                            CurrentLaunchPosition = Random.Range(0, (PlayerOneBallLaunchPositions.Count - 1));
                            var ballOne = (GameObject)Instantiate(BallPrefab, PlayerOneBallLaunchPositions[CurrentLaunchPosition].position, PlayerOneBallLaunchPositions[CurrentLaunchPosition].rotation);
                            Balls.Add(ballOne);
                            ballOne.SetActive(true);
                            PlayLaunchSound();

                            // Launch a ball at PlayerTwo
                            CurrentLaunchPosition = Random.Range(0, (PlayerTwoBallLaunchPositions.Count - 1));
                            var ballTwo = (GameObject)Instantiate(BallPrefab, PlayerTwoBallLaunchPositions[CurrentLaunchPosition].position, PlayerTwoBallLaunchPositions[CurrentLaunchPosition].rotation);
                            Balls.Add(ballTwo);
                            ballTwo.SetActive(true);
                            PlayLaunchSound();

                            RandomBallLaunchDelayTime = Random.Range(3f, 10f);
                            BallLastLaunchedTime = Time.time;
                        }
                    }
                }
                else
                {
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
}
