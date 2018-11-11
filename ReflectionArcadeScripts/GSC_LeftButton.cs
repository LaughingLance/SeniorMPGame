using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSC_LeftButton : MonoBehaviour
{
    public GameObject gameSelector;
    GameSelectorController gameSelectorController;
    private bool isRotating = false;
    public Material Green;
    public Material Red;
    Renderer rend;
    public GameObject lightObject;
    Light buttonLight;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    // Use this for initialization
    void Start()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();

        gameSelectorController = gameSelector.GetComponent<GameSelectorController>();
        rend = GetComponent<Renderer>();
        buttonLight = lightObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSelectorController.Rotating == false)
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
            gameSelectorController.SelectorRotation -= gameSelectorController.RotationIncrement;
            gameSelectorController.RotationDirection = "Right";
            gameSelectorController.Rotating = true;
            isRotating = true;
        }
    }
}