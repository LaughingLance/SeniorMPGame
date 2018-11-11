using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayerStartButton : MonoBehaviour
{
    public GameObject Controller;
    GameControllerSingle GameController;
    public GameObject Score;
    SingleplayerScoreTracker ScoreTracker;
    public GameObject ExitButton;

    public GameObject StartSpeaker;
    public AudioClip ButtonPressSound;
    AudioSource SpeakerSource;

	// Use this for initialization
	void Start ()
    {
        SpeakerSource = StartSpeaker.GetComponent<AudioSource>();

        GameController = Controller.GetComponent<GameControllerSingle>();
        ScoreTracker = Score.GetComponent<SingleplayerScoreTracker>();
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerOne")
        {
            SpeakerSource.PlayOneShot(ButtonPressSound, 1f);
            StartCoroutine("StartTheGame");
        }
    }

    IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(0.11f);
        ScoreTracker.isGameScoreShowing = false;
        GameController.PlayerReady = true;
        GameController.GameStarted = false;
        GameController.StartPauseTimerComplete = false;
        ExitButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
