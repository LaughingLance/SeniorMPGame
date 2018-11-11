using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPopSoundController : MonoBehaviour
{
    public GameObject PopSpeaker;
    public AudioClip TargetPopSound;
    AudioSource TargetPopSpeakerSource;

    void Start()
    {
        TargetPopSpeakerSource = PopSpeaker.GetComponent<AudioSource>();
    }

    public void PlayPopSound()
    {
        TargetPopSpeakerSource.PlayOneShot(TargetPopSound, 1f);
    }
}
