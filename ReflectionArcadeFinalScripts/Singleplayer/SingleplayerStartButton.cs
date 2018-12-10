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

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        SpeakerSource = StartSpeaker.GetComponent<AudioSource>();

        GameController = Controller.GetComponent<GameControllerSingle>();
        ScoreTracker = Score.GetComponent<SingleplayerScoreTracker>();

        player = GameObject.Find("Player_Single");
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
        player.GetComponent<PlayerWeaponSwap>().isWeaponInitiated = true;
        ExitButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
