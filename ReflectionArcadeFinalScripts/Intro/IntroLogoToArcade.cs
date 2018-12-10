using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLogoToArcade : MonoBehaviour
{
    public GameObject FadeObjectHolder;
    public GameObject Logo;
    public GameObject Arcade;
    public GameObject Player;
    SceneFading fadeInOut;

    public GameObject LogoSpeaker;
    public AudioClip LaughSound;
    AudioSource SpeakerSource;

    public GameObject ArcadeSpeaker;

    public bool ArcadeOn = false;

    private Vector3 playerPosition;

	// Use this for initialization
	void Start ()
    {
        playerPosition = Player.transform.position;
        playerPosition.y = 0f;
        Player.transform.position = playerPosition;
        SpeakerSource = LogoSpeaker.GetComponent<AudioSource>();

        Arcade.SetActive(false);
        fadeInOut = FadeObjectHolder.GetComponent<SceneFading>();
        StartCoroutine("InitialPause");
	}

    IEnumerator InitialPause()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("FadeInTimer");
    }

    IEnumerator FadeInTimer()
    {
        yield return new WaitForSeconds(1.0f);
        fadeInOut.FadeToClear();
        StartCoroutine("PauseToLaugh");
    }

    IEnumerator PauseToLaugh()
    {
        yield return new WaitForSeconds(0.5f);
        SpeakerSource.PlayOneShot(LaughSound, 1f);
        StartCoroutine("FadeOutTimer");
    }

    IEnumerator FadeOutTimer()
    {
        yield return new WaitForSeconds(2.5f);
        fadeInOut.FadeToBlack();
        StartCoroutine("DarknessPause");
    }

    IEnumerator DarknessPause()
    {
        yield return new WaitForSeconds(1f);
        Logo.SetActive(false);
        Arcade.SetActive(true);
        fadeInOut.FadeToClear();
        ArcadeSpeaker.GetComponent<AudioSource>().mute = false;
        StartCoroutine("FadeInToArcade");
    }

    IEnumerator FadeInToArcade()
    {
        yield return new WaitForSeconds(1.5f);
        ArcadeOn = true;
    }

}
