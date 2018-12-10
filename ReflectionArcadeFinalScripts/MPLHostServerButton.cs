using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MPLHostServerButton : MonoBehaviour
{
    private GameObject ButtonSoundSpeaker;
    SinglePlaySoundController soundController;

    void Start()
    {
        ButtonSoundSpeaker = GameObject.Find("ButtonPressSpeaker");
        soundController = ButtonSoundSpeaker.GetComponent<SinglePlaySoundController>();
    }

        private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerOne")
        {
            soundController.PlaySoundOneShot();
            GameObject.Find("Canvas").GetComponent<SceneFading>().FadeToBlack();
            NetworkManager.singleton.GetComponent<CustomNetworkMenu>().StartServer();
        }
    }
}
