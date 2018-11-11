using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleMenuOpenClose : MonoBehaviour
{
    public GameObject Menu;

    private bool isMenuOpen = false;
    private bool isMenuMoving = false;
    private string MenuMovement;
    private float MenuOpenYPosition = 1.663f;

    public Material Green;
    public Material Red;
    Renderer rend;
    public GameObject LeftLightObject;
    public GameObject RightLightObject;
    Light LeftButtonLight;
    Light RightButtonLight;

    private Vector3 MenuStartingPostion;

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

        MenuStartingPostion = Menu.transform.position;
        rend = GetComponent<Renderer>();
        LeftButtonLight = LeftLightObject.GetComponent<Light>();
        RightButtonLight = RightLightObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isMenuMoving)
        {
            if (MenuMovement == "UP")
            {
                if (Menu.transform.position.y < MenuOpenYPosition)
                {
                    Menu.transform.Translate(Vector3.up * 0.5f * Time.deltaTime);
                }
                else
                {
                    rend.material = Green;
                    LeftButtonLight.color = Color.green;
                    RightButtonLight.color = Color.green;

                    isMenuOpen = true;
                    isMenuMoving = false;
                }
            }
            else if (MenuMovement == "DOWN")
            {
                if (Menu.transform.position.y > MenuStartingPostion.y)
                {
                    Menu.transform.Translate(Vector3.up * -0.5f * Time.deltaTime);
                }
                else
                {
                    rend.material = Green;
                    LeftButtonLight.color = Color.green;
                    RightButtonLight.color = Color.green;

                    isMenuOpen = false;
                    isMenuMoving = false;
                }
            }
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if (!isMenuMoving)
        {
            if (!isMenuOpen)
            {
                soundController.PlaySoundOneShot();
                playerMenu.UpdatePlayerStatsMenu();

                rend.material = Red;
                LeftButtonLight.color = Color.red;
                RightButtonLight.color = Color.red;

                MenuMovement = "UP";
                isMenuMoving = true;
            }
            else
            {
                soundController.PlaySoundOneShot();
                rend.material = Red;
                LeftButtonLight.color = Color.red;
                RightButtonLight.color = Color.red;

                MenuMovement = "DOWN";
                isMenuMoving = true;
            }
        }
    }
}
