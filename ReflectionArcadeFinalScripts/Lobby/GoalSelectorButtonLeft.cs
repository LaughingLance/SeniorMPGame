using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSelectorButtonLeft : MonoBehaviour
{
    public GameObject Console;
    GoalSelectorController goalRotater;
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

        goalRotater = Console.GetComponent<GoalSelectorController>();
        rend = GetComponent<Renderer>();
        buttonLight = lightObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goalRotater.switchingGoal == false)
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
            goalRotater.switchingGoal = true;
            isRotating = true;
            goalRotater.RotateGoalLeft();
        }
    }
}
