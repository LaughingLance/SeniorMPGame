using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelectorButtonRight : MonoBehaviour
{
    public GameObject BallSelector;
    PlayerBallController ballController;
    private bool isSwitching = false;
    public Material Green;
    public Material Red;
    Renderer rend;
    public GameObject lightObject;
    Light buttonLight;
    public string player;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start ()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        ballController = BallSelector.GetComponent<PlayerBallController>();
        rend = GetComponent<Renderer>();
        buttonLight = lightObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (ballController.switchingBall == false)
        {
            isSwitching = false;
            rend.material = Green;
            buttonLight.color = Color.green;
        }
        else
        {
            isSwitching = true;
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if (!isSwitching)
        {
            soundController.PlaySoundOneShot();
            rend.material = Red;
            buttonLight.color = Color.red;
            ballController.ballBeingSwitched = player;
            ballController.switchingBall = true;
            ballController.RemoveOldBallRight();
            isSwitching = true;
        }
    }
}
