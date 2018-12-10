using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStartButton : MonoBehaviour
{
    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject Gun3;

    public GameObject AudioSpeaker;
    public AudioClip AudioBeep;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Gun1.GetComponent<IntroCannonController>().hasStartButtonBeenPressed = true;
            Gun2.GetComponent<IntroCannonController>().hasStartButtonBeenPressed = true;
            Gun3.GetComponent<IntroCannonController>().hasStartButtonBeenPressed = true;
            AudioSpeaker.GetComponent<AudioSource>().PlayOneShot(AudioBeep, 1f);
            Destroy(gameObject);
        }
    }
}
