using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectorButtonRight : MonoBehaviour
{
    public GameObject Weapons;
    RotateWeapon weaponRotater;
    private bool isRotating = false;
    public Material Green;
    public Material Red;
    Renderer rend;
    public GameObject lightObject;
    Light buttonLight;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start ()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        weaponRotater = Weapons.GetComponent<RotateWeapon>();
        rend = GetComponent<Renderer>();
        buttonLight = lightObject.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (weaponRotater.switchingWeapon == false)
        {
            isRotating = false;
            rend.material = Green;
            buttonLight.color = Color.green;
        }
        else
        {
            isRotating = true;
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if (!isRotating)
        {
            soundController.PlaySoundOneShot();
            rend.material = Red;
            buttonLight.color = Color.red;
            weaponRotater.switchingWeapon = true;
            isRotating = true;
            weaponRotater.RotatingWeaponsRight();
        }
    }
}
