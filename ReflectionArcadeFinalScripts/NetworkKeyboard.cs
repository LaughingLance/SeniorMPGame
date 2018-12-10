using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkKeyboard : MonoBehaviour
{
    Light KeyLight;

    MPLIPandPort ipAndPort;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        KeyLight = GetComponentInChildren<Light>();

        ipAndPort = GameObject.Find("KeyboardHinge").GetComponent<MPLIPandPort>();
        StartCoroutine("KeyboardPauseTimer");

        if (gameObject.name == "IP")
        {
            if (ipAndPort.isIPSelected)
            {
                KeyLight.color = Color.red;
            } 
            else
            {
                KeyLight.color = Color.white;
            }
        }

        if (gameObject.name == "Port")
        {
            if (!ipAndPort.isIPSelected)
            {
                KeyLight.color = Color.red;
            }
            else
            {
                KeyLight.color = Color.white;
            }
        }
    }

    void Update()
    {
        if (gameObject.name == "IP")
        {
            if (ipAndPort.isIPSelected)
            {
                KeyLight.color = Color.red;
            }
            else
            {
                KeyLight.color = Color.white;
            }
        }

        if (gameObject.name == "Port")
        {
            if (!ipAndPort.isIPSelected)
            {
                KeyLight.color = Color.red;
            }
            else
            {
                KeyLight.color = Color.white;
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerOne")
        {
            if (!ipAndPort.isKeyPressed)
            {
                soundController.PlaySoundOneShot();
     
                KeyLight.color = Color.red;
                ipAndPort.UpdateAddress(gameObject.name.ToString());
                ipAndPort.isKeyPressed = true;
                StartCoroutine("KeyboardPauseTimer");
                
            }
        }
    }

    IEnumerator KeyboardPauseTimer()
    {
        yield return new WaitForSeconds(1f);
        KeyLight.color = Color.white;
        ipAndPort.isKeyPressed = false;
    }
}
