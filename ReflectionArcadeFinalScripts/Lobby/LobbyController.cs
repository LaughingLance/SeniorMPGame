using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    public GameObject FadeInOutHolder;
    public GameObject Player;
    private Vector3 playerLocation;
    SceneFading fadeInOut;

	// Use this for initialization
	void Start ()
    {
        playerLocation = Player.transform.position;
        playerLocation.y = 2f;
        Player.transform.position = playerLocation;
        fadeInOut = FadeInOutHolder.GetComponent<SceneFading>();
        fadeInOut.FadeToClear();
	}
}
