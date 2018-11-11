using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKeyboard : MonoBehaviour
{
    public GameObject Keyboard;

    private GameObject statsMenu;
    PlayerStatsMenu playerStatsMenu;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;


    // Use this for initialization
    void Start ()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        statsMenu = GameObject.Find("Menu");
        playerStatsMenu = statsMenu.GetComponent<PlayerStatsMenu>();
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!playerStatsMenu.isKeyboardActive)
            {
                soundController.PlaySoundOneShot();
                playerStatsMenu.isKeyboardActive = true;
                StartCoroutine("TurnKeysOn");
            }
        }
    }

    IEnumerator TurnKeysOn()
    {
        yield return new WaitForSeconds(0.5f);
        Keyboard.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerStatsMenu.isKeyPressed = false;
    }
}
