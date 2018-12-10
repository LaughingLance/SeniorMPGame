using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkLobbyFades : MonoBehaviour
{
    public GameObject FadeObjectHolder;
    SceneFading fadeInOut;

    public GameObject player;
    private Vector3 playerPostion;

    // Use this for initialization
    void Start ()
    {
        playerPostion = player.transform.position;
        playerPostion.y = 0;
        player.transform.position = playerPostion;

        fadeInOut = FadeObjectHolder.GetComponent<SceneFading>();
        fadeInOut.FadeToClear();
    }
}
