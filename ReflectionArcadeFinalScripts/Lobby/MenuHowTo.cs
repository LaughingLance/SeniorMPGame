using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHowTo : MonoBehaviour
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
    Renderer rendAchieve;
    Renderer rend;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        rendPlayer = PlayerMenuButton.GetComponent<Renderer>();
        rendAchieve = AchievementsMenuButton.GetComponent<Renderer>();
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            soundController.PlaySoundOneShot();
            PlayerMenu.SetActive(false);
            rendPlayer.material = red;
            AchievementsMenu.SetActive(false);
            rendAchieve.material = red;
            HowToMenu.SetActive(true);
            rend.material = blue;
            HowToText.SetActive(true);
        }
    }
}
