using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTimer : MonoBehaviour
{
    public GameObject FadeObjectHolder;
    SceneFading fadeInOut;
    public GameObject player;
    private Vector3 playerPosition;

	// Use this for initialization
	void Start ()
    {
        playerPosition = player.transform.position;
        playerPosition.y = 0f;
        player.transform.position = playerPosition;
        fadeInOut = FadeObjectHolder.GetComponent<SceneFading>();
        fadeInOut.FadeToClear();
        StartCoroutine("PauseBeforeExiting");
	}

    IEnumerator PauseBeforeExiting()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine("FinalFadeToBlack");
        fadeInOut.FadeToBlack();
    }
	
    IEnumerator FinalFadeToBlack()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

}
