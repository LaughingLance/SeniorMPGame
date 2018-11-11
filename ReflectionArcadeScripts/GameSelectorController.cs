using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectorController : MonoBehaviour
{
    public GameObject GameSelector;

    public float SelectorRotation = 0;
    public float SelectorMovementSpeed = 1;
    public float RotationIncrement = 30f;
    private float CurrentRotation;
    private float NegativeRotation;

    private Quaternion TransitionRotation;

    public bool Rotating = false;
    
    public string RotationDirection;

    private bool RotationSoundStarted = false;
    public GameObject RotationSpeaker;
    public AudioClip RotationSound;
    AudioSource RotationsSoundSource;

    // Use this for initialization
    void Start()
    {
        RotationsSoundSource = RotationSpeaker.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotating)
        {
            if (!RotationSoundStarted)
            {
                RotationsSoundSource.PlayOneShot(RotationSound, 1f);
                RotationSoundStarted = true;
            }

            if (RotationDirection == "Left")
            {
                if (SelectorRotation >= 0 && NegativeRotation < 1)
                {
                    RotateLeft();
                }
                else
                {
                    RotateLeftFromNegative();
                }
            }
            else if (RotationDirection == "Right")
            {
                if (SelectorRotation >= 0 && NegativeRotation < 1)
                {
                    RotateRightFromPositive();
                }
                else
                {
                    RotateRight();
                }
            }
        }
    }

    private void RotateLeft()
    {
        CurrentRotation = GameSelector.transform.rotation.eulerAngles.y;

        if (SelectorRotation >= 360 && CurrentRotation < 1)
        {
            SelectorRotation = 0;
            CurrentRotation = 0;
            GameSelector.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            Rotating = false;
        }

        if (CurrentRotation < SelectorRotation)
        {
            GameSelector.transform.Rotate(0f, Time.deltaTime * RotationIncrement * 0.5f, 0f);
        }
        else
        {
            Rotating = false;
            RotationSoundStarted = false;
        }
    }

    private void RotateLeftFromNegative()
    {
        CurrentRotation = GameSelector.transform.rotation.eulerAngles.y;
        NegativeRotation = 360 + SelectorRotation;

        if (NegativeRotation == 360)
        {
            if (CurrentRotation > 359 || CurrentRotation < 2)
            {
                SelectorRotation = 0;
                CurrentRotation = 0;
                NegativeRotation = 0;
                GameSelector.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                Rotating = false;
            }
        }

        if (CurrentRotation < NegativeRotation)
        {
            GameSelector.transform.Rotate(0f, Time.deltaTime * RotationIncrement * 0.5f, 0f);
        }
        else
        {
            Rotating = false;
            RotationSoundStarted = false;
        }

    }

    private void RotateRightFromPositive()
    {
        CurrentRotation = GameSelector.transform.rotation.eulerAngles.y;

        if (CurrentRotation > 359 || CurrentRotation < 1 && CurrentRotation != 0)
        {
            SelectorRotation = 0;
            CurrentRotation = 0;
            GameSelector.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            Rotating = false;
        }

        if (CurrentRotation > SelectorRotation)
        {
            GameSelector.transform.Rotate(0f, Time.deltaTime * RotationIncrement * -0.5f, 0f);
        }
        else
        {
            Rotating = false;
            RotationSoundStarted = false;
        }
    }

    private void RotateRight()
    {
        CurrentRotation = GameSelector.transform.rotation.eulerAngles.y;
        NegativeRotation = 360 + SelectorRotation;
                
        // Resets CodexRotation to 0 after a full rotation of the night codex
        if (SelectorRotation <= -360 && CurrentRotation > 358)
        {
            SelectorRotation = 0;
            CurrentRotation = 0;
            NegativeRotation = 0;
            GameSelector.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            Rotating = false;
        }

        if (CurrentRotation > NegativeRotation || CurrentRotation == 0)
        {
            GameSelector.transform.Rotate(0f, Time.deltaTime * RotationIncrement * -0.5f, 0f);
        }
        else
        {
            Rotating = false;
            RotationSoundStarted = false;
        }
    }
}
