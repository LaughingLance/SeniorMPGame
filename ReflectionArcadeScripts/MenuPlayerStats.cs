using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerStats : MonoBehaviour
{
    public GameObject PlayerMenu;
    public GameObject PlayerMenuButton;
    public GameObject AchievementsMenu;
    public GameObject AchievementsMenuButton;
    public GameObject HowToMenu;
    public GameObject HowToMenuButton;

    public Material red;
    public Material blue;

    Renderer rend;
    Renderer rendAchieve;
    Renderer rendHowTo;

    private GameObject menu;
    PlayerStatsMenu playerMenu;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start ()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        menu = GameObject.Find("Menu");
        playerMenu = menu.GetComponent<PlayerStatsMenu>();

        rend = GetComponent<Renderer>();
        rendAchieve = AchievementsMenuButton.GetComponent<Renderer>();
        rendHowTo = HowToMenuButton.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            soundController.PlaySoundOneShot();
            PlayerMenu.SetActive(true);
            rend.material = blue;
            AchievementsMenu.SetActive(false);
            rendAchieve.material = red;
            HowToMenu.SetActive(false);
            rendHowTo.material = red;

            playerMenu.UpdatePlayerStatsMenu();
        }
    }
}
