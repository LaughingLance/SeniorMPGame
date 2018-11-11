﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSwap : MonoBehaviour
{
    public GameObject leftHandWeapon;
    public GameObject rightHandWeapon;

    public GameObject GoldenSwordLeft;
    public GameObject GoldenSwordRight;

    public GameObject WoodenClubLeft;
    public GameObject WoodenClubRight;

    private bool rightHandActive = true;

    private GameObject dataController;
    PlayerDataController playerData;

    public GameObject LeftWeaponSpeaker;
    public GameObject RightWeaponSpeaker;
    AudioSource LeftSpeakerSource;
    AudioSource RightSpeakerSource;
    public AudioClip WeaponHitSound;

    // Use this for initialization
    void Start ()
    {
        LeftSpeakerSource = LeftWeaponSpeaker.GetComponent<AudioSource>();
        RightSpeakerSource = RightWeaponSpeaker.GetComponent<AudioSource>();

        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        switch (playerData.PlayerWeapon)
        {
            case "GoldenSword":
                leftHandWeapon = GoldenSwordLeft;
                rightHandWeapon = GoldenSwordRight;
                break;
            case "WoodenClub":
                leftHandWeapon = WoodenClubLeft;
                rightHandWeapon = WoodenClubRight;
                break;
        }

        leftHandWeapon.SetActive(false);
        rightHandWeapon.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (rightHandActive)
        {
            if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                rightHandWeapon.SetActive(false);
                leftHandWeapon.SetActive(true);
                rightHandActive = false;
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                leftHandWeapon.SetActive(false);
                rightHandWeapon.SetActive(true);
                rightHandActive = true;
            }
        }
	}

    public void PlayWeaponHitSound()
    {
        if (rightHandActive)
        {
            RightSpeakerSource.PlayOneShot(WeaponHitSound, 1f);
        }
        else
        {
            LeftSpeakerSource.PlayOneShot(WeaponHitSound, 1f);
        }
    }
}
