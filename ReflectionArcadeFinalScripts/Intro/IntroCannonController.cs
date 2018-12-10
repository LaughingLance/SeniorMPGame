using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCannonController : MonoBehaviour
{
    public GameObject FadeObjectHolder;
    public GameObject CannonTrapTop;
    private float DelayTime;
    public bool isCannonStarted = false;
    private bool isCannonUp = false;
    private bool isRotating = false;
    public Transform launchPosition;
    public GameObject ballPrefab;

    public bool hasStartButtonBeenPressed = false;
    private bool hasCannonRun = false;
    private bool transitionTimerStarted = false;

    public GameObject CannonSpeaker;
    public AudioClip CannonFire;
    AudioSource SpeakerSource;
    SceneFading fadeInOut;

	// Use this for initialization
	void Start ()
    {
        SpeakerSource = CannonSpeaker.GetComponent<AudioSource>();
        fadeInOut = FadeObjectHolder.GetComponent<SceneFading>();
        DelayTime = Random.Range(0.5f, 2.5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hasStartButtonBeenPressed)
        {
            if (!hasCannonRun)
            {
                StartCannon();
                hasStartButtonBeenPressed = false;
                hasCannonRun = true;
            }            
        }

        if (isCannonStarted)
        {
            if (!isCannonUp)
            {
                if (CannonTrapTop.transform.position.y < -0.3f)
                {
                    CannonTrapTop.transform.Translate(Vector3.up * 0.02f * Time.deltaTime);
                }
                else
                {
                    isCannonUp = true;
                }
            }
            else
            {
                if (!isRotating)
                {
                    var ball = (GameObject)Instantiate(ballPrefab, launchPosition.position, launchPosition.rotation);
                    ball.SetActive(true);
                    SpeakerSource.PlayOneShot(CannonFire, 1f);
                    isRotating = true;
                    
                }
                else
                {

                }
            }

            if (gameObject.name == "gunMiddle")
            {
                if (!transitionTimerStarted)
                {
                    StartCoroutine("TransitionFadeOutTimer");
                    transitionTimerStarted = true;
                }
            }
        }

	}

    public void StartCannon()
    {
        StartCoroutine("RaiseTopDelay");
    }

    IEnumerator RaiseTopDelay()
    {
        yield return new WaitForSeconds(DelayTime);
        isCannonStarted = true;
    }

    IEnumerator TransitionFadeOutTimer()
    {
        yield return new WaitForSeconds(10f);
        fadeInOut.FadeToBlack();
        StartCoroutine("SceneTransition");
    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("lobby");
    }
}
