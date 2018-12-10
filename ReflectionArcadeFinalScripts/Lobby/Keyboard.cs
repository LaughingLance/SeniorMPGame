using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    Light KeyLight;

    private GameObject statsMenu;
    PlayerStatsMenu playerStatsMenu;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start ()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        KeyLight = GetComponentInChildren<Light>();
        statsMenu = GameObject.Find("Menu");
        playerStatsMenu = statsMenu.GetComponent<PlayerStatsMenu>();
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!playerStatsMenu.isKeyPressed)
            {
                soundController.PlaySoundOneShot();
                if (gameObject.name == "Enter")
                {
                    playerStatsMenu.UpdatePlayerName(gameObject.name.ToString());
                }
                else
                {
                    KeyLight.color = Color.red;
                    playerStatsMenu.UpdatePlayerName(gameObject.name.ToString());
                    playerStatsMenu.isKeyPressed = true;
                    StartCoroutine("KeyboardPauseTimer");
                }
            }
        }
    }

    IEnumerator KeyboardPauseTimer()
    {
        yield return new WaitForSeconds(1f);
        KeyLight.color = Color.white;
        playerStatsMenu.isKeyPressed = false;
    }
}
