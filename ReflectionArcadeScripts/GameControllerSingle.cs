using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSingle : MonoBehaviour
{
    public List<Transform> BallLaunchPositions = new List<Transform>();
    public List<GameObject> Balls = new List<GameObject>();

    public GameObject BallPrefab;
    public GameObject TopLeftSpeaker;
    public GameObject TopRightSpeaker;
    public GameObject BottomLeftSpeaker;
    public GameObject BottomRightSpeaker;
    public AudioClip CannonFire;

    public bool PlayerReady = false;
    public bool GameStarted = false;
    public bool StartPauseTimerComplete = false;

    AudioSource TopLeftSpeakerSource;
    AudioSource TopRightSpeakerSource;
    AudioSource BottomLeftSpeakerSource;
    AudioSource BottomRightSpeakerSource;

    // Insert GameTimer Stuff Here

    private float BallLastLaunchedTime;
    private float RandomBallLaunchDelayTime;

    private int CurrentLaunchPosition;

    private GameObject scoreObject;
    SingleplayerScoreTracker scoreTracker;

	// Use this for initialization
	void Start ()
    {
        scoreObject = GameObject.Find("GameScoreController");
        scoreTracker = scoreObject.GetComponent<SingleplayerScoreTracker>();

        RandomBallLaunchDelayTime = Random.Range(1f, 4f);
        BallLastLaunchedTime = Time.time;
        TopLeftSpeakerSource = TopLeftSpeaker.GetComponent<AudioSource>();
        TopRightSpeakerSource = TopRightSpeaker.GetComponent<AudioSource>();
        BottomLeftSpeakerSource = BottomLeftSpeaker.GetComponent<AudioSource>();
        BottomRightSpeakerSource = BottomRightSpeaker.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (PlayerReady)
        {
            if (GameStarted)
            {
                if (StartPauseTimerComplete)
                {
                    if (RandomBallLaunchDelayTime < Time.time - BallLastLaunchedTime)
                    {
                        if (CurrentLaunchPosition < BallLaunchPositions.Count - 1)
                        {
                            CurrentLaunchPosition++;
                        }
                        else { CurrentLaunchPosition = 0; }
                        var ball = (GameObject)Instantiate(BallPrefab, BallLaunchPositions[CurrentLaunchPosition].position, BallLaunchPositions[CurrentLaunchPosition].rotation);
                        Balls.Add(ball);
                        ball.SetActive(true);
                        PlayLaunchSound();

                        RandomBallLaunchDelayTime = Random.Range(1f, 4f);
                        BallLastLaunchedTime = Time.time;
                    }
                }
            }
            else
            {
                scoreTracker.SetScoreTextForGamePlay();
                StartCoroutine("StartDelayTimer");
                GameStarted = true;
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
                TopLeftSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
            case 1:
                TopRightSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
            case 2:
                BottomLeftSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
            case 3:
                BottomRightSpeakerSource.PlayOneShot(CannonFire, 1f);
                break;
        }
    }
}
