using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPLClientEntryButton : MonoBehaviour
{
    public GameObject HostButton;
    public GameObject ClientButton;
    public GameObject KeyboardCover;
    public GameObject NetworkKeyboard;
    public GameObject KeyboardHinge;
    public GameObject IPCanvas;

    public bool isKeyboardUp = false;
    public bool isKeyboardMoving = false;

    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    void Start()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();
    }

    void Update()
    {
        if (isKeyboardMoving)
        {
            if (!isKeyboardUp)
            {
                if (KeyboardHinge.transform.rotation.eulerAngles.x >= 40)
                {
                    KeyboardHinge.transform.Rotate(Vector3.right * -20f * Time.deltaTime);
                }
                else
                {
                    isKeyboardMoving = false;
                    isKeyboardUp = true;
                }
            }
            else
            {
                if (KeyboardHinge.transform.rotation.eulerAngles.x < 89.8)
                {
                    KeyboardHinge.transform.Rotate(Vector3.right * 20f * Time.deltaTime);
                }
                else
                {
                    IPCanvas.SetActive(false);
                    HostButton.SetActive(true);
                    KeyboardCover.SetActive(true);
                    isKeyboardMoving = false;
                    isKeyboardUp = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerOne")
        {
            if (!isKeyboardUp)
            {
                soundController.PlaySoundOneShot();
                IPCanvas.SetActive(true);
                HostButton.SetActive(false);
                KeyboardCover.SetActive(false);
                isKeyboardMoving = true;
            }
        }
    }
}
