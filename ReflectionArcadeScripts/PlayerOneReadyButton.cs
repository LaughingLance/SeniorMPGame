using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneReadyButton : MonoBehaviour
{
    private GameObject controller;
    public GameObject ReadyButton;
    GameController gameController;
    public Material Red;
    Renderer rend;
    public GameObject lightObject;
    Light StartLight;
    public GameObject StartText;
    public GameObject WaitingText;

	// Use this for initialization
	void Start ()
    {
        controller = GameObject.Find("Game Controller");
        gameController = controller.GetComponent<GameController>();
        rend = GetComponent<Renderer>();
        StartLight = lightObject.GetComponent<Light>();
	}

    void Update()
    {
        if (gameController.PlayerOneReady && gameController.PlayerTwoReady)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerOne")
        {
            rend.material = Red;
            StartLight.color = Color.red;
            StartText.SetActive(false);
            WaitingText.SetActive(true);
            gameController.PlayerOneReady = true;
        }
    }
}
