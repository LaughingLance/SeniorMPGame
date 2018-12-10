using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAchievements : MonoBehaviour
{
    public GameObject PlayerMenu;
    public GameObject PlayerMenuButton;
    public GameObject AchievementsMenu;
    public GameObject AchievementsMenuButton;
    public GameObject HowToMenu;
    public GameObject HowToMenuButton;
    public GameObject HowToText;

    public Material red;
    public Material blue;

    Renderer rendPlayer;
    Renderer rend;
    Renderer rendHowTo;

    private GameObject menu;
    AchievementsMenu achieveMenu;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        menu = GameObject.Find("Menu");
        achieveMenu = menu.GetComponent<AchievementsMenu>();

        rendPlayer = PlayerMenuButton.GetComponent<Renderer>();
        rend = GetComponent<Renderer>();
        rendHowTo = HowToMenuButton.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            soundController.PlaySoundOneShot();
            PlayerMenu.SetActive(false);
            rendPlayer.material = red;
            AchievementsMenu.SetActive(true);
            rend.material = blue;
            HowToMenu.SetActive(false);
            rendHowTo.material = red;
            HowToText.SetActive(false);

            achieveMenu.UpdateAchievementsMenu();
        }
    }
}
