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

    void Start()
    {
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
        yield return new WaitForSeconds(0.11f);
        SceneManager.LoadScene("lobby");
    }
}
