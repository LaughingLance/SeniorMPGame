using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleplayerExitButton : MonoBehaviour
{
    public bool OkayToExit = false;
    public GameObject Speaker;
    public AudioClip ButtonSound;
    AudioSource SpeakerSource;

    public GameObject FadeObjectHolder;
    SceneFading fadeInOut;

    void Start()
    {
        fadeInOut = FadeObjectHolder.GetComponent<SceneFading>();
        SpeakerSource = Speaker.GetComponent<AudioSource>();
        StartCoroutine("PauseToActivate");
    }

    private void OnCollisionEnter(Collision col)
    {
        if (OkayToExit)
        {
            if (col.gameObject.tag == "PlayerOne")
            {
                SpeakerSource.PlayOneShot(ButtonSound, 1f);
                fadeInOut.FadeToBlack();
                StartCoroutine("ExitTheCircusGame");
            }
        }
    }

    IEnumerator PauseToActivate()
    {
        yield return new WaitForSeconds(2.5f);
        OkayToExit = true;
    }

    IEnumerator ExitTheCircusGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("lobby");
    }
}
